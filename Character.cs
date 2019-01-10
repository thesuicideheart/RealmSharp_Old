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
        public string Class { get; private set; }
        public string ClassQuestCompleted { get; private set; }
        public int Level { get; private set; }
        public int Fame { get; private set; }
        public int Exp { get; private set; }
        public bool HasBackpack { get; private set; }
        public CharacterEquipment Equipment { get; private set; }
        public CharacterStats Stats { get; private set; }
        
        public Character ( JToken obj )
        {
            Class = obj [ "class" ].ToString( );
            ClassQuestCompleted = obj [ "class_quests_completed" ].ToString( );
            Level = int.Parse( obj [ "level" ].ToString( ) );
            Fame = int.Parse( obj [ "fame" ].ToString( ) );
            Exp = int.Parse( obj [ "xp" ].ToString( ) );
            Equipment = new CharacterEquipment( obj [ "equipment" ] );
            HasBackpack = Equipment.HasBackpack;
            Stats = new CharacterStats( );
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
