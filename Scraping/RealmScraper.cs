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
        public static Graveyard ScrapeGraveyard ( string player, int amountOfGravesToRetrieve = 10 )
        {

            var browser = SetupBrowser( );

            //try
            //{
            WebPage test = browser.NavigateToPage( new Uri( Utils.GetGraveyardURL( player ) ) );

            var Table = test.Html.CssSelect( ".table-responsive" ).First( );



            var graveyardTable = Table.LastChild;

            Graveyard yard = new Graveyard( player );
            int i = 0;
            foreach ( var row in graveyardTable.SelectNodes( "tbody/tr" ) )
            {
                if ( i <= amountOfGravesToRetrieve )
                {
                    var deathItem = new GraveyardItem( );
                    deathItem.DeathDate = row.SelectSingleNode( "td[1]" ).InnerText;
                    deathItem.Class = row.SelectSingleNode( "td[3]" ).InnerText;
                    deathItem.Level = int.Parse( row.SelectSingleNode( "td[4]" ).InnerText );
                    deathItem.BaseFame = int.Parse( row.SelectSingleNode( "td[5]" ).InnerText.Replace( " ", "" ) );
                    deathItem.TotalFame = int.Parse( row.SelectSingleNode( "td[6]/span" ).InnerText.Replace( " ", "" ) );
                    deathItem.Exp = row.SelectSingleNode( "td[7]" ).InnerText.Replace( " ", "," );

                    deathItem.Equipment = new CharacterEquipment( );

                    var weapNode = row.SelectSingleNode( "td[8]/span[1]/a[1]/span[1]" );
                    var abilityNode = row.SelectSingleNode( "td[8]/span[2]/a[1]/span[1]" );
                    var armorNode = row.SelectSingleNode( "td[8]/span[3]/a[1]/span[1]" );
                    var ringNode = row.SelectSingleNode( "td[8]/span[4]/a[1]/span[1]" );
                    var backpackNode = row.SelectSingleNode( "td[8]/span[5]/a[1]/span[1]" );

                    if ( !weapNode.IsNodeNotNull( ) )
                    {
                        deathItem.Equipment.Weapon = weapNode.GetAttributeValue( "title" );
                    }
                    if ( !abilityNode.IsNodeNotNull( ) )
                    {
                        deathItem.Equipment.Ability = weapNode.GetAttributeValue( "title" );
                    }
                    if ( !armorNode.IsNodeNotNull( ) )
                    {
                        deathItem.Equipment.Armor = weapNode.GetAttributeValue( "title" );
                    }
                    if ( !ringNode.IsNodeNotNull( ) )
                    {
                        deathItem.Equipment.Ring = weapNode.GetAttributeValue( "title" );
                    }

                    deathItem.Equipment.HasBackpack = !backpackNode.IsNodeNotNull( );

                    yard.Add( deathItem );
                    i++;
                }
                else
                {
                    //yeet
                }

            }
            return yard;
            //}
            //catch ( Exception e )
            //{
            //    Console.WriteLine( $"An error occured!\nCould not fetch graveyard of {player}\nPossible errors: \nA: Got a private profile\nB: Hid their graveyard" );
            //}

            //return null;
        }

        public static PetYard ScrapePetyard ( string player )
        {
            var petYard = new PetYard( );

            var browser = SetupBrowser( );


            WebPage page = browser.NavigateToPage( new Uri( Utils.GetPetyardURL( player ) ) );

            var Table = page.Html.CssSelect( ".table-responsive" ).First( );

            var graveyardTable = Table.LastChild;

            foreach ( var row in graveyardTable.SelectNodes( "tbody/tr" ) )
            {
                Pet pet = new Pet( );

                var skinNode = row.SelectSingleNode( "td[1]/span[1]" );
                var nameNode = row.SelectSingleNode( "td[2]" );
                var familyNode = row.SelectSingleNode( "td[3]" );
                var rarityNode = row.SelectSingleNode( "td[4]" );
                var placeNode = row.SelectSingleNode( "td[5]" );

                var ab1Name = row.SelectSingleNode( "td[6]/span[1]" );
                var ab2Name = row.SelectSingleNode( "td[8]/span[1]" );
                var ab3Name = row.SelectSingleNode( "td[10]/span[1]" );

                var ab1Level = row.SelectSingleNode( "td[7]/span[1]" );
                var ab2Level = row.SelectSingleNode( "td[9]/span[1]" );
                var ab3Level = row.SelectSingleNode( "td[11]" );

                pet.Name = nameNode.InnerText;
                pet.Family = familyNode.InnerText;
                pet.Rarity = rarityNode.InnerText;
                pet.Place = row.SelectSingleNode( "td[5]" ).InnerText;

                pet.Stats = new PetStats( );
                pet.Stats.Ability1 = ab1Name.InnerText;
                pet.Stats.Ability2 = ab2Name.InnerText;
                pet.Stats.Ability3 = ab3Name.InnerText;

                if ( ab1Level.IsNodeNotNull( ) )
                    if ( !string.IsNullOrEmpty( ab1Level.InnerText ) )
                        pet.Stats.Ability1Level = int.Parse( ab1Level.InnerText );

                if ( ab2Level.IsNodeNotNull( ) )
                    if ( !string.IsNullOrEmpty( ab2Level.InnerText ) )
                        pet.Stats.Ability2Level = int.Parse( ab2Level.InnerText );

                if ( ab3Level.IsNodeNotNull( ) )
                    if ( !string.IsNullOrEmpty( ab3Level.InnerText ) )
                        pet.Stats.Ability3Level = int.Parse( ab3Level.InnerText );


                //pet.Stats.Ability1Level = int.Parse( ab1Node.InnerText );
                //pet.Stats.Ability2Level = int.Parse( ab2Node.InnerText );
                //pet.Stats.Ability3Level = int.Parse( ab3Node.InnerText );

                petYard.Add( pet );

            }
            return petYard;

        }

        public static Player ScrapePlayerPage ( string playerName )
        {
            var player = new Player( );

            var browser = SetupBrowser( );

            var page = browser.NavigateToPage( new Uri( Utils.GetPlayerURL( playerName ) ) );

            var wantedElements = page.Html.CssSelect( ".col-md-12" );

            var mainElem = wantedElements.First( );

            if ( mainElem != null )
            {
                var xpath = "div[1]/div[1]/table[1]/";
                var nameElem = mainElem.SelectSingleNode( "h1[1]/span[1]" );
                var charCount = mainElem.SelectSingleNode( xpath + "tr[1]/td[2]" ).InnerText;
                var skins = mainElem.SelectSingleNode( xpath+"tr[2]/td[2]/span[1]" ).InnerText;
                //TODO: Finish this
                Console.WriteLine( skins );


            }


            return player;
        }

        internal static ScrapingBrowser SetupBrowser ( )
        {
            var browser = new ScrapingBrowser( );
            browser.AllowAutoRedirect = true;
            browser.AllowMetaRedirect = true;
            return browser;
        }

    }
}
