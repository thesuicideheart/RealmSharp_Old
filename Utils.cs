using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class Utils
    {

        public static string GetTiffitPetLink ( string player )
        {
            var url = "http://www.tiffit.net/RealmInfo/api/pets-of?u={player}";
            url = url.Replace( "{player}", player );
            return url;
        }

        public static string GetTiffitGuildLink ( string guild )
        {
            string api = "http://www.tiffit.net/RealmInfo/api/guild?g={guild}&f=";
            api = api.Replace( "{guild}", guild );
            return api;

        }

        public static string GetTiffitPlayerLink ( string user )
        {
            string api = "http://www.tiffit.net/RealmInfo/api/user?u={user}";
            api = api.Replace( "{user}", user );
            return api;
        }

        public static string [ ] GetArrayFromCommaSeperatedString ( string str )
        {
            var arr = str.Split( ',' );
            return arr;
        }

        public static string GetGraveyardURL ( string player )
        {
            var url = "https://www.realmeye.com/graveyard-of-player/{player}";
            url = url.Replace( "{player}", player );
            return url;
        }

        public static string GetPetyardURL ( string player )
        {
            var url = "https://www.realmeye.com/pets-of/{player}";
            url = url.Replace( "{player}", player );
            return url;
        }

        public static string GetPlayerURL ( string player )
        {
            var url = "https://www.realmeye.com/player/{player}";
            url = url.Replace( "{player}", player );
            return url;
        }

        public static JObject LoadJObjectFromWebAPI ( string API )
        {
            WebRequest req = WebRequest.Create( API );

            var res = req.GetResponse( );
            string json = "";
            using ( StreamReader stream = new StreamReader( res.GetResponseStream( ) ) )
            {
                json = stream.ReadToEnd( );
            }

            //TODO: 
            // Load graveyard
            // Load guild history
            // Load name history
            // Load pets

            var obj = JObject.Parse( json );

            return obj;
        }
    }
}
