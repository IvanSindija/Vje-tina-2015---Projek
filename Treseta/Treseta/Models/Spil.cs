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
            spil.Add(new Karta("tricaBastoni", Zvanje.bastoni, 10, 1, "Images/trica_bastoni.jpg"));
            spil.Add(new Karta("dujaBastoni", Zvanje.bastoni, 9, 1, "Images/duja_bastoni.jpg"));
            spil.Add(new Karta("asBastoni", Zvanje.bastoni, 8, 1, "Images/as_bastoni.jpg"));
            spil.Add(new Karta("kraljBastoni", Zvanje.bastoni, 7, 1, "Images/kralj_bastoni.jpg"));
            spil.Add(new Karta("kavalBastoni", Zvanje.bastoni, 6, 1, "Images/kaval_bastoni.jpg"));
            spil.Add(new Karta("fanatBastoni", Zvanje.bastoni, 5, 1, "Images/fanat_bastoni.jpg"));
            spil.Add(new Karta("sedmicaBastoni", Zvanje.bastoni, 4, 1, "Images/7_bastoni.jpg"));
            spil.Add(new Karta("sesticaBastoni", Zvanje.bastoni, 3, 1, "Images/6_bastoni.jpg"));
            spil.Add(new Karta("peticaBastoni", Zvanje.bastoni, 2, 1, "Images/5_bastoni.jpg"));
            spil.Add(new Karta("cetvorkaBastoni", Zvanje.bastoni, 1, 1, "Images/4_bastoni.jpg"));
            spil.Add(new Karta("tricaSpade", Zvanje.spade, 10, 2, "Images/trica_spada.jpg"));
            spil.Add(new Karta("dujaSpade", Zvanje.spade, 9, 2, "Images/duja_spada.jpg"));
            spil.Add(new Karta("asSpade", Zvanje.spade, 8, 2, "Images/as_spada.jpg"));
            spil.Add(new Karta("kraljSpade", Zvanje.spade, 7, 2, "Images/kralj_spada.jpg"));
            spil.Add(new Karta("kavalSpade", Zvanje.spade, 6, 2, "Images/kaval_spada.jpg"));
            spil.Add(new Karta("fanatSpade", Zvanje.spade, 5, 2, "Images/fanat_spada.jpg"));
            spil.Add(new Karta("sedmicaSpade", Zvanje.spade, 4, 2, "Images/7_spada.jpg"));
            spil.Add(new Karta("sesticaSpade", Zvanje.spade, 3, 2, "Images/6_spada.jpg"));
            spil.Add(new Karta("peticaSpade", Zvanje.spade, 2, 2, "Images/5_spada.jpg"));
            spil.Add(new Karta("cetvorkaSpade", Zvanje.spade, 1, 2, "Images/4_spada.jpg"));
            spil.Add(new Karta("tricaKopi", Zvanje.kupi, 10, 3, "Images/trica_kope.jpg"));
            spil.Add(new Karta("dujaKopi", Zvanje.kupi, 9, 3, "Images/duja_kope.jpg"));
            spil.Add(new Karta("asKopi", Zvanje.kupi, 8, 3, "Images/as_kope.jpg"));
            spil.Add(new Karta("kraljKopi", Zvanje.kupi, 7, 3, "Images/kralj_kope.jpg"));
            spil.Add(new Karta("kavalKopi", Zvanje.kupi, 6, 3, "Images/kaval_kope.jpg"));
            spil.Add(new Karta("fanatKopi", Zvanje.kupi, 5, 3, "Images/fanat_kope.jpg"));
            spil.Add(new Karta("sedmicaKopi", Zvanje.kupi, 4, 3, "Images/7_kope.jpg"));
            spil.Add(new Karta("sesticaKopi", Zvanje.kupi, 3, 3, "Images/6_kope.jpg"));
            spil.Add(new Karta("peticaKopi", Zvanje.kupi, 2, 3, "Images/5_kope.jpg"));
            spil.Add(new Karta("cetvorkaKopi", Zvanje.kupi, 1, 3, "Images/4_kope.jpg"));
            spil.Add(new Karta("tricaDinari", Zvanje.dinari, 10, 4, "Images/trica_dinari.jpg"));
            spil.Add(new Karta("dujaDinari", Zvanje.dinari, 9, 4, "Images/duja_dinari.jpg"));
            spil.Add(new Karta("asDinari", Zvanje.dinari, 8, 4, "Images/as_dinari.jpg"));
            spil.Add(new Karta("kraljDinari", Zvanje.dinari, 7, 4, "Images/kralj_dinari.jpg"));
            spil.Add(new Karta("kavalDinari", Zvanje.dinari, 6, 4, "Images/kaval_dinari.jpg"));
            spil.Add(new Karta("fanatDinari", Zvanje.dinari, 5, 4, "Images/fanat_dinari.jpg"));
            spil.Add(new Karta("sedmicaDinari", Zvanje.dinari, 4, 4, "Images/7_dinari.jpg"));
            spil.Add(new Karta("sesticaDinari", Zvanje.dinari, 3, 4, "Images/6_dinari.jpg"));
            spil.Add(new Karta("peticaDinari", Zvanje.dinari, 2, 4, "Images/5_dinari.jpg"));
            spil.Add(new Karta("cetvorkaDinari", Zvanje.dinari, 1, 4, "Images/4_dinari.jpg"));
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

            return ruka;// bozja
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
