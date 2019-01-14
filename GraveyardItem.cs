using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class GraveyardItem
    {
        public string Killer { get; internal set; }
        public string Class { get; internal set; }
        public string DeathDate { get; internal set; }
        public string Exp { get; internal set; }
        public int Level { get; internal set; }
        public int BaseFame { get; internal set; }
        public int TotalFame { get; internal set; }
        public int MaxedStats { get; internal set; }

        public CharacterEquipment Equipment { get; internal set; }
        
    }
}
