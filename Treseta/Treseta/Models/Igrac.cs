using System.Collections.Generic;

namespace Treseta.Models
{
    public class Igrac
    {
        public string imeKorisnika { get; set; }
        public string connectioId { get; set; }
        public List<Karta> mojeKarte { get; set; }
    }
}