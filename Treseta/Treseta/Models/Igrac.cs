using System.Collections.Generic;

namespace Treseta.Models
{
    public class Igrac
    {
        public string connectioId { get; set; }
        public string imeKorisnika { get; set; }
        public List<Karta> mojeKarte { get; set; }

        public Igrac(string imeKorisnika, string connectioId)
        {
            this.imeKorisnika = imeKorisnika;
            this.connectioId = connectioId;
        }

        public Igrac()
        {
        }
    }
}