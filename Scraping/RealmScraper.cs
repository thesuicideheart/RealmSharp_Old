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
        public static PetYard LoadPetyardFromTiffit ( string player )
        {
            var petyard = new PetYard( player );

            var obj = Utils.LoadJObjectFromWebAPI( Utils.GetTiffitPetLink( player ) );

            for ( int i = 0 ; i < obj [ "pets" ].Count( ) ; i++ )
            {
                var pet = new Pet( );
                pet.Name = obj [ i ] [ "name" ].ToString( );
                pet.Rarity = obj [ i ] [ "rarity" ].ToString( );
                if ( pet.Rarity.ToLower( ) == "common" )
                {
                    pet.MaxAbilityLevel = "30";
                }
                else if ( pet.Rarity.ToLower( ) == "uncommon" )
                {
                    pet.MaxAbilityLevel = "50";
                }
                else if ( pet.Rarity.ToLower( ) == "rare" )
                {
                    pet.MaxAbilityLevel = "70";
                }
                else if ( pet.Rarity.ToLower( ) == "legendary" )
                {
                    pet.MaxAbilityLevel = "90";
                }
                else if ( pet.Rarity.ToLower( ) == "divine" )
                {
                    pet.MaxAbilityLevel = "100";
                }
                pet.Place = obj [ i ] [ "place" ].ToString( );
                pet.Family = obj [ i ] [ "family" ].ToString( );

                pet.Stats = new PetStats( );
                pet.Stats.Ability1 = obj [ i ] [ "ability1" ] [ "type" ].ToString( );
                pet.Stats.Ability2 = obj [ i ] [ "ability2" ] [ "type" ].ToString( );
                pet.Stats.Ability3 = obj [ i ] [ "ability3" ] [ "type" ].ToString( );

                if ( obj [ i ] [ "ability1" ].GetValue( "level" ) != "" )
                    pet.Stats.Ability1Level = int.Parse( obj [ i ] [ "ability1" ] [ "level" ].ToString( ) );
                if ( obj [ i ] [ "ability2" ].GetValue( "level" ) != "" )
                    pet.Stats.Ability2Level = int.Parse( obj [ i ] [ "ability2" ] [ "level" ].ToString( ) );
                if ( obj [ i ] [ "ability3" ].GetValue( "level" ) != "" )
                    pet.Stats.Ability3Level = int.Parse( obj [ i ] [ "ability3" ] [ "level" ].ToString( ) );

            }

            return petyard;
        }

        public static Graveyard ScrapeGraveyard ( string player, int amountOfGravesToRetrieve = 10 )
        {

            var browser = SetupBrowser( );

            //try
            //{
            WebPage test = browser.NavigateToPage( new Uri( Utils.GetGraveyardURL( player ) ) );

            var Table = test.Html.CssSelect( ".table-responsive" ).First( );

            if ( Table != null )
            {
                var graveyardTable = Table.LastChild;

                Graveyard yard = new Graveyard( player );
                int i = 0;
                foreach ( var row in graveyardTable.SelectNodes( "tbody/tr" ) )
                {
                    if ( i <= amountOfGravesToRetrieve )
                    {
                        var deathItem = new GraveyardCharacter( );
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

                        if ( !weapNode.IsNotNull( ) )
                        {
                            deathItem.Equipment.Weapon = weapNode.GetAttributeValue( "title" );
                        }
                        if ( !abilityNode.IsNotNull( ) )
                        {
                            deathItem.Equipment.Ability = weapNode.GetAttributeValue( "title" );
                        }
                        if ( !armorNode.IsNotNull( ) )
                        {
                            deathItem.Equipment.Armor = weapNode.GetAttributeValue( "title" );
                        }
                        if ( !ringNode.IsNotNull( ) )
                        {
                            deathItem.Equipment.Ring = weapNode.GetAttributeValue( "title" );
                        }

                        deathItem.Equipment.HasBackpack = !backpackNode.IsNotNull( );

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

            return null;
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

            if ( Table != null )
            {
                var petyard = Table.LastChild;

                foreach ( var row in petyard.SelectNodes( "tbody/tr" ) )
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

                    if ( ab1Level.IsNotNull( ) )
                        if ( !string.IsNullOrEmpty( ab1Level.InnerText ) )
                            pet.Stats.Ability1Level = int.Parse( ab1Level.InnerText );

                    if ( ab2Level.IsNotNull( ) )
                        if ( !string.IsNullOrEmpty( ab2Level.InnerText ) )
                            pet.Stats.Ability2Level = int.Parse( ab2Level.InnerText );

                    if ( ab3Level.IsNotNull( ) )
                        if ( !string.IsNullOrEmpty( ab3Level.InnerText ) )
                            pet.Stats.Ability3Level = int.Parse( ab3Level.InnerText );


                    //pet.Stats.Ability1Level = int.Parse( ab1Node.InnerText );
                    //pet.Stats.Ability2Level = int.Parse( ab2Node.InnerText );
                    //pet.Stats.Ability3Level = int.Parse( ab3Node.InnerText );

                    petYard.Add( pet );

                }
                return petYard;

            }

            else
            {
                return null;
            }
        }

        public static Player ScrapePlayerPage ( string playerName )
        {
            var player = new Player( playerName );

            var browser = SetupBrowser( );

            var page = browser.NavigateToPage( new Uri( Utils.GetPlayerURL( playerName ) ) );

            var wantedElements = page.Html.CssSelect( ".col-md-12" );

            if ( wantedElements != null )
            {
                var mainElem = wantedElements.First( );

                if ( mainElem != null )
                {

                    var statsXpath = "div[1]/div[1]/table[1]/";
                    var descXpath = "div[1]/div[2]/div[1]/";
                    var nameElem = mainElem.SelectSingleNode( "h1[1]/span[1]" );
                    if ( nameElem != null )
                    {
                        var charCount = mainElem.SelectSingleNode( statsXpath + "tr[1]/td[2]" );
                        var skins = mainElem.SelectSingleNode( statsXpath + "tr[2]/td[2]/span[1]" );
                        var fame = mainElem.SelectSingleNode( statsXpath + "tr[3]/td[2]/span[1]" );
                        var exp = mainElem.SelectSingleNode( statsXpath + "tr[4]/td[2]/span[1]" );
                        var rank = mainElem.SelectSingleNode( statsXpath + "tr[5]/td[2]/div[1]" );
                        var accountFame = mainElem.SelectSingleNode( statsXpath + "tr[6]/td[2]/span[1]" );
                        var guild = mainElem.SelectSingleNode( statsXpath + "tr[7]/td[2]/a[1]" );
                        var guildRank = mainElem.SelectSingleNode( statsXpath + "tr[8]/td[2]" );
                        var created = mainElem.SelectSingleNode( statsXpath + "tr[9]/td[2]" );
                        var lastSeen = mainElem.SelectSingleNode( statsXpath + "tr[10]/td[2]" );

                        var line1 = mainElem.SelectSingleNode( descXpath + "div[1]" ).InnerText;
                        var line2 = mainElem.SelectSingleNode( descXpath + "div[2]" ).InnerText;
                        var line3 = mainElem.SelectSingleNode( descXpath + "div[3]" ).InnerText;

                        var Table = page.Html.CssSelect( ".table-responsive" ).First( );

                        if ( Table != null )
                        {
                            var chrTable = Table.LastChild;
                            foreach ( var row in chrTable.SelectNodes( "tbody/tr" ) )
                            {
                                var chr = new Character( );
                                var Class = row.SelectSingleNode( "td[3]" );
                                var Level = row.SelectSingleNode( "td[4]" );
                                var CQC = row.SelectSingleNode( "td[5]" );
                                var Fame = row.SelectSingleNode( "td[6]" );
                                var Exp = row.SelectSingleNode( "td[7]" );
                                var Place = row.SelectSingleNode( "td[8]" );
                                var equipElem = row.SelectSingleNode( "td[9]" );
                                var weap = equipElem.SelectSingleNode( "span[1]/a[1]/span[1]" );
                                var ability = equipElem.SelectSingleNode( "span[2]/a[1]/span[1]" );
                                var armor = equipElem.SelectSingleNode( "span[3]/a[1]/span[1]" );
                                var ring = equipElem.SelectSingleNode( "span[4]/a[1]/span[1]" );
                                var hasBackpack = equipElem.SelectSingleNode( "span[5]/a[1]/span[1]" ).IsNotNull( );

                                var stats = row.SelectSingleNode( "td[10]" );
                                var maxedStats = stats.SelectSingleNode( "span[1]" ).InnerText;
                                var currStats = stats.SelectSingleNode( "span[1]" ).GetAttributeValue( "data-stats" );
                                var bonuses = stats.SelectSingleNode( "span[1]" ).GetAttributeValue( "data-bonuses" );

                                currStats = currStats.Remove( 0, 1 );
                                currStats = currStats.Remove( currStats.Length - 1, 1 );
                                bonuses = bonuses.Remove( 0, 1 );
                                bonuses = bonuses.Remove( bonuses.Length - 1, 1 );

                                if ( Class.IsNotNull( ) && Level.IsNotNull( ) && CQC.IsNotNull( ) && Fame.IsNotNull( )
                                    && Exp.IsNotNull( ) && Place.IsNotNull( ) && equipElem.IsNotNull( ) && weap.IsNotNull( )
                                    && ability.IsNotNull( ) && armor.IsNotNull( ) && ring.IsNotNull( )
                                    && stats.IsNotNull( ) && currStats.IsNotNull( ) && bonuses.IsNotNull( ) )
                                {
                                    //TODO: Implement exact stats
                                    chr.Class = Class.InnerText;
                                    chr.Level = int.Parse( Level.InnerText );
                                    chr.ClassQuestCompleted = CQC.InnerText;
                                    chr.Fame = int.Parse( Fame.InnerText.Replace( " ", "" ) );
                                    chr.Exp = int.Parse( Exp.InnerText.Replace( " ", "" ) );
                                    chr.Place = Place.InnerText;

                                    chr.Equipment = new CharacterEquipment( );
                                    chr.Equipment.Weapon = weap.GetAttributeValue( "title" ).Replace( "&apos;", "'" );
                                    chr.Equipment.Ability = ability.GetAttributeValue( "title" ).Replace( "&apos;", "'" );
                                    chr.Equipment.Armor = armor.GetAttributeValue( "title" ).Replace( "&apos;", "'" );
                                    chr.Equipment.Ring = ring.GetAttributeValue( "title" ).Replace( "&apos;", "'" );
                                    chr.Equipment.HasBackpack = hasBackpack;

                                    player.Characters.Add( chr );

                                }
                                else
                                {
                                    throw new Exception( "Error scraping characters" );
                                }
                            }
                        }

                        if ( skins.IsNotNull( ) && fame.IsNotNull( ) && exp.IsNotNull( ) && rank.IsNotNull( ) && accountFame.IsNotNull( )
                            && guild.IsNotNull( ) && guildRank.IsNotNull( ) && created.IsNotNull( ) && lastSeen.IsNotNull( ) && line1.IsNotNull( )
                            && line2.IsNotNull( ) && line3.IsNotNull( ) )
                        {
                            player.Skins = int.Parse( skins.InnerText );
                            player.AliveFame = int.Parse( fame.InnerText.Replace( " ", "" ) );
                            player.AliveExp = int.Parse( exp.InnerText.Replace( " ", "" ) );
                            player.Rank = int.Parse( rank.InnerText );
                            player.AccountFame = int.Parse( accountFame.InnerText.Replace( " ", "" ) );
                            player.Guild = guild.InnerText;
                            player.GuildRank = guildRank.InnerText;
                            player.AccountCreatedDate = created.InnerText;
                            player.LastSeen = created.InnerText;
                            player.Description [ 0 ] = line1;
                            player.Description [ 1 ] = line2;
                            player.Description [ 2 ] = line3;
                        }
                        else
                        {
                            throw new Exception( "Something went wrong when scraping player data." );
                        }

                    }
                    else
                    {
                        throw new Exception( "Could not load player. Player most likely got a private profile" );
                    }


                }


                return player;

            }
            return null;
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
