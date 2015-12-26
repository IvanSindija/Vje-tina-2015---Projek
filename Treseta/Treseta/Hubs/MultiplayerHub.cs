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
        List<Room> sobe = SingletonListaSoba.dohvatiListuSoba();
        public void Connect(string userName, string imeSobe)
        {
            var id = Context.ConnectionId;

            bool igracJeUsobi = false;
            foreach (Room soba in sobe)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (soba.igraci[i].connectioId == id)
                    {
                        igracJeUsobi = true;
                    }
                }
            }
            if (!igracJeUsobi)
            {
                Room sobaJoin = sobe.Find(x => x.imeSobe == imeSobe);//dohvatim sobu u koju igrac zali uci
                sobaJoin.brojIgraca++;
                sobaJoin.igraci[sobaJoin.brojIgraca] = new Igrac() { imeKorisnika = userName };
            }

            // send to all except caller client
            Clients.AllExcept(id).onNewUserConnected(id, userName);

        }



        public void SendMessage(string korisnik, string soba, string poruka)
        {

            Room sobaJoin = sobe.Find(x => x.imeSobe == soba);//dohvatim sobu u kojoj je igrac
            //for kroz igrace u sobi za poruku posalti
            // send to korisnici u sobi
            Clients.Client().sendMessage(korisnik, poruka);

            // send to caller user
            Clients.Caller.sendMessage(korisnik, poruka);

        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }

            return base.OnDisconnected();
        }
    }
}
