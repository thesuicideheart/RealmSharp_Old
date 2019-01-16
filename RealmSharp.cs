using Newtonsoft.Json.Linq;
using RealmSharp.Scraping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class RealmSharpAPI
    {

        internal static bool UseTiffit { get; private set; }

        public static RealmSharpAPI Singleton {
            get
            {
                if ( Singleton == null )
                    Singleton = Init( true );
                return Singleton;
            }
            set
            {
                Singleton = value;
            }
        }

        /// <summary>
        /// Returns an instance of the API class. Used to get player data
        /// </summary>
        /// <param name="UseTiffit">if declared as true, will use tiffit's realm api</param>
        /// <returns></returns>
		public static RealmSharpAPI Init ( bool useTiffit )
        {
            UseTiffit = useTiffit;
            var realmSharp = new RealmSharpAPI( );

            return realmSharp;
        }

        public Player LoadPlayer ( string name )
        {
            Player player = null;
            if ( UseTiffit )
            {
                player = new Player( Utils.LoadJObjectFromWebAPI( CreateUserLink( name ) ) );
            }
            else
            {
                //player = Player.ScrapePlayer( name );
                player = RealmScraper.ScrapePlayerPage( name );
            }
            return player;
        }

        public Graveyard LoadGraveyard ( string player, int graveCount = 10 )
        {
            var graveyard = new Graveyard( player );

            graveyard = RealmScraper.ScrapeGraveyard( player, graveCount );

            return graveyard;
        }

        public PetYard LoadPetyard ( string player )
        {
            var petyard = new PetYard( player );

            petyard = RealmScraper.ScrapePetyard( player );

            return petyard;
        }

        public Guild LoadGuild ( string guildName )
        {
            var guild = new Guild( );

            if ( UseTiffit )
            {
                var obj = Utils.LoadJObjectFromWebAPI( CreateGuildLink( guildName ) );

                guild.SetName( obj [ "name" ].ToString( ) );
                guild.SetCharacters( int.Parse( obj [ "characters" ].ToString( ) ) );

                guild.SetFame( int.Parse( obj [ "fame" ] [ "amount" ].ToString( ) ) );
                guild.SetFameRank( obj [ "fame" ] [ "rank" ].ToString( ) );

                guild.SetExp( int.Parse( obj [ "xp" ] [ "amount" ].ToString( ) ) );
                guild.SetExpRank( obj [ "xp" ] [ "rank" ].ToString( ) );

                guild.SetMostActiveServer( obj [ "most_active" ] [ "server" ].ToString( ) );
                guild.SetMostActiveServerRank( obj [ "most_active" ] [ "rank" ].ToString( ) );

                for ( int i = 0 ; i < obj [ "desc" ].Count( ) ; i++ )
                {
                    guild.SetDescriptionLine( i, obj [ "desc" ] [ i ].ToString( ) );
                }

                for ( int i = 0 ; i < obj [ "members" ].Count( ) ; i++ )
                {
                    var guildMember = new GuildMember( );
                    var gMemObj = obj [ "members" ] [ i ];

                    guildMember.SetName( gMemObj.GetValue( "name" ) );
                    guildMember.SetGuildRank( gMemObj.GetValue( "guild_rank" ) );
                    guildMember.SetLastSeen( gMemObj.GetValue( "last_seen" ) );
                    guildMember.SetLastSeenServer( gMemObj.GetValue( "server" ) );
                    guildMember.SetFame( int.Parse( gMemObj.GetValue( "fame" ) ) );
                    guildMember.SetExp( int.Parse( gMemObj.GetValue( "xp" ) ) );
                    guildMember.SetRank( int.Parse( gMemObj.GetValue( "rank" ) ) );

                    //TODO: Load in guild member. 
                    guild.GuildMembers.Add( guildMember );
                }

            }


            return guild;
        }

        private string CreateGuildLink ( string guild )
        {
            string api = "http://www.tiffit.net/RealmInfo/api/guild?g={guild}&f=";
            api = api.Replace( "{guild}", guild );
            Console.WriteLine( api );
            return api;

        }

        private string CreateUserLink ( string user )
        {
            string api = "http://www.tiffit.net/RealmInfo/api/user?u={user}";
            api = api.Replace( "{user}", user );
            Console.WriteLine( api );
            return api;
        }

    }
}
