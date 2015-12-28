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
    }
}
