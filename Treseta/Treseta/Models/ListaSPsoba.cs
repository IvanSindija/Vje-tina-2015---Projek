using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treseta.Models
{
    class ListaSPsoba
    {
        private static List<SpSoba> sobe; //lista svih dostupnih soba za igru
        private ListaSPsoba()
        {
            sobe = new List<SpSoba>();
        }
        public static List<SpSoba> dohvatiListuSoba()
        {
            if (sobe == null)
            {
                new ListaSPsoba();
            }
            return sobe;
        }
    }
}
