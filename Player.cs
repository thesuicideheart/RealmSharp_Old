using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class Player
    {
        /// <summary>
        /// The amount of characters the player has alive 
        /// </summary>
        public int CharacterCount {
            get
            {
                return Characters.Count;
            }
        }

        /// <summary>
        /// The amount of skins the player has unlocked
        /// </summary>
        public int Skins { get; internal set; }
        
        /// <summary>
        /// The amount of fame gained across all alive characters
        /// </summary>
        public int AliveFame { get; internal set; }
        
        /// <summary>
        /// The amount of exp gained across all alive characters
        /// </summary>
        public int AliveExp { get; internal set; }
        
        /// <summary>
        /// The rank of the player(in stars)
        /// </summary>
        public int Rank { get; internal set; }

        /// <summary>
        /// The amount of fame the player currently has
        /// </summary>
        public int AccountFame { get; internal set; }

        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The guild rank(founder, leader, officer, member, initate)
        /// </summary>
        public string GuildRank { get; internal set; }

        /// <summary>
        /// Date of when account was created
        /// </summary>
        public string AccountCreatedDate { get; internal set; }

        /// <summary>
        /// The lines of the description
        /// </summary>
        public string [ ] Description { get; internal set; } = new string [ 3 ];

        /// <summary>
        /// The guild name of the player's guild
        /// </summary>
        public string Guild { get; internal set; }

        /// <summary>
        /// The server where the player was last seen
        /// </summary>
        public string LastSeen { get; internal set; }

        /// <summary>
        /// A list of characters.
        /// </summary>
        public List<Character> Characters { get; internal set; } = new List<Character>( );

        internal Player ( JObject obj )
        {
            Name = obj [ "name" ].ToString( );
            Skins = int.Parse( obj [ "skins" ].ToString( ) );
            AliveFame = int.Parse( obj [ "fame" ].ToString( ) );
            AliveExp = int.Parse( obj [ "xp" ].ToString( ) );
            Rank = int.Parse( obj [ "rank" ].ToString( ) );
            AccountFame = int.Parse( obj [ "account_fame" ].ToString( ) );
            GuildRank = obj [ "guild_rank" ].ToString( );
            Guild = obj [ "guild" ].ToString( );

            for ( int i = 0 ; i < obj [ "description" ].Count( ) ; i++ )
            {
                Description [ i ] = obj [ "description" ] [ i ].ToString( );
            }

            AccountCreatedDate = obj [ "created" ].ToString( );

            var chars = obj [ "characters" ];
            foreach ( var elem in chars )
            {
                var chr = new Character( elem );
                Characters.Add( chr );
            }

        }

        internal Player ( )
        {

        }

        internal Player ( string name ) => Name = name;

        public override string ToString ( )
        {

            string chrString = "";

            foreach ( var chr in Characters )
            {
                chrString += chr.ToString( );
            }

            string descString = "";

            for ( int i = 0 ; i < Description.Length ; i++ )
            {
                descString += $"\tLine {i + 1}: {Description [ i ]}\n";
            }

            return $"Name: {Name}\n" +
                $"Skins: {Skins}\n" +
                $"Fame: {AliveFame}\n" +
                $"Exp: {AliveExp}\n" +
                $"Rank: {Rank}\n" +
                $"Account Fame: {AccountFame}\n" +
                $"Guild: {Guild}\n" +
                $"Guild Rank: {GuildRank}\n" +
                $"Created: {AccountCreatedDate}\n" +
                $"Description:\n" +
                $"{descString}\n" +
                $"\n" +
                $"Characters: \n" +
                $"{chrString}";
        }
    }
}
