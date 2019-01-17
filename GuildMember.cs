using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    /// <summary>
    /// Guild member object
    /// </summary>
    public class GuildMember
    {
        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The rank of the player
        /// </summary>
        public string GuildRank { get; internal set; }

        /// <summary>
        /// The last seen time
        /// </summary>
        public string LastSeen { get; internal set; }

        /// <summary>
        /// The last seen sever
        /// </summary>
        public string LastSeenServer { get; internal set; }

        /// <summary>
        /// Amount of stars the player has
        /// </summary>
        public int Rank { get; internal set; }

        /// <summary>
        /// The amount of alive fame the player has
        /// </summary>
        public int Fame { get; internal set; }

        /// <summary>
        /// The amount of Exp the player has. 
        /// </summary>
        public int Exp { get; internal set; }

        /// <summary>
        /// The player data object for a guild member
        /// </summary>
        //public Player Player { get; internal set; }

        //TODO: Change all Setters function to assign instead;

        internal void SetName ( string name )
        {
            Name = name;
        }

        internal void SetGuildRank ( string guildRank )
        {
            GuildRank = guildRank;
        }

        internal void SetLastSeen ( string lastSeen )
        {
            LastSeen = lastSeen;
        }

        internal void SetLastSeenServer ( string server )
        {
            LastSeenServer = server;
        }

        internal void SetFame ( int fame )
        {
            Fame = fame;
        }

        internal void SetExp ( int exp )
        {
            Exp = exp;
        }

        internal void SetRank ( int rank )
        {
            Rank = rank;
        }

        public string ToString ( bool shouldIndent )
        {
            if ( shouldIndent )
            {
                return
                    $"Name: {Name}\n" +
                    $"\tGuild Rank: {GuildRank}\n" +
                    $"\tRank: {Rank}\n" +
                    $"\tLast seen: {LastSeen}\n" +
                    $"\tLast seen server: {LastSeenServer}\n" +
                    $"\tFame: {Fame}\n" +
                    $"\tExp: {Exp}\n";
            }
            else
            {
                return ToString( );
            }
        }

        public override string ToString ( )
        {

            return
                $"Name: {Name}\n" +
                $"Guild Rank: {GuildRank}\n" +
                $"Rank: {Rank}\n" +
                $"Last seen: {LastSeen}\n" +
                $"Last seen server: {LastSeenServer}\n" +
                $"Fame: {Fame}\n" +
                $"Exp: {Exp}\n";
        }


    }
}
