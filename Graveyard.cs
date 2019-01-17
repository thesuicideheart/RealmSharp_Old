using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class Graveyard
    {

        /// <summary>
        /// The list of dead characters
        /// </summary>
        public List<GraveyardCharacter> Deaths { get; internal set; } = new List<GraveyardCharacter>( );

        /// <summary>
        /// The owner of the graveyard
        /// </summary>
        public string Owner { get; internal set; }

        internal Graveyard ( string owner ) => Owner = owner;

        internal void Add ( GraveyardCharacter item ) => Deaths.Add( item );

    }
}
