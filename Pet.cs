using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class Pet
    {
        //public string PetSkin { get; internal set; }

        /// <summary>
        /// The pet name on realmeye.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Rarity of the pet.(divine, legendary...)
        /// </summary>
        public string Rarity { get; internal set; }

        /// <summary>
        /// The family of the pet.(????, Woodland...)
        /// </summary>
        public string Family { get; internal set; }

        /// <summary>
        /// The ranking of the pet.
        /// </summary>
        public string Place { get; internal set; }

        /// <summary>
        /// The max ability level of the pet.
        /// </summary>
        public string MaxAbilityLevel { get; internal set; }

        /// <summary>
        /// the ability stats of the pet
        /// </summary>
        public PetStats Stats { get; internal set; }


        public override string ToString ( )
        {
            return 
                $"Name: {Name}\n" +
                //$"Pet Skin: {PetSkin}\n" +
                $"Rarity: {Rarity}\n" +
                $"Family: {Family}\n" +
                $"Place: {Place}\n" +
                $"Max level: {MaxAbilityLevel}\n" +
                $"{Stats}\n";
        }

    }

    public class PetStats
    {

        /// <summary>
        /// The name of the first ability
        /// </summary>
        public string Ability1 { get; internal set; }
        /// <summary>
        /// The level of the first ability
        /// </summary>
        public int Ability1Level { get; internal set; }
        
        /// <summary>
        /// The name of the second ability
        /// </summary>
        public string Ability2 { get; internal set; }
        
        /// <summary>
        /// The level of the second ability
        /// </summary>
        public int Ability2Level { get; internal set; }

        /// <summary>
        /// The name of the third ability
        /// </summary>
        public string Ability3 { get; internal set; }

        /// <summary>
        /// The level of the third ability
        /// </summary>
        public int Ability3Level { get; internal set; }

        public override string ToString ( )
        {
            return
                $"Stats: \n" +
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
