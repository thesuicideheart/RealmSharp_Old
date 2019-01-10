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
    public class RealmSharpAPI
    {

        internal static bool UseTiffit { get; private set; }

        /// <summary>
        /// 
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

            WebRequest req = WebRequest.Create( CreateUserLink( name ) );

            var res = req.GetResponse( );
            string json = "";
            using ( StreamReader stream = new StreamReader( res.GetResponseStream( ) ) )
            {
                json = stream.ReadToEnd( );
            }

            var obj = JObject.Parse( json );

            return new Player( obj );
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
