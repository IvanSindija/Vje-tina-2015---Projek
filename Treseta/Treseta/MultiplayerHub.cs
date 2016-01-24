using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Treseta.Models;

namespace Treseta.Hubs
{
    /// <summary>
    /// koristm ga za chat i igru
    /// </summary>
    public class MultiplayerHub : Hub
    {
        private List<Room> sobe;

        public MultiplayerHub()
        {
            if (sobe == null)
                sobe = SingletonListaSoba.dohvatiListuSoba();
        }
        //odredi koja je bacena karta iz kordinate klika
        private Karta getKliknutaKarta(Room sobaIgre ,int mouseX , int mouseY)
        {
            for (int i = sobaIgre.krugIgre-1; i >=0; i--)
            {
                Karta temp = sobaIgre.igraci[sobaIgre.igracNaPotezu].mojeKarte.ElementAt(i);//karta za provjeru ide od najvise prema najnizoj
                if (temp.xPoz < mouseX && (temp.xPoz + temp.sirina) > mouseX && temp.yPoz <mouseY && temp.yPoz +temp.visina > mouseY)//kliknuta je ova karta
                {
                    return temp;
                }
            }
            return null;
        }


        /// <summary>
        /// kad se klikne na platno u igri pozove se ova funkcija
        /// </summary>
        /// <param name="mouseX"></param>
        /// <param name="mouseY"></param>
        /// <param name="imeSobe"></param>
        public void cardClick(int mouseX, int mouseY, string imeSobe)
        {
            Room sobaIgre = sobe.Find(x => x.imeSobe.Equals(imeSobe));
            var id = Context.ConnectionId;
            if (sobaIgre.igraci[sobaIgre.igracNaPotezu].connectioId != id)//igrac koji nije na potezu je kliknuo na svoje karte
            {
                Clients.Client(id).upozorenje("Nisi na potezu");
                return;
            }
            
            Karta kliknutaKarta = getKliknutaKarta(sobaIgre , mouseX , mouseY);
            if (kliknutaKarta == null)
            {
                return;//karta nije kliknuta ne uciniti nista
            }
            //pamcenje bacenih karata provjera dali korisnik krsi pravila
            //ova dva if bloka spreme bacnje karte povecaju broj bacenih karata i maknu kartu iz liste karata kod igraca
            if (sobaIgre.brojBacenihKarata == 0)
            {
                baciKartu(sobaIgre, kliknutaKarta);

            }
            else
            {
                if (sobaIgre.baceneKarte[0].zvanje == kliknutaKarta.zvanje)
                {
                    baciKartu(sobaIgre, kliknutaKarta);
                }
                else
                {
                    int brojKarata = sobaIgre.igraci[sobaIgre.igracNaPotezu].mojeKarte.Count(x => x.zvanje == sobaIgre.baceneKarte[0].zvanje);
                    if (brojKarata > 0)
                    {
                        Clients.Client(id).upozorenje("Moras odgovarati na zvanje");
                        return;
                    }
                    baciKartu(sobaIgre, kliknutaKarta);
                }
            }

            //saljemo igraci podatke o kliknutoj karti**********************************************************************
            Clients.Client(id).bacenaJe(kliknutaKarta, 0 , sobaIgre.igraci[sobaIgre.igracNaPotezu].mojeKarte);//iz kliknute kate moze dobiti 
                                                          //podatke o pozicije karte da zna bacac moze pobrisati a 0 zato jer se ovo salje korisniku koji je bacio kartu
                                                          //sad saljmo svima ostalima
            for (int i = 1; i < 4; i++)
            {
                Clients.Client(sobaIgre.igraci[(sobaIgre.igracNaPotezu + i) % 4].connectioId).bacenaJe(kliknutaKarta, i , null);//ovima nemoram slati njihovu ruku zato null
            }
            sobaIgre.igracNaPotezu = (sobaIgre.igracNaPotezu + 1) % 4;
            //***************************************************************************************************************

            //zavrsija je krug igre 
            if (sobaIgre.brojBacenihKarata == 4)
            {
                System.Threading.Thread.Sleep(2000);//pricekaj 2sec da igraci vide tko je sto bacio
                sobaIgre.brojBacenihKarata = 0;
                for (int i = 0; i < 4; i++)
                    Clients.Client(sobaIgre.igraci[i].connectioId).noviKrug();

                //dodjela bodova ovog kruga i određivane sljedeceg igraca
                zavrsetakKruga(sobaIgre);
            }
           
        }

        //određuje koji je sljedeci igrac, dodojeljuje bodov pobjedniku kruga i provjerava dali je igra zavrsila
        private void zavrsetakKruga(Room sobaIgre)
        {
            Karta pobjednickaKarta = sobaIgre.baceneKarte[0];
            int pozPobjednickaKarta = 0;
            int bodoviKruga = pobjednickaKarta.bodovi;
            for (int j = 1; j < 4; j++)
            {
                bodoviKruga += sobaIgre.baceneKarte[j].bodovi;
                Karta tempPobjednickaKarta = pobjednickaKarta.tkoJeJaci(sobaIgre.baceneKarte[j]);
                if (!pobjednickaKarta.Equals(tempPobjednickaKarta))
                {
                    pobjednickaKarta = tempPobjednickaKarta;
                    pozPobjednickaKarta = j;
                }
            }
            sobaIgre.igracNaPotezu = (sobaIgre.igracNaPotezu + pozPobjednickaKarta) % 4;//igrac koji je bacio najjacu kartu ovaj krug
            dodjeliBodove(sobaIgre, bodoviKruga);
            //odredi koji je krug igre
            sobaIgre.krugIgre--;

            //kraj igre
            if (sobaIgre.krugIgre == 0)
            {
                //davanje bodova za zadnje dizanje
                dodjeliBodove(sobaIgre, 3);

                for (int i = 0; i < 4; i++)
                    Clients.Client(sobaIgre.igraci[i].connectioId).krajIgre(sobaIgre.bodoviTimaA / 3, sobaIgre.bodoviTimaB / 3);
            }
        }
        //dodjel bodova
        private void dodjeliBodove(Room sobaIgre , int brojBodova)
        {
            if (sobaIgre.igracNaPotezu == 0 || sobaIgre.igracNaPotezu == 2)
                sobaIgre.bodoviTimaA += brojBodova;
            if (sobaIgre.igracNaPotezu == 1 || sobaIgre.igracNaPotezu == 3)
                sobaIgre.bodoviTimaB += brojBodova;
        }

        //bacanje karte 
        private void baciKartu(Room sobaIgre, Karta kliknutaKarta)
        {
            sobaIgre.baceneKarte[sobaIgre.brojBacenihKarata] = kliknutaKarta;
            sobaIgre.brojBacenihKarata++;
            sobaIgre.igraci[sobaIgre.igracNaPotezu].mojeKarte.Remove(kliknutaKarta);
        }

        /// <summary>
        /// poziva se automatski pri ulasku u sobu za igru
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="imeSobe"></param>
        public void joinRoom(string userName, string imeSobe)
        {
            var id = Context.ConnectionId;

            Room sobaJoin = sobe.Find(x => x.imeSobe.Equals(imeSobe));//dohvatim sobu u koju igrac zali uci
                                                                      // int a = 0;
                                                                      //if (sobaJoin.brojIgraca == 3)
                                                                      //  a++;
            if(sobaJoin==null || userName == null)
            {
                Clients.Client(id).izbaci();
                return;

            }
                sobaJoin.igraci[sobaJoin.brojIgraca] = new Igrac() { imeKorisnika = userName, connectioId = id };

            int pozicija = sobaJoin.brojIgraca;//mjesto u koje ubacujem
            //slanje podataka o ostalim korisnicima trenutnom igracu ime , pozicija u sobi
            Clients.Client(id).podatciOIgracima(sobaJoin.igraci[(pozicija + 1) % 4], 1, sobaJoin.igraci[(pozicija + 2) % 4], 2, sobaJoin.igraci[(pozicija + 3) % 4], 3);

            //svima osim zadnjem prikljucenom
            for (int i = 0; i < pozicija; i++)
            {
                Clients.Client(sobaJoin.igraci[i].connectioId).onNewUserConnected(userName, (pozicija - i));
            }
            // Clients.Client(sobaJoin.igraci[i].connectioId).onNewUserConnected(userName, (sobaJoin.brojIgrac);
            //ako je soba puna pocne igraca

            sobaJoin.brojIgraca++;//broj igraca i koristim za saviti sljedeceg igraca
            if (sobaJoin.brojIgraca == 4)//zapocni kad je puna soba
            {
                Spil spil = new Spil();
                for (int i = 0; i < sobaJoin.brojIgraca; i++)
                {
                    List<Karta> ruka = spil.getDesteKarat();
                    ruka.Sort();
                    for (int j = 0; j < 10; j++)
                    {
                        ruka.ElementAt(j).xPoz = 50 + j * 140/2;//karte ce se polovicno preklapati
                        ruka.ElementAt(j).yPoz = 500;
                    }
                    sobaJoin.igraci[i].mojeKarte = ruka;
                    Clients.Client(sobaJoin.igraci[i].connectioId).zapocniIgru(ruka);
                }
            }

        }


        //funkcija za chat
        public void sendMessage(string korisnik, string soba, string poruka)
        {

            Room sobaGrupe = sobe.Find(x => x.imeSobe.Equals(soba));//dohvatim sobu u kojoj je igrac
            // send to korisnici u sobi
            for (int i = 0; i < sobaGrupe.brojIgraca; i++)
                Clients.Client(sobaGrupe.igraci[i].connectioId).addNewMessageToPage(korisnik, poruka);

        }

        /// <summary>
        /// pri odlasku iz sobe se pozove
        /// </summary>
        /// <param name="x"> ignoriram </param>
        /// <returns></returns>
        public override System.Threading.Tasks.Task OnDisconnected(bool x)
        {
            var otisao = Context.ConnectionId;
            string userOtisao = null;
            Room sobaOdlaska = getSobaOdlaska(otisao, ref userOtisao);
            //osigurnje i ovaj slucaj se desi kad je igrac otiso tjekom partije i OnDisconnected se pozove od strane igraca koji su ibaceni iz sobe 
            if (sobaOdlaska == null)
                return base.OnDisconnected(x);
            //soba je puna i moramo prekinuti partiju koja je u tjeku i to dojaviti svima osim korisniku koji odlazi
            if (sobaOdlaska.brojIgraca == 4)
            {
                sobaOdlaska.brojIgraca = 0;
                for (int i=0;i<4;i++)
                {
                    if (!sobaOdlaska.igraci[i].connectioId.Equals(otisao))
                    {
                        if (i == 0 || i == 2)
                        {
                            Clients.Client(sobaOdlaska.igraci[i].connectioId).pizda("Tim B pobjeđuje jer je " +userOtisao);
                        }
                        else
                        {
                            Clients.Client(sobaOdlaska.igraci[i].connectioId).pizda("Tim A pobjeđuje jer je "+userOtisao);
                        }
                    }
                    sobaOdlaska.igraci[i] = null;
                }
                return base.OnDisconnected(x);
            }

            //ako soba nije puna onda moram prepraviti pozicije igraca i nove pozicije za stolom javiti igracia**********************

            //micem korisnika iz sobe i javljam im koji je korisnik otisao
            int j = 0; //koristim za pomicanje krisnika na i-j poziciju kad izbacim korisnika iz polja
            for(int i=0; i<sobaOdlaska.brojIgraca-j; i++)
            {
                if (sobaOdlaska.igraci[i].connectioId.Equals(otisao))
                {
                    j = 1;
                }
                sobaOdlaska.igraci[i] = sobaOdlaska.igraci[i+j];
                if(sobaOdlaska.igraci[i] != null)
                     Clients.Client(sobaOdlaska.igraci[i].connectioId).onUserDisconnected(userOtisao);
            }
            sobaOdlaska.brojIgraca--;
            sobaOdlaska.igraci[sobaOdlaska.brojIgraca]=null;

       
            //svima javljmo koje su pozicije oko stola
            for (int i = 0; i < sobaOdlaska.brojIgraca; i++)
            {
                Clients.Client(sobaOdlaska.igraci[i].connectioId).podatciOIgracima(sobaOdlaska.igraci[(i + 1) % 4], 1, sobaOdlaska.igraci[(i + 2) % 4], 2, sobaOdlaska.igraci[(i + 3) % 4], 3);
            }
            return base.OnDisconnected(x);
        }

        //dohvaca sobu u kojoj je korisnik koji odlazi i postavi korisnicko ime onog sto odlazi
        private Room getSobaOdlaska(string connectionId , ref string userOtisao)
        {
            Room sobaOdlaska = null;
            bool nadenaSoba = false;
            foreach(Room soba in sobe)
            {
                for(int i=0; i<soba.brojIgraca; i++)
                {
                    if (connectionId.Equals(soba.igraci[i].connectioId))
                    {
                        userOtisao = soba.igraci[i].imeKorisnika;
                        sobaOdlaska = soba;
                        nadenaSoba = true;
                        break;
                    }
                }
                if (nadenaSoba) break;
            }
            return sobaOdlaska;
        }
    }
}
