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
            sobe.Add(new Room() { imeSobe = "prva soba", brojIgraca = 0 });
            sobe.Add(new Room() { imeSobe = "druga soba", brojIgraca = 0 });
            sobe.Add(new Room() { imeSobe = "treća soba", brojIgraca = 0 });
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
