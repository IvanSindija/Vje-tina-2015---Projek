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
        public List<Karta> odbaceneKarte = new List<Karta>();

        public int obrada;//obrađuje se logika ai i nesmije se moci bacati karta
        public int bodoviAi { get; set; }
        public int bodoviIgraca { get; set; }
        public int AIjeigrao { get; set; }//za slucaj kad ai bacio prvi 1=aijebacio
        public Karta baceneKartaAI { get; set; }//karte koju je bacio AI
        public int krugIgre { get; set; }//mozda ti bude tribalo

        public SpSoba(string imeKorisnika, string connectioId)
        {
            this.Igrac = new Igrac(imeKorisnika, connectioId);
            krugIgre = 0;
            obrada = 0;
            bodoviAi = 0;
            bodoviIgraca = 0;
            AIjeigrao = 0;
        }

        public Karta aiBacaPrvi()
        {
            Random rnd = new Random();
            int i = rnd.Next()%karteU_RuciAI.Count;
            return karteU_RuciAI.ElementAt(i);
        }

        public Karta aiVracaKartu(Karta bacenaIgrac)
        {
            Karta odgovor;
            Random rnd = new Random();
            List<Karta> mogucnostiZaPovratak = karteU_RuciAI.FindAll(x => x.zvanje.Equals(bacenaIgrac.zvanje));
            if (mogucnostiZaPovratak.Count == 0)
            {
                int i = rnd.Next() % karteU_RuciAI.Count;
                odgovor = karteU_RuciAI.ElementAt(i);
            }
            else
            {
                int i = rnd.Next() % mogucnostiZaPovratak.Count;
                odgovor = mogucnostiZaPovratak.ElementAt(i);
            }

            return odgovor;
        }
    }
}
