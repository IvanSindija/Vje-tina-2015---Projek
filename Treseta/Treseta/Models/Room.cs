using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treseta.Models
{
    /// <summary>
    /// Soba za igru ima jedinstveno ime 
    /// namjenjena je za multiplayer
    /// 4 igraca 
    /// </summary>
    public class Room
    {
        public string imeSobe { get; set; }
        public Igrac[] igraci = new Igrac[4];
        public int brojIgraca { get ; set;  }
        public int bodoviTimaA { get; set; }//0,2
        public int bodoviTimaB { get; set; }//1,3
        public int igracNaPotezu { get; set; }//od 0 do 3
        public Karta[] baceneKarte = new Karta[4];//karte koje su bacene na stol
        public int brojBacenihKarata { get; set;}
        public int krugIgre { get; set; }//krug igre od 0 do 10


        public Room()
        {
            bodoviTimaA = 0;
            bodoviTimaB = 0;
            igracNaPotezu = 0;
            brojBacenihKarata = 0;
            krugIgre = 0;
        }
    }
}
