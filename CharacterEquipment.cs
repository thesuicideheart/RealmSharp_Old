using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class CharacterEquipment
    {
        public string Weapon { get; private set; }
        public string Ability { get; private set; }
        public string Armor { get; private set; }
        public string Ring { get; private set; }
        public bool HasBackpack { get; private set; }

        public CharacterEquipment ( JToken obj )
        {
            Weapon = obj [ 0 ].ToString( );
            Ability = obj [ 1 ].ToString( );
            Armor = obj [ 2 ].ToString( );
            Ring = obj [ 3 ].ToString( );
            //TODO: Implement backpack thingy?
            //HasBackpack = obj [ 4 ].ToString( ).ToLower( ) == "backpack";
        }

    }
}
