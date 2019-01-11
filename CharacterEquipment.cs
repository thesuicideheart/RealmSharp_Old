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
            List<string> equip = new List<string>( );
            for ( int i = 0 ; i < obj.Count( ) ; i++ )
            {
                equip.Add( obj [ i ].ToString( ) );
            }

            Weapon = equip [ 0 ];
            Ability = equip [ 1 ];
            Armor = equip [ 2 ];
            Ring = equip [ 3 ];
            if(equip.Count() >= 5 )
            {
                HasBackpack = equip[ 4 ].ToLower( ) == "backpack";

            }
        }

    }
}
