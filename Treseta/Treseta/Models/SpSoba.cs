using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treseta.Models
{
    class SpSoba
    {
        public Igrac Igrac { get; set; }
        public List<Karta> karteU_RuciAI = new List<Karta>();
        public Spil spilIgre;

        public int bodoviAi { get; set; }
        public int bodoviIgraca { get; set; }
        public int igracNaPotezu { get; set; }//0 ai , 1 igrac
        public List<Karta> baceneKarte = new List<Karta>();//karte koje su bacene

        public int krugIgre { get; set; }//mozda ti bude tribalo

        public SpSoba(string imeKorisnika, string connectioId)
        {
            this.Igrac = new Igrac(imeKorisnika, connectioId);
            krugIgre = 0;
            bodoviAi = 0;
            bodoviIgraca = 0;
            igracNaPotezu = 0;
        }

        public Karta aiVracaKartu()
        {
            return null;
        }
    }
}
