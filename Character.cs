using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class Character
    {
        /// <summary>
        /// The class of the character
        /// </summary>
        public string Class { get; internal set; }
        /// <summary>
        /// How many class quests has been completed(stars unlocked)
        /// </summary>
        public string ClassQuestCompleted { get; internal set; }
        /// <summary>
        /// The place of the character in fame
        /// </summary>
        public string Place { get; internal set; }
        /// <summary>
        /// The level of the character
        /// </summary>
        public int Level { get; internal set; }
        /// <summary>
        /// The current alive fame of the character
        /// </summary>
        public int Fame { get; internal set; }
        /// <summary>
        /// The current alive exp of the character
        /// </summary>
        public int Exp { get; internal set; }
        /// <summary>
        /// Whether the character has a backpack or not
        /// </summary>
        public bool HasBackpack { get; internal set; }
        /// <summary>
        /// The equipment object of the character
        /// </summary>
        public CharacterEquipment Equipment { get; internal set; }
        /// <summary>
        /// The character's stats
        /// </summary>
        //internal CharacterStats Stats { get; internal set; }

        internal Character ( JToken obj )
        {
            Class = obj [ "class" ].ToString( );
            ClassQuestCompleted = obj [ "class_quests_completed" ].ToString( );
            Level = int.Parse( obj [ "level" ].ToString( ) );
            Fame = int.Parse( obj [ "fame" ].ToString( ) );
            Exp = int.Parse( obj [ "xp" ].ToString( ) );
            Equipment = new CharacterEquipment( obj [ "equipment" ] );
            HasBackpack = Equipment.HasBackpack;
            //Stats = new CharacterStats( );
        }

        internal Character ( )
        {

        }

        public override string ToString ( )
        {
            return $"\nCharacter {Class}:\n" +
                $"\tCQC: {ClassQuestCompleted}\n" +
                $"\tLevel: {Level}\n" +
                $"\tFame: {Fame}\n" +
                $"\tExp: {Exp}\n" +
                $"\tEquipment\n" +
                $"\t\tWeapon: {Equipment.Weapon}\n" +
                $"\t\tAbility: {Equipment.Ability}\n" +
                $"\t\tArmor: {Equipment.Armor}\n" +
                $"\t\tRing: {Equipment.Ring}\n" +
                $"\t\tHas Backpack: {HasBackpack}";
        }

    }

}
