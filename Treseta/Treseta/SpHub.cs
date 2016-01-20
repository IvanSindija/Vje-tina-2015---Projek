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
            novaSoba.Igrac.mojeKarte.Sort();//poslozimo ih da budu u redosljedu u ruci
            for (int j = 0; j < 10; j++)
            {
                novaSoba.Igrac.mojeKarte.ElementAt(j).xPoz = 80 + j * 90;//određujemo im kordinatu u ruci y=590
            }
            //****************************************************************
            novaSoba.karteU_RuciAI = spil.getDesteKarat();//dali smo karte AI
            novaSoba.spilIgre = spil;
            spSobe.Add(novaSoba);

            Clients.Client(connectionId).pocetakIgre(novaSoba.Igrac.mojeKarte); //igracu saljem njegove karte da ih iscrta
        }


        //za Babana implementirati !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //imas nesto slicno u MultiplayerHub funkcija se zove isto cardClick pa ako nesto neznas tamo mos pogledati
        public void cardKlik(int x , int y)
        {
            var connectionId = Context.ConnectionId;
            SpSoba sobaIgre = ListaSPsoba.dohvatiListuSoba().Find(t=> t.Igrac.connectioId.Equals(connectionId));//soba u kojoj se igra
            //dobio si kordinatu klika od igraca
            //ako je AI prvi na potezu goTo velikaSlovaAi
            //provjeris jeli kliknuta karta 
            // provjeri jeli igrac smije baciti tu kartu ako nesmije posaljes mu upozorenje
            Clients.Client(connectionId).upozoenje("Nesmijes tu kartu igrati");
            //odredi koju kartu baca ai pomocu SpSoba.aiVraca kartu tu funkciju moras implementirati
            //makni iz ruke igraca i ai-a kartu koju su bacili
            //ovime zavrsava određivanje koju kartu baca igrac i koju baca AI*****************************************************
            //odredi tko je bacio jacu kartu karta ti ima lokalnu varjablu sanga i zvanje
            //dodaj bodove onome tko je digao to bacanje
            //odredi tko igra prvi sljedeci krug imas tu varjablu u sobi igre
            //ovime zavrsava određivanje pobjednika kruga i dodjela bodova*******************************************************
            //dohvati 1 kartu za igraca i 1 za ai iz spila postoji ti vec funkcija za to
            //dodaj tu kartu sto su izvukli u ruku im onda sortiraj ruku i unesi im opet kordinate
            //posalji novu rukuIgraca, kartuBacenuOdIgraca, kartuBacenuOdAI, kartuIzvucenuAI, kataIzvucenaIgrac
            // Clients.Client(connectionId).noviKrug(rukuIgraca, kartuBacenuOdIgraca, kartuBacenuOdAI, kartuIzvucenuAI, kataIzvucenaIgrac);
            //s ovime zavrsava sljanje kresi podataka za iscrtavanje*************************************************************
            System.Threading.Thread.Sleep(5000);//zaustavim dretvu 5 sec
            //ako je sada ai i potezu odredi koju ce kartu ai baciti i posaljes to i makni mu tu kartu iz ruke
            //ako ai nje na potezu samo return; napisi i ovo dalje se nece izvoditi
            //Clients.Client(connectionId).aiIgra(karta);
            //VELIKASLOVAAI!!!!!!!!!!!!!!!!!!!
            //tu si ako je ai bio prvi na potezu i igrac odgovara klikom
            ////provjeris jeli kliknuta karta 
            // provjeri jeli igrac smije baciti tu kartu ako nesmije posaljes mu upozorenje
            Clients.Client(connectionId).upozoenje("Nesmijes tu kartu igrati");
            //makni iz ruke igraca kartu koju je bacio
            //bla bla nove karte u ruku bla bla ko igra prvi bla bla
            //Clients.Client(connectionId).odgovor(rukuIgraca, kartuBacenuOdIgraca,kartuIzvucenuAI, kataIzvucenaIgrac);
            //i mislim da je to to
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

            sobe.Remove(sobaOdlaska);//maknem sobu iz liste da nebude u memoriji bezveze

            return base.OnDisconnected(x);

        }
    }
}