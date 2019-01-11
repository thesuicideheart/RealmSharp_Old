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
        public static JObject LoadJObjectFromWebAPI(string API )
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
