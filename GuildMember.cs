using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class GuildMember
    {
        public string Name { get; private set; }
        public string GuildRank { get; private set; }
        public string LastSeen { get; private set; }
        public string LastSeenServer { get; private set; }
        public int Rank { get; private set; }
        public int Fame { get; private set; }
        public int Exp { get; private set; }

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
