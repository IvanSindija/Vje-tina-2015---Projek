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

        public void joinRoom(string userName, string imeSobe)
        {
            var id = Context.ConnectionId;

            Room sobaJoin = sobe.Find(x => x.imeSobe.Equals(imeSobe));//dohvatim sobu u koju igrac zali uci


            sobaJoin.igraci[sobaJoin.brojIgraca] = new Igrac() { imeKorisnika = userName, connectioId = id };
            int pozicija = sobaJoin.brojIgraca;//mjesto u koje ubacujem
            //slanje podataka o ostalim korisnicima trenutnom igracu ime , pozicija u sobi
            Clients.Client(id).podatciOIgracima(sobaJoin.igraci[(pozicija + 1) % 4], 1, sobaJoin.igraci[(pozicija + 2) % 4], 2, sobaJoin.igraci[(pozicija + 3) % 4], 3);

            //svima osim zadnjem prikljucenom
            for (int i = 0; i < sobaJoin.brojIgraca; i++)
                Clients.Client(sobaJoin.igraci[i].connectioId).onNewUserConnected(userName, (sobaJoin.brojIgraca).ToString());
            //ako je soba puna pocne igraca

            sobaJoin.brojIgraca++;//broj igraca i koristim za saviti sljedeceg igraca
            if (true)//zapocni kad je puna soba
            {
                Spil spil = new Spil();
                for (int i = 0; i < sobaJoin.brojIgraca; i++)
                {
                    List<Karta> ruka = spil.getDesteKarat();
                    ruka.Sort();
                    for(int j=0; j<10; j++)
                    {
                        ruka.ElementAt(j).xPoz = 50 + j*90;
                        ruka.ElementAt(j).sirina = 80;
                        ruka.ElementAt(j).visina = 100;
                    }
                    Clients.Client(sobaJoin.igraci[i].connectioId).zapocniIgru(ruka);
                }
            }

        }



        public void sendMessage(string korisnik, string soba, string poruka)
        {

            Room sobaGrupe = sobe.Find(x => x.imeSobe.Equals(soba));//dohvatim sobu u kojoj je igrac
            // send to korisnici u sobi
            for (int i = 0; i < sobaGrupe.brojIgraca; i++)
                Clients.Client(sobaGrupe.igraci[i].connectioId).addNewMessageToPage(korisnik, poruka);

        }

        public override System.Threading.Tasks.Task OnDisconnected(bool x)
        {
            var otisao = Context.ConnectionId;
            Room sobaOdlaska = null;
            string userName = null;
            foreach (Room soba in sobe)
            {
                int j = 0;
                for (int i = 0; i < soba.brojIgraca; i++)
                {
                    if (soba.igraci[i].connectioId.Equals(otisao))
                    {
                        sobaOdlaska = soba;//dohvatim sobu iz koje odlazi
                        userName = sobaOdlaska.igraci[i].imeKorisnika;
                        if (sobaOdlaska.brojIgraca == 4)
                            for (int e = 0; e < 4; e++)
                            {
                                Clients.Client(sobaOdlaska.igraci[e].connectioId).pizda(userName);
                                sobaOdlaska.igraci[e] = null;
                                sobaOdlaska.brojIgraca = 0;
                            }
                        soba.brojIgraca--;
                        j++;
                    }
                    soba.igraci[i] = soba.igraci[i + j];
                }
            }

            // send to all except caller client
            for (int i = 0; i < sobaOdlaska.brojIgraca; i++)
                Clients.Client(sobaOdlaska.igraci[i].connectioId).onUserDisconnected(userName);


            return base.OnDisconnected(x);
        }
    }
}
