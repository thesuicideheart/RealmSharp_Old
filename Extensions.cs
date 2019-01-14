using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    internal static class Extensions
    {
        internal static string GetValue ( this JToken obj, object key )
        {
            return obj [ key ].ToString();
        }
    }
}
