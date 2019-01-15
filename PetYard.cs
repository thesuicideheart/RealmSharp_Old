using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class PetYard
    {
        public string PlayerName { get; internal set; }
        public List<Pet> Pets { get; internal set; } = new List<Pet>( );

        public PetYard ( )
        {
        }

        public PetYard ( string player ) => PlayerName = player;

        public void Add ( Pet pet ) => Pets.Add( pet );

    }
}
