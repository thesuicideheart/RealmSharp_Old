using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp.Scraping
{
    internal class RealmScraper
    {
        public static Graveyard ScrapeGraveyard ( string player , int amountOfGravesToRetrieve = 10)
        {

            ScrapingBrowser browser = new ScrapingBrowser( );

            browser.AllowAutoRedirect = true;
            browser.AllowMetaRedirect = true;
            try
            {
                WebPage test = browser.NavigateToPage( new Uri( Utils.GetGraveyardURL( player ) ) );

                var Table = test.Html.CssSelect( ".table-responsive" ).First( );

                var graveyardTable = Table.LastChild;

                Graveyard yard = new Graveyard( player );
                int i = 0;
                foreach ( var row in graveyardTable.SelectNodes( "tbody/tr" ) )
                {
                    if(i <= amountOfGravesToRetrieve )
                    {
                        var deathItem = new GraveyardItem( );
                        deathItem.DeathDate = row.SelectSingleNode( "td[1]" ).InnerText;
                        deathItem.Class = row.SelectSingleNode( "td[3]" ).InnerText;
                        deathItem.Level = int.Parse( row.SelectSingleNode( "td[4]" ).InnerText );
                        deathItem.BaseFame = int.Parse( row.SelectSingleNode( "td[5]" ).InnerText.Replace( " ", "" ) );
                        deathItem.TotalFame = int.Parse( row.SelectSingleNode( "td[6]/span" ).InnerText.Replace( " ", "" ) );
                        deathItem.Exp = row.SelectSingleNode( "td[7]" ).InnerText.Replace( " ", "," );

                        deathItem.Equipment = new CharacterEquipment( );
                        deathItem.Equipment.Weapon = row.SelectSingleNode( "td[8]/span[1]/a[1]/span[1]" ).GetAttributeValue( "title" );
                        deathItem.Equipment.Ability = row.SelectSingleNode( "td[8]/span[2]/a[1]/span[1]" ).GetAttributeValue( "title" );
                        deathItem.Equipment.Armor = row.SelectSingleNode( "td[8]/span[3]/a[1]/span[1]" ).GetAttributeValue( "title" );
                        deathItem.Equipment.Ring = row.SelectSingleNode( "td[8]/span[4]/a[1]/span[1]" ).GetAttributeValue( "title" );

                        yard.Add( deathItem );
                        i++;
                    }
                    else
                    {
                        //yeet
                    }
                    
                }
                return yard;
            }
            catch ( Exception e )
            {
                Console.WriteLine( $"An error occured!\nCould not fetch graveyard of {player}\nPossible errors: \nA: Got a private profile\nB: Hid their graveyard" );
            }

            return null;
        }

        public static PetYard ScrapePetyard ( string player )
        {
            var petYard = new PetYard( );

            //TODO: Implement this.

            return petYard;
        }

    }
}
