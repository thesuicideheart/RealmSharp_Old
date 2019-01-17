using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class GraveyardCharacter
    {
        /// <summary>
        /// The entity that killed the character
        /// </summary>
        public string Killer { get; internal set; }
        
        /// <summary>
        /// The class of the character
        /// </summary>
        public string Class { get; internal set; }
        
        /// <summary>
        /// The date of the death
        /// </summary>
        public string DeathDate { get; internal set; }
        
        /// <summary>
        /// The amount of exp the character had
        /// </summary>
        public string Exp { get; internal set; }
        
        /// <summary>
        /// The level of the character
        /// </summary>
        public int Level { get; internal set; }
        
        /// <summary>
        /// The base fame of the character
        /// </summary>
        public int BaseFame { get; internal set; }
        
        /// <summary>
        /// How much fame the character got upon death
        /// </summary>
        public int TotalFame { get; internal set; }
        
        /// <summary>
        /// The amount of stats maxed
        /// </summary>
        public int MaxedStats { get; internal set; }

        /// <summary>
        /// The equipment of the character
        /// </summary>
        public CharacterEquipment Equipment { get; internal set; }
        
    }
}
