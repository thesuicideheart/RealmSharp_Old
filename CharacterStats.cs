using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    internal class CharacterStats
    {
        public int Health { get; internal set; }
        public int Mana { get; internal set; }
        public int Defence { get; internal set; }
        public int Attack { get; internal set; }
        public int Speed { get; internal set; }
        public int Dexterity { get; internal set; }
        public int Wisdom { get; internal set; }
        public int Vitality { get; internal set; }

        public int MaxHealth { get; internal set; }
        public int MaxMana { get; internal set; }
        public int MaxAttack { get; internal set; }
        public int MaxDefence { get; internal set; }
        public int MaxSpeed { get; internal set; }
        public int MaxDexterity { get; internal set; }
        public int MaxWisdom { get; internal set; }
        public int MaxVitality { get; internal set; }

        public CharacterStats ( )
        {

        }

        public CharacterStats ( string cls ) => LoadMaxStats( cls );

        public void LoadMaxStats ( string cl )
        {
            switch ( cl.ToLower( ) )
            {

                //TODO: Check if theyre the same as on realmeye. Will do some time later. im too lazy
                #region rogue
                case "rogue":
                    MaxHealth = 720;
                    MaxMana = 252;
                    MaxAttack = 50;
                    MaxDefence = 25;
                    MaxSpeed = 75;
                    MaxDexterity = 75;
                    MaxVitality = 40;
                    MaxWisdom = 50;

                    break;

                #endregion

                #region archer
                case "archer":
                    MaxHealth = 700;
                    MaxMana = 252;
                    MaxAttack = 75;
                    MaxDefence = 25;
                    MaxSpeed = 50;
                    MaxDexterity = 50;
                    MaxVitality = 40;
                    MaxWisdom = 50;


                    break;

                #endregion

                #region wizard
                case "wizard":
                    MaxHealth = 670;
                    MaxMana = 385;
                    MaxAttack = 75;
                    MaxDefence = 25;
                    MaxSpeed = 50;
                    MaxDexterity = 75;
                    MaxVitality = 40;
                    MaxWisdom = 60;


                    break;

                #endregion

                #region priest
                case "priest":
                    MaxHealth = 670;
                    MaxMana = 385;
                    MaxAttack = 50;
                    MaxDefence = 25;
                    MaxSpeed = 55;
                    MaxDexterity = 55;
                    MaxVitality = 40;
                    MaxWisdom = 75;

                    break;

                #endregion

                #region warrior
                case "warrior":
                    MaxHealth = 770;
                    MaxMana = 252;
                    MaxAttack = 75;
                    MaxDefence = 25;
                    MaxSpeed = 50;
                    MaxDexterity = 50;
                    MaxVitality = 75;
                    MaxWisdom = 50;

                    break;

                #endregion

                #region knight
                case "knight":
                    MaxHealth = 770;
                    MaxMana = 252;
                    MaxAttack = 50;
                    MaxDefence = 40;
                    MaxSpeed = 50;
                    MaxDexterity = 50;
                    MaxVitality = 75;
                    MaxWisdom = 50;

                    break;
                #endregion

                #region paladin
                case "paladin":
                    MaxHealth = 770;
                    MaxMana = 252;
                    MaxAttack = 50;
                    MaxDefence = 30;
                    MaxSpeed = 55;
                    MaxDexterity = 50;
                    MaxVitality = 40;
                    MaxWisdom = 75;

                    break;
                #endregion

                #region assassin
                case "assassin":
                    MaxHealth = 720;
                    MaxMana = 252;
                    MaxAttack = 60;
                    MaxDefence = 25;
                    MaxSpeed = 75;
                    MaxDexterity = 75;
                    MaxVitality = 40;
                    MaxWisdom = 60;

                    break;

                #endregion

                #region necromancer
                case "necromancer":
                    MaxHealth = 670;
                    MaxMana = 385;
                    MaxAttack = 75;
                    MaxDefence = 25;
                    MaxSpeed = 50;
                    MaxDexterity = 60;
                    MaxVitality = 30;
                    MaxWisdom = 75;

                    break;

                #endregion

                #region huntress
                case "huntress":
                    MaxHealth = 700;
                    MaxMana = 252;
                    MaxAttack = 75;
                    MaxDefence = 25;
                    MaxSpeed = 50;
                    MaxDexterity = 50;
                    MaxVitality = 40;
                    MaxWisdom = 50;

                    break;

                #endregion

                #region mystic
                case "mystic":
                    MaxHealth = 670;
                    MaxMana = 385;
                    MaxAttack = 60;
                    MaxDefence = 25;
                    MaxSpeed = 60;
                    MaxDexterity = 55;
                    MaxVitality = 40;
                    MaxWisdom = 75;

                    break;

                #endregion

                #region trickster
                case "trickster":
                    MaxHealth = 720;
                    MaxMana = 252;
                    MaxAttack = 65;
                    MaxDefence = 25;
                    MaxSpeed = 75;
                    MaxDexterity = 75;
                    MaxVitality = 40;
                    MaxWisdom = 60;

                    break;

                #endregion

                #region sorcerer
                case "sorcerer":
                    MaxHealth = 670;
                    MaxMana = 385;
                    MaxAttack = 40;
                    MaxDefence = 25;
                    MaxSpeed = 60;
                    MaxDexterity = 60;
                    MaxVitality = 75;
                    MaxWisdom = 60;

                    break;

                #endregion

                #region ninja(fuck you flux)
                case "ninja":
                    MaxHealth = 720;
                    MaxMana = 252;
                    MaxAttack = 70;
                    MaxDefence = 25;
                    MaxSpeed = 60;
                    MaxDexterity = 70;
                    MaxVitality = 40;
                    MaxWisdom = 70;

                    break;

                #endregion

                #region MyRegion samurai
                case "samurai":
                    MaxHealth = 720;
                    MaxMana = 252;
                    MaxAttack = 75;
                    MaxDefence = 25;
                    MaxSpeed = 50;
                    MaxDexterity = 50;
                    MaxVitality = 40;
                    MaxWisdom = 60;

                    break;

                #endregion

                default:
                    break;
            }
        }

    }
}
