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

        public int Skins { get; internal set; }
        public int AliveFame { get; internal set; }
        public int AliveExp { get; internal set; }
        public int Rank { get; internal set; }
        public int AccountFame { get; internal set; }
        public string Name { get; internal set; }
        public string GuildRank { get; internal set; }
        public string AccountCreatedDate { get; internal set; }
        public string [ ] Description { get; internal set; } = new string [ 3 ];
        public string Guild { get; internal set; }

        public List<Character> Characters { get; internal set; } = new List<Character>( );

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

        public Player ( )
        {

        }

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
                descString += $"\tLine {i+1}: {Description[i]}\n";
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
