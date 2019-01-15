using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class Pet
    {
        public string Name { get; internal set; }
        public string PetSkin { get; internal set; }
        public string Rarity { get; internal set; }
        public string Family { get; internal set; }
        public string Place { get; internal set; }
        public string MaxAbilityLevel { get; internal set; }

        public PetStats Stats { get; internal set; }


        public override string ToString ( )
        {
            return 
                $"Name: {Name}\n" +
                $"Pet Skin: {PetSkin}\n" +
                $"Rarity: {Rarity}\n" +
                $"Family: {Family}\n" +
                $"Place: {Place}\n" +
                $"Max level: {MaxAbilityLevel}\n" +
                $"Stats: {Stats}\n";
        }

    }

    public class PetStats
    {
        public string Ability1 { get; internal set; }
        public int Ability1Level { get; internal set; }
        //public int Ability1Points { get; internal set; }
        //public int Ability1FeedpowerToNextLevel { get; internal set; }
        //public int Ability1FeedpowerToMaxLevel { get; internal set; }


        public string Ability2 { get; internal set; }
        public int Ability2Level { get; internal set; }
        //public int Ability2Points { get; internal set; }
        //public int Ability2FeedpowerToNextLevel { get; internal set; }
        //public int Ability2FeedpowerToMaxLevel { get; internal set; }


        public string Ability3 { get; internal set; }
        public int Ability3Level { get; internal set; }
        //public int Ability3Points { get; internal set; }
        //public int Ability3FeedpowerToNextLevel { get; internal set; }
        //public int Ability3FeedpowerToMaxLevel { get; internal set; }

        public override string ToString ( )
        {
            return
                $"Stats: " +
                $"Ability 1: {Ability1}\n" +
                $"Level: {Ability1Level}\n" +
                //$"Points: {Ability1Points}\n" +
                //$"Next Level: {Ability1FeedpowerToNextLevel}\n" +
                //$"Max level: {Ability1FeedpowerToMaxLevel}\n" +

                $"Ability 2: {Ability2}\n" +
                $"Level: {Ability2Level}\n" +
                //$"Points: {Ability2Points}\n" +
                //$"Next Level: {Ability2FeedpowerToNextLevel}\n" +
                //$"Max level: {Ability2FeedpowerToMaxLevel}\n" +

                $"Ability 3: {Ability3}\n" +
                $"Level: {Ability3Level}\n" +
                //$"Points: {Ability3Points}\n" +
                //$"Next Level: {Ability3FeedpowerToNextLevel}\n" +
                //$"Max level: {Ability3FeedpowerToMaxLevel}\n" +
                $"\n";
        }

    }
}
