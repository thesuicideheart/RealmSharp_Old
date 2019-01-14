using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class Guild
    {
        public string Name { get; private set; }
        public string MostActiveServer { get; private set; }
        public string MostActiveServerRank { get; private set; }
        public int Characters { get; private set; }
        public int Fame { get; private set; }
        public string FameRank { get; private set; }
        public int Exp { get; private set; }
        public string ExpRank { get; private set; }

        public string [ ] Description { get; private set; } = new string [ 3 ];

        public List<GuildMember> GuildMembers { get; private set; } = new List<GuildMember>( );

        internal void SetName ( string name )
        {
            Name = name;
        }

        internal void SetDescriptionLine ( int line, string val )
        {
            if ( line < 0 ) line = 0;
            if ( line >= 3 ) line = 2;
            Description [ line ] = val;
        }

        internal void SetMostActiveServer ( string server )
        {
            MostActiveServer = server;
        }

        internal void SetCharacters ( int chrs )
        {
            Characters = chrs;
        }

        internal void SetFame ( int fame )
        {
            Fame = fame;
        }

        internal void SetFameRank ( string rank )
        {
            FameRank = rank;
        }

        internal void SetExp ( int exp )
        {
            Exp = exp;
        }

        internal void SetExpRank ( string rank )
        {
            ExpRank = rank;
        }

        internal void SetMostActiveServerRank ( string rank )
        {
            MostActiveServerRank = rank;
        }

        public override string ToString ( )
        {

            string descStr = "";
            string gmStr = "";


            for ( int i = 0 ; i < Description.Length ; i++ )
            {
                descStr += $"\tLine {i + 1}: {Description [ i ]}\n";
            }

            for ( int i = 0 ; i < GuildMembers.Count( ) ; i++ )
            {
                gmStr += 
                    $"Guild member {GuildMembers [ i ].Name}\n"+
                    $"\t{GuildMembers[i].ToString(true)}\n";
            }

            return
                $"Name: {Name}\n" +
                $"Characters: {Characters}\n" +
                $"Fame: {Fame} ({FameRank})\n" +
                $"Exp: {Exp} ({ExpRank})\n" +
                $"Description: \n" +
                $"{descStr}\n" +
                $"Guild members: \n" +
                $"{gmStr}\n" +
                $"";
        }

    }
}
