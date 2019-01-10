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
        public int CharacterCount {
            get
            {
                return Characters.Count;
            }
        }

        public int Skins { get; private set; }
        public int AliveFame { get; private set; }
        public int AliveExp { get; private set; }
        public int Rank { get; private set; }
        public int AccountFame { get; private set; }
        public string Name { get; private set; }
        public string GuildRank { get; private set; }
        public string AccountCreatedDate { get; private set; }
        public string DescriptionLine1 { get; private set; }
        public string DescriptionLine2 { get; private set; }
        public string DescriptionLine3 { get; private set; }
        public string Guild { get; private set; }

        public List<Character> Characters { get; private set; } = new List<Character>( );

        public Player ( JObject obj )
        {
            Name = obj [ "name" ].ToString( );
            Skins = int.Parse( obj [ "skins" ].ToString( ) );
            AliveFame = int.Parse( obj [ "fame" ].ToString( ) );
            AliveExp = int.Parse( obj [ "xp" ].ToString( ) );
            Rank = int.Parse( obj [ "rank" ].ToString( ) );
            AccountFame = int.Parse( obj [ "account_fame" ].ToString( ) );
            GuildRank = obj [ "guild_rank" ].ToString( );
            Guild = obj [ "guild" ].ToString( );

            DescriptionLine1 = obj [ "description" ] [ 0 ].ToString( );
            DescriptionLine2 = obj [ "description" ] [ 1 ].ToString( );
            DescriptionLine3 = obj [ "description" ] [ 2 ].ToString( );

            AccountCreatedDate = obj [ "created" ].ToString( );

            var chars = obj [ "characters" ];
            foreach(var elem in chars )
            {
                var chr = new Character( elem );
                Characters.Add( chr );
            }

        }


        public override string ToString ( )
        {

            string chrString = "";

            foreach(var chr in Characters )
            {
                chrString += chr.ToString( );
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
                $"\tLine 1: {DescriptionLine1}\n" +
                $"\tLine 2: {DescriptionLine2}\n" +
                $"\tLine 3: {DescriptionLine3}\n" +
                $"\n" +
                $"Characters: \n" +
                $"{chrString}";
        }
    }
}
