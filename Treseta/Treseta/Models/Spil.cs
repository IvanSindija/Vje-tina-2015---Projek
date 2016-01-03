using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treseta.Models;

namespace Treseta.Models
{
    class Spil //mac grofe jedan
    {
        private List<Karta> spil = new List<Karta>();
        public Spil()
        {
            spil.Add(new Karta("tricaBastoni", Zvanje.bastoni, 10, 1, "/Images/trica_bastoni.jpg"));
            spil.Add(new Karta("dujaBastoni", Zvanje.bastoni, 9, 1, "/Images/duja_bastoni.jpg"));
            spil.Add(new Karta("asBastoni", Zvanje.bastoni, 8, 3, "/Images/as_bastoni.jpg"));
            spil.Add(new Karta("kraljBastoni", Zvanje.bastoni, 7, 1, "/Images/kralj_bastoni.jpg"));
            spil.Add(new Karta("kavalBastoni", Zvanje.bastoni, 6, 1, "/Images/kaval_bastoni.jpg"));
            spil.Add(new Karta("fanatBastoni", Zvanje.bastoni, 5, 1, "/Images/fanat_bastoni.jpg"));
            spil.Add(new Karta("sedmicaBastoni", Zvanje.bastoni, 4, 0, "/Images/7_bastoni.jpg"));
            spil.Add(new Karta("sesticaBastoni", Zvanje.bastoni, 3, 0, "/Images/6_bastoni.jpg"));
            spil.Add(new Karta("peticaBastoni", Zvanje.bastoni, 2, 0, "/Images/5_bastoni.jpg"));
            spil.Add(new Karta("cetvorkaBastoni", Zvanje.bastoni, 1, 0, "/Images/4_bastoni.jpg"));
            spil.Add(new Karta("tricaSpade", Zvanje.spade, 10, 1, "/Images/trica_spada.jpg"));
            spil.Add(new Karta("dujaSpade", Zvanje.spade, 9, 1, "/Images/duja_spada.jpg"));
            spil.Add(new Karta("asSpade", Zvanje.spade, 8, 3, "/Images/as_spada.jpg"));
            spil.Add(new Karta("kraljSpade", Zvanje.spade, 7, 1, "/Images/kralj_spada.jpg"));
            spil.Add(new Karta("kavalSpade", Zvanje.spade, 6, 1, "/Images/kaval_spada.jpg"));
            spil.Add(new Karta("fanatSpade", Zvanje.spade, 5, 1, "/Images/fanat_spada.jpg"));
            spil.Add(new Karta("sedmicaSpade", Zvanje.spade, 4, 0, "/Images/7_spada.jpg"));
            spil.Add(new Karta("sesticaSpade", Zvanje.spade, 3, 0, "/Images/6_spada.jpg"));
            spil.Add(new Karta("peticaSpade", Zvanje.spade, 2, 0, "/Images/5_spada.jpg"));
            spil.Add(new Karta("cetvorkaSpade", Zvanje.spade, 1, 0, "/Images/4_spada.jpg"));
            spil.Add(new Karta("tricaKopi", Zvanje.kupe, 10, 1, "/Images/trica_kope.jpg"));
            spil.Add(new Karta("dujaKopi", Zvanje.kupe, 9, 1, "/Images/duja_kope.jpg"));
            spil.Add(new Karta("asKopi", Zvanje.kupe, 8, 3, "/Images/as_kope.jpg"));
            spil.Add(new Karta("kraljKopi", Zvanje.kupe, 7, 1, "/Images/kralj_kope.jpg"));
            spil.Add(new Karta("kavalKopi", Zvanje.kupe, 6, 1, "/Images/kaval_kope.jpg"));
            spil.Add(new Karta("fanatKopi", Zvanje.kupe, 5, 1, "/Images/fanat_kope.jpg"));
            spil.Add(new Karta("sedmicaKopi", Zvanje.kupe, 4, 0, "/Images/7_kope.jpg"));
            spil.Add(new Karta("sesticaKopi", Zvanje.kupe, 3, 0, "/Images/6_kope.jpg"));
            spil.Add(new Karta("peticaKopi", Zvanje.kupe, 2, 0, "/Images/5_kope.jpg"));
            spil.Add(new Karta("cetvorkaKopi", Zvanje.kupe, 1, 0, "/Images/4_kope.jpg"));
            spil.Add(new Karta("tricaDinari", Zvanje.dinari, 10, 1, "/Images/trica_dinari.jpg"));
            spil.Add(new Karta("dujaDinari", Zvanje.dinari, 9, 1, "/Images/duja_dinari.jpg"));
            spil.Add(new Karta("asDinari", Zvanje.dinari, 8, 3, "/Images/as_dinari.jpg"));
            spil.Add(new Karta("kraljDinari", Zvanje.dinari, 7, 1, "/Images/kralj_dinari.jpg"));
            spil.Add(new Karta("kavalDinari", Zvanje.dinari, 6, 1, "/Images/kaval_dinari.jpg"));
            spil.Add(new Karta("fanatDinari", Zvanje.dinari, 5, 1, "/Images/fanat_dinari.jpg"));
            spil.Add(new Karta("sedmicaDinari", Zvanje.dinari, 4, 0, "/Images/7_dinari.jpg"));
            spil.Add(new Karta("sesticaDinari", Zvanje.dinari, 3, 0, "/Images/6_dinari.jpg"));
            spil.Add(new Karta("peticaDinari", Zvanje.dinari, 2, 0, "/Images/5_dinari.jpg"));
            spil.Add(new Karta("cetvorkaDinari", Zvanje.dinari, 1, 0, "/Images/4_dinari.jpg"));
        }
        /// <summary>
        /// funkcija za dohvat karata za igraca
        /// </summary>
        /// <returns> vrati listu Kartu </returns>
        public List<Karta> getDesteKarat()
        {
            List<Karta> ruka = new List<Karta>();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int indexKarte = rnd.Next(spil.Count);
                Karta karta = spil[indexKarte];
                spil.RemoveAt(indexKarte);
                ruka.Add(karta);
            }

            return ruka;
        }

        /// <summary>
        /// za dohvat jedne karte u igri s 2 igraca
        /// </summary>
        /// <returns>
        /// vrati Kartu</returns>
        public Karta getKarta()
        {
            Random rnd = new Random();
            int indexKarte = rnd.Next(spil.Count);
            Karta karta = spil[indexKarte];
            spil.RemoveAt(indexKarte);
            return karta;
        }
    }
}
