using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Treseta.Models;

namespace Treseta
{
    public class SpHub : Hub
    {
        public void JoinRoom(string imeKorisnika)
        {
            List<SpSoba> spSobe = ListaSPsoba.dohvatiListuSoba();
            //SpSoba sobaIgraca = spSobe.Find(x => x.Igrac.connectioId);
            var connectionId = Context.ConnectionId;
            SpSoba novaSoba = new SpSoba(imeKorisnika, connectionId); //soba u kojoj je igrac
            Spil spil = new Spil();
            //dajemo karte igracu ******************************************
            novaSoba.Igrac.mojeKarte = spil.getDesteKarat();
            //****************************************************************
            sortRuku(novaSoba);
            novaSoba.karteU_RuciAI = spil.getDesteKarat();//dali smo karte AI
            novaSoba.spilIgre = spil;
            spSobe.Add(novaSoba);

            Clients.Client(connectionId).pocetakIgre(novaSoba.Igrac.mojeKarte); //igracu saljem njegove karte da ih iscrta
        }

        private void sortRuku(SpSoba sobaIgre)
        {
            sobaIgre.Igrac.mojeKarte.Sort();//poslozimo ih da budu u redosljedu u ruci
            for (int j = 0; j < sobaIgre.Igrac.mojeKarte.Count; j++)
            {
                sobaIgre.Igrac.mojeKarte.ElementAt(j).xPoz = 50 + j * 140 / 2;
                sobaIgre.Igrac.mojeKarte.ElementAt(j).yPoz = 500;
            }

        }

        //odredi koja je bacena karta iz kordinate klika
        private Karta getKliknutaKarta(SpSoba sobaIgre, int mouseX, int mouseY)
        {
            for (int i = sobaIgre.Igrac.mojeKarte.Count - 1; i >= 0; i--)
            {
                Karta temp = sobaIgre.Igrac.mojeKarte.ElementAt(i);//karta za provjeru ide od najvise prema najnizoj
                if (temp.xPoz < mouseX && (temp.xPoz + temp.sirina) > mouseX && temp.yPoz < mouseY && temp.yPoz + temp.visina > mouseY)//kliknuta je ova karta
                {
                    return temp;
                }
            }
            return null;
        }

        //bacanje karte 
        private void baciKartu(SpSoba sobaIgre, Karta igracevoBacanje, int istoZvanje, string connectionId)
        {
            sobaIgre.Igrac.mojeKarte.Remove(igracevoBacanje);
            Karta jacaKarta = sobaIgre.baceneKartaAI.tkoJeJaci(igracevoBacanje);
            Karta kartuIzvucenuAI = sobaIgre.spilIgre.getKarta();
            Karta kataIzvucenaIgrac = sobaIgre.spilIgre.getKarta();
            sobaIgre.odbaceneKarte.Add(igracevoBacanje);
            sobaIgre.odbaceneKarte.Add(sobaIgre.baceneKartaAI);
            int bodovi = sobaIgre.baceneKartaAI.bodovi + igracevoBacanje.bodovi;
            if (jacaKarta.Equals(sobaIgre.baceneKartaAI) || istoZvanje == 1)//1 odgovorio je krivim zvanjem
            {
                sobaIgre.AIjeigrao = 1;
                sobaIgre.bodoviAi += bodovi;
            }
            if (jacaKarta.Equals(igracevoBacanje))
            {
                sobaIgre.bodoviIgraca += bodovi;
            }
            Clients.Client(connectionId).odgovor(sobaIgre.Igrac.mojeKarte, igracevoBacanje, kartuIzvucenuAI, kataIzvucenaIgrac);
            if (kataIzvucenaIgrac != null)
                sobaIgre.Igrac.mojeKarte.Add(kataIzvucenaIgrac);
            sortRuku(sobaIgre);
            if (kartuIzvucenuAI != null)
                sobaIgre.karteU_RuciAI.Add(kartuIzvucenuAI);
        }

        public void cardKlik(int x, int y)
        {
            var connectionId = Context.ConnectionId;
            SpSoba sobaIgre = ListaSPsoba.dohvatiListuSoba().Find(t => t.Igrac.connectioId.Equals(connectionId));//soba u kojoj se igra
            if (sobaIgre.obrada == 1)//obraduje se logika
                return;

            sobaIgre.obrada = 1;
            Karta kliknutaKarta = getKliknutaKarta(sobaIgre, x, y);
            if (kliknutaKarta == null)
            {
                sobaIgre.obrada = 0;
                return;
            }
            //igrac odgovara na bacanje od ai
            if (sobaIgre.AIjeigrao == 1)
            {
                sobaIgre.AIjeigrao = 0;
                if (sobaIgre.baceneKartaAI.zvanje.Equals(kliknutaKarta.zvanje))
                {
                    baciKartu(sobaIgre, kliknutaKarta, 0, connectionId);
                }
                else
                {
                    int brojKarata = sobaIgre.Igrac.mojeKarte.Count(z => z.zvanje.Equals(sobaIgre.baceneKartaAI.zvanje));
                    if (brojKarata > 0)
                    {
                        Clients.Client(connectionId).upozorenje("Moras odgovarati na zvanje");
                        sobaIgre.obrada = 0;
                        return;
                    }
                    baciKartu(sobaIgre, kliknutaKarta, 1, connectionId);
                }
                System.Threading.Thread.Sleep(10000);
                sobaIgre.obrada = 0;
            }
            else//igrac prvi baca smije baciti sto god hoce nije potrebno paziti zvanje
            {

                Karta aiVraca = sobaIgre.aiVracaKartu(kliknutaKarta);//ai odgovara na bacenu kartu 
                sobaIgre.Igrac.mojeKarte.Remove(kliknutaKarta);//micemo iz ruke kliknutu kartu
                sobaIgre.karteU_RuciAI.Remove(aiVraca);
                Karta jacaKarta = kliknutaKarta.tkoJeJaci(aiVraca);
                Karta kartuIzvucenuAI = sobaIgre.spilIgre.getKarta();
                Karta kataIzvucenaIgrac = sobaIgre.spilIgre.getKarta();
                sobaIgre.odbaceneKarte.Add(kliknutaKarta);
                sobaIgre.odbaceneKarte.Add(aiVraca);
                int bodovi = aiVraca.bodovi + kliknutaKarta.bodovi;
                if (jacaKarta.Equals(aiVraca))
                {
                    sobaIgre.AIjeigrao = 1;
                    sobaIgre.bodoviAi += bodovi;
                }
                if (jacaKarta.Equals(kliknutaKarta))
                {
                    sobaIgre.bodoviIgraca += bodovi;
                }
                Clients.Client(connectionId).noviKrug(sobaIgre.Igrac.mojeKarte, kliknutaKarta, aiVraca, kartuIzvucenuAI, kataIzvucenaIgrac);
                System.Threading.Thread.Sleep(10000);
                if (kataIzvucenaIgrac != null)
                    sobaIgre.Igrac.mojeKarte.Add(kataIzvucenaIgrac);
                sortRuku(sobaIgre);
                if (kartuIzvucenuAI != null)
                    sobaIgre.karteU_RuciAI.Add(kartuIzvucenuAI);
            }
            Clients.Client(connectionId).novaRuka(sobaIgre.Igrac.mojeKarte);
            if (sobaIgre.Igrac.mojeKarte.Count == 0)
            {
                Clients.Client(connectionId).krajIgre("AI bodovi" + (sobaIgre.bodoviAi / 3).ToString() + " tvoji bodovi" + (sobaIgre.bodoviIgraca / 3).ToString());
            }

            if (sobaIgre.AIjeigrao == 1)
            {
                sobaIgre.baceneKartaAI = sobaIgre.aiBacaPrvi();
                sobaIgre.karteU_RuciAI.Remove(sobaIgre.baceneKartaAI);//bacio sam kartu i maknuo je iz ruke ai-ja
                Clients.Client(connectionId).aiIgra(sobaIgre.baceneKartaAI);
            }
            sobaIgre.obrada = 0;

        }


        /// <summary>
        /// pozove se kad igrac izađe iz sobe za igru
        /// moze izaci tako da se odspoji s interneta ili klikne return na pretrazivacu
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public override System.Threading.Tasks.Task OnDisconnected(bool x)
        {
            var otisao = Context.ConnectionId;

            List<SpSoba> sobe = ListaSPsoba.dohvatiListuSoba();
            SpSoba sobaOdlaska = sobe.Find(y => y.Igrac.connectioId.Equals(otisao));
            //osigurnje  
            if (sobaOdlaska == null)
                return base.OnDisconnected(x);

            sobe.Remove(sobaOdlaska);//maknem sobu iz liste da ne koristi memoriju bez razloga

            return base.OnDisconnected(x);

        }
    }
}