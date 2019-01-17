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

        /// <summary>
        /// The singleton used if you ever wanna use this for some reason.
        /// </summary>
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

        /// <summary>
        /// loads a player into a player object.
        /// If you want to know more about player, look into <code>Player</code> class
        /// </summary>
        /// <param name="name">The player's IGN</param>
        /// <returns>Player object</returns>
        public Player LoadPlayer ( string name )
        {
            Player player = null;
            if ( UseTiffit )
            {
                player = new Player( Utils.LoadJObjectFromWebAPI( Utils.GetTiffitPlayerLink( name ) ) );
            }
            else
            {
                player = RealmScraper.ScrapePlayerPage( name );
            }
            return player;
        }

        /// <summary>
        /// Loads the graveyard of a player
        /// </summary>
        /// <param name="player">Player's IGN</param>
        /// <param name="graveCount">the amount of graves you want.</param>
        /// <returns>A graveyard object containing dead character data</returns>
        public Graveyard LoadGraveyard ( string player, int graveCount = 10 )
        {
            var graveyard = new Graveyard( player );

            graveyard = RealmScraper.ScrapeGraveyard( player, graveCount );

            return graveyard;
        }

        /// <summary>
        /// Loads the wanted player's pet yard
        /// </summary>
        /// <param name="player">Player of the IGN</param>
        /// <returns>Returns the petyard with all pets</returns>
        public PetYard LoadPetyard ( string player )
        {
            var petyard = new PetYard( player );

            if ( UseTiffit )
            {
                petyard = RealmScraper.LoadPetyardFromTiffit( player );
            }
            else
            {
                petyard = RealmScraper.ScrapePetyard( player );
            }


            return petyard;
        }

        /// <summary>
        /// Loads the wanted guild and all the members
        /// </summary>
        /// <param name="guildName">The name of the guildname</param>
        /// <returns>Returns a guild object containing guild data</returns>
        public Guild LoadGuild ( string guildName )
        {
            var guild = new Guild( );

            //TODO: Implement choice between using tiffit or scraping

            var obj = Utils.LoadJObjectFromWebAPI( Utils.GetTiffitGuildLink( guildName ) );

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

                //guildMember.Player = LoadPlayer( gMemObj.GetValue( "name" ) );

                //TODO: Load in guild member. 
                guild.GuildMembers.Add( guildMember );
            }




            return guild;
        }



    }
}
