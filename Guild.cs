using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    /// <summary>
    /// Contains data for a guild
    /// </summary>
    public class Guild
    {
        /// <summary>
        /// Name of the guild
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The guilds most active server
        /// </summary>
        public string MostActiveServer { get; internal set; }

        /// <summary>
        /// The rank of the guild on the guild's most active server
        /// </summary>
        public string MostActiveServerRank { get; internal set; }

        /// <summary>
        /// The character amount of characters in the guild
        /// </summary>
        public int Characters { get; internal set; }

        /// <summary>
        /// The guild's total alive fame
        /// </summary>
        public int Fame { get; internal set; }

        /// <summary>
        /// The rank of the guild in fame
        /// </summary>
        public string FameRank { get; internal set; }

        /// <summary>
        /// The guild's total alive exp
        /// </summary>
        public int Exp { get; internal set; }

        /// <summary>
        /// The rank of the guild in fame
        /// </summary>
        public string ExpRank { get; internal set; }

        /// <summary>
        /// The 3 lines of description
        /// </summary>
        public string [ ] Description { get; internal set; } = new string [ 3 ];

        /// <summary>
        /// The list of guild members
        /// </summary>
        public List<GuildMember> GuildMembers { get; internal set; } = new List<GuildMember>( );

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
