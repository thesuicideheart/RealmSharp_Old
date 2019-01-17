using HtmlAgilityPack;
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

        internal static bool IsNotNull(this HtmlNode node)
        {
            return node != null;
        }

        internal static bool IsNotNull(this object obj )
        {
            return obj != null;
        }
    }
}
