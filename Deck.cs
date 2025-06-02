/*
 * Deck/collection object
 *
 * Contains all the Magic cards added during a given execution
 * Allows for adding, removing, and searching for cards
 * ToString prints out the name of each card in the collection
 */
namespace TermProject;

public class Deck
{
    List<Card> Cards { get; set; } = new();

    public void AddCard()
    {
        Console.WriteLine("Enter the card's name: ");
        string? name = Console.ReadLine();
        
        // provide a useful link if the user isn't aware of
        // scryfall mana cost syntax structure
        // (scryfall is my de facto MTG search engine)
        string? manaCost = "";
        bool helped = false;
        while (!helped)
        {
            Console.WriteLine("Enter the card's mana cost: (for colored \"pips\" enclose them in {} like {R} or {2/U}.\nEnter \"help\" for more details)");
            manaCost = Console.ReadLine();
            if (manaCost != null && manaCost.ToLower() == "help")
            {
                Console.WriteLine("\nPlease visit: https://scryfall.com/docs/syntax#mana for a guide on mana cost syntax.\n");
            }
            else
            {
                helped = true;
            }
        }
        Console.WriteLine("Enter the card's typeline: (e.g. Creature - Soldier; Sorcery; Planeswalker - Liliana...)");
        string? typeLine = Console.ReadLine();

        bool raritySet = false;
        string? rarityLine = "";
        do
        {
            Console.WriteLine("Enter the card's rarity - choose one of [common, uncommon, rare, mythic rare]: (must be exact match)");
            rarityLine = Console.ReadLine().ToLower();
            switch (rarityLine.ToLower())
            {
                case "common":
                    rarityLine = "⚫️️";
                    raritySet = true;
                    break;
                case "uncommon":
                    rarityLine = "⚪️";
                    raritySet = true;
                    break;
                case "rare":
                    rarityLine = "🟠️";
                    raritySet = true;
                    break;
                case "mythic rare":
                    rarityLine = "🔴";
                    raritySet = true;
                    break;
                default:
                    Console.WriteLine("error: wrong input, try again");
                    break;
            }
        } while (!raritySet);

        Console.WriteLine("Enter the card's text: (hit enter or ctrl+enter to enter new line)\n*Enter END on a line (without other characters) to finish input*");
        string? text = "";
        string? line;
        do
        {
            line = Console.ReadLine();
            if (line != null && line.ToLower() != "end")
            {
                text += line + "\n";
            }
        } while (line.ToLower() != "end");

        if (text.Length > 0)
        {
            text = text.Substring(0, text.Length - 1); // remove final newline char
        }

        Console.WriteLine("Enter the card's flavor text: (the storytelling text beneath the card text)\n*Enter END on a line (without other characters) to finish input*");
        string? flavorText = "";
        string? flavorLine;
        do
        {
            flavorLine = Console.ReadLine();
            if (flavorLine != null && flavorLine.ToLower() != "end")
            {
                flavorText += flavorLine + "\n";
            }
        } while (flavorLine.ToLower() != "end");

        if (flavorText.Length > 0)
        {
            flavorText = flavorText.Substring(0, flavorText.Length - 1); // remove final newline char
        }
        

        Console.WriteLine("Enter the artist's name: ");
        string? artist = Console.ReadLine();

        string isCreature = "";
        int power = -99;
        int toughness = -99;
        
        do
        // handle creatures and vehicles, they have power/toughness as a card attribute
        {
            Console.WriteLine("Does the card need power and toughness added?: (Y/y for yes, N/n for no)");
            isCreature = (Console.ReadLine()).ToLower();
        } while (isCreature != "y" && isCreature != "n");

        
        switch (isCreature)
        {
            case "y":
                
                // handle assigning power
                bool valid = false;
                do
                {
                    Console.WriteLine("Enter the card's power: ");
                    valid = int.TryParse(Console.ReadLine(), out power);
                } while (!valid);
                
                // handle assigning toughness
                valid = false;
                do
                {
                    Console.WriteLine("Enter the card's toughness: ");
                    valid = int.TryParse(Console.ReadLine(), out toughness);
                } while (!valid);
                break;
            
            case "n":
                break;
            
            default:
                throw new Exception("error: couldn't parse response for power/toughness");
        }

        
        // handle planeswalkers, they have starting loyalty as a card attribute
        string isPlaneswalker = "";
        int loyalty = -99;
        
        do
        {
            Console.WriteLine("Does the card need starting loyalty added?: (Y/y for yes, N/n for no)");
            isPlaneswalker = (Console.ReadLine()).ToLower();
        } while (isPlaneswalker != "y" && isPlaneswalker != "n");

        
        switch (isPlaneswalker)
        {
            case "y":
                
                // handle assigning loyalty
                bool valid = false;
                do
                {
                    Console.WriteLine("Enter the card's starting loyalty: ");
                    valid = int.TryParse(Console.ReadLine(), out loyalty);
                } while (!valid);
                break;
            
            case "n":
                break;
            
            default:
                throw new Exception("error: couldn't parse response for loyalty");
        }
        
        // handle battles, they have starting defense as a card attribute
        string isBattle = "";
        int defense = -99;
        
        do
        {
            Console.WriteLine("Does the card need starting defense added?: (Y/y for yes, N/n for no)");
            isBattle = (Console.ReadLine()).ToLower();
        } while (isBattle != "y" && isBattle != "n");

        
        switch (isBattle)
        {
            case "y":
                
                // handle assigning loyalty
                bool valid = false;
                do
                {
                    Console.WriteLine("Enter the card's starting defense: ");
                    valid = int.TryParse(Console.ReadLine(), out defense);
                } while (!valid);
                break;
            
            case "n":
                break;
            
            default:
                throw new Exception("error: couldn't parse response for defense");
        }
        
        // build a card object
        Card newCard = new Card(name, manaCost, typeLine, rarityLine, text, flavorText, artist, power, toughness, loyalty, defense);
        // show the card in the terminal, using the classes overridden ToString method
        Console.WriteLine(newCard);
        Cards.Add(newCard);
    }

    public void RemoveCard(Card card)
    {
        Cards.Remove(card);
    }

    // uses the Card classes MatchAttr method to return the first card
    // with an attribute that matches the value passed in during search
    public Card SearchCard()
    {
        // default/null case, will update if we get a match later
        Card searchCard = new Card("", "", "", "", "", "", "", -99, -99, -99, -99);
        
        if (Cards.Count > 0)
        { 
            string[] cardAttrs =
            [
                "Name",
                "ManaCost",
                "Typeline",
                "RarityLine",
                "Text",
                "FlavorText",
                "Artist",
                "Power",
                "Toughness",
                "Loyalty",
                "Defense"
            ];
            Console.WriteLine($"Type a card field, enter one of the following:(type END to exit)\n");
            foreach (string a in cardAttrs)
            {
               Console.WriteLine(a); 
            }
            
            bool valid = false;
            // loop until we get good input
            do
            {
                string? cardAttr = Console.ReadLine();
                if (cardAttr.ToLower() is "end") 
                {
                    // close the loop
                    valid = true;
                    break;
                }

                for (int i = 0; i < cardAttrs.Length; i++)
                {
                    // if the two strings match, set up an actual search using that field
                    if (string.Equals(cardAttr, cardAttrs[i], StringComparison.OrdinalIgnoreCase))
                    {
                        valid = true;

                        // now grab a value to pass into the match method as well
                        string? value;
                        bool isVal = false;

                        do
                        {
                            Console.WriteLine($"Searching by {cardAttr}, enter value to search for:\n");

                            // loop until we get good input
                            value = Console.ReadLine();
                            if (value != null)
                            {
                                // close the loop
                                isVal = true;
                                foreach (Card c in Cards)
                                {
                                    // use the card's match method
                                    if (c.MatchAttr(cardAttr.ToLower(), value))
                                    {
                                        searchCard = c;
                                        break;
                                    }
                                }
                            }

                            if (searchCard.GetName() is "")
                            {
                                Console.WriteLine("No matches found using value given.");
                                break;
                            }
                        } while (!isVal);
                    } 
                }
                if (!valid)
                {
                    Console.WriteLine("error: wrong input detected, try again");
                }
            } while (!valid);
        }

        return searchCard;
    }


    public override string ToString()
    {
        string output = "Collection includes:\n";

        for (int i = 0; i < Cards.Count; i++)
        {
            output += Cards[i].GetName();
            if (i != Cards.Count - 1)
            {
                output += ",\n";
            }
        }

        return output;
    }
}