using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    /// <summary>
    /// The data that defines the character equipment
    /// </summary>
    public class CharacterEquipment
    {

        /// <summary>
        /// The name of the weapon.
        /// </summary>
        public string Weapon { get; internal set; }

        /// <summary>
        /// The name of the ability
        /// </summary>
        public string Ability { get; internal set; }

        /// <summary>
        /// The name of the Armor
        /// </summary>
        public string Armor { get; internal set; }

        /// <summary>
        /// The name of the ring
        /// </summary>
        public string Ring { get; internal set; }

        /// <summary>
        /// Whether the character has a backpack or not
        /// </summary>
        public bool HasBackpack { get; internal set; }

        internal CharacterEquipment ( JToken obj )
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

        internal CharacterEquipment ( )
        {

        }

        public override string ToString ( )
        {
            return 
                $"Weapon: {Weapon}\n" +
                $"Ability: {Ability}\n" +
                $"Armor: {Armor}\n" +
                $"Ring: {Ring}";
        }

    }
}
