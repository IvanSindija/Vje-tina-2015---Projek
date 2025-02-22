﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treseta.Models
{
    public enum Zvanje : int { bastoni = 1, spade = 2, kupe = 3, dinari = 4 }

    public class Karta : IComparable
    {
        public string ime { get; set; }
        public Zvanje zvanje { get; set; }
        public int snaga { get; set; }//trica = 10 cetvorka = 1
        public int bodovi { get; set; }//u belama as = 3
        public string pathSlike { get; set; } //put do slike
        public int xPoz { get; set; }
        public int yPoz { get; set; }
        public int sirina { get; set; }
        public int visina { get; set; }
        public Karta(string ime, Zvanje zvanje, int snaga, int bodovi, string pathSlike)
        {
            this.ime = ime;
            this.zvanje = zvanje;
            this.snaga = snaga;
            this.bodovi = bodovi;
            this.pathSlike = pathSlike;
            sirina = 140;
            visina = 180;
        }


        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return ((Karta) obj).ime.Equals(this.ime);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.ime.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Karta karta2 = (Karta)obj;
            if (karta2.zvanje.Equals(zvanje))
                return snaga.CompareTo(karta2.snaga);
            return zvanje.CompareTo(karta2.zvanje);
        }

        internal Karta tkoJeJaci(Karta karta)
        {
            if (this.zvanje != karta.zvanje)
                return this;
            if (karta.snaga > this.snaga)
                return karta;
            return this;
        }
    }
}
