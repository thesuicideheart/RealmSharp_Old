using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{

    /// <summary>
    /// Petyard class. contains playername and list of pets
    /// </summary>
    public class PetYard
    {
        /// <summary>
        /// Name of the petyard owner
        /// </summary>
        public string PlayerName { get; internal set; }

        /// <summary>
        /// List of pets
        /// </summary>
        public List<Pet> Pets { get; internal set; } = new List<Pet>( );

        internal PetYard ( )
        {
        }

        internal PetYard ( string player ) => PlayerName = player;

        internal void Add ( Pet pet ) => Pets.Add( pet );

    }
}
