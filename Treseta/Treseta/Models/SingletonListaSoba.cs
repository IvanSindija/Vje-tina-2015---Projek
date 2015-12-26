using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treseta.Models
{
    class SingletonListaSoba
    {
        private static List<Room> sobe; //lista svih dostupnih soba za igru
        private SingletonListaSoba()
        {
            sobe = new List<Room>();
        }
        public static List<Room> dohvatiListuSoba()
        {
            if (sobe == null)
            {
                new SingletonListaSoba();
            }
            return sobe;
        }
    }
}
