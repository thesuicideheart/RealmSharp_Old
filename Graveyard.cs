using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp
{
    public class Graveyard
    {

        public List<GraveyardItem> Deaths { get; internal set; } = new List<GraveyardItem>( );
        public string Owner { get; internal set; }

        public Graveyard(string owner )
        {
            Owner = owner;
        }

        public void Add ( GraveyardItem item )
        {
            Deaths.Add( item );
        }

    }
}
