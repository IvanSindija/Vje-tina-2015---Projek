using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treseta.Models;

namespace Treseta.Models
{
    class Spil
    {
        private List<Karta> spil = new List<Karta>();
        public Spil()
        {
            spil.Add(new Karta("tricaBastoni", Zvanje.bastoni, 10, 1, "Images/trica_bastoni.jpg"));
            //ovako za sve karte
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
