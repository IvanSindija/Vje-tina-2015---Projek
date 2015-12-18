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
        public Igrac igrac1 { get; set; }
        public Igrac igrac2 { get; set; }
        public Igrac igrac3 { get; set; }
        public Igrac igrac4 { get; set; }
    }
}
