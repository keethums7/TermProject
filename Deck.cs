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
    private List<Card> Cards { get; set; } = [];

    internal Card BuildCard()
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
            Console.WriteLine(
                "Enter the card's mana cost: (for colored \"pips\" enclose them in {} like {R} or {2/U}.\nEnter \"help\" for more details)");
            manaCost = Console.ReadLine();
            if (manaCost != null && manaCost.ToLower() == "help")
            {
                Console.WriteLine(
                    "\nPlease visit: https://scryfall.com/docs/syntax#mana for a guide on mana cost syntax.\n");
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
            Console.WriteLine(
                "Enter the card's rarity - choose one of [common, uncommon, rare, mythic rare]: (must be exact match)");
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

        // TODO - intelligent wrapping for card text and flavor text
        // for the command line printout
        Console.WriteLine(
            "Enter the card's text: (hit enter or ctrl+enter to enter new line)\n*Enter END on a line (without other characters) to finish input*");
        string? text = "";
        string? line;
        do
        {
            // allow for multiline input
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

        Console.WriteLine(
            "Enter the card's flavor text: (the storytelling text beneath the card text)\n*Enter END on a line (without other characters) to finish input*");
        string? flavorText = "";
        string? flavorLine;
        do
        {
            // multiline input
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


        // build a card object
        Card newCard = new Card(name, manaCost, typeLine, rarityLine, text, flavorText, artist);

        // output the card so far,
        // then finish with special cases
        Console.WriteLine(newCard);
        return newCard;
    }
    
    private CardBack BuildBack(Card front)
    {
        Console.WriteLine("Enter the (backside) card's name: ");
        string? name = Console.ReadLine();

        Console.WriteLine("For color identity, enter any combination of colors from among the color pie, separated by newlines: (Enter END on a line (without other characters) to finish entry.)\n- Tip: White, Blue, Black, Red, Green are the colors.");
        string[] colors =
        [
            "white", "blue", "black", "red", "green"
        ];
        string? colorId = "";
        string? line;
        do
        {
            // allow for multiline input
            line = Console.ReadLine();
            if (line != null && line.ToLower() != "end")
            {
                // check if the line typed is a color
                if (colors.Contains(line))
                {
                    colorId += $"{line}, ";
                }
            }
        } while (line.ToLower() != "end");

        if (colorId.Length > 0)
        {
            colorId = colorId.Substring(0, colorId.Length - 1); // remove final comma char
        }
        
        // now colorIdentity is an array of color strings
        string[] colorIdentity = colorId.Split(',');
        
        Console.WriteLine("Enter the card's typeline: (e.g. Creature - Soldier; Sorcery; Planeswalker - Liliana...)");
        string? typeLine = Console.ReadLine();

        // TODO - intelligent wrapping for card text and flavor text
        // for the command line printout
        Console.WriteLine(
            "Enter the card's text: (hit enter or ctrl+enter to enter new line)\n*Enter END on a line (without other characters) to finish input*");
        string? text = "";
        line = "";
        do
        {
            // allow for multiline input
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

        Console.WriteLine(
            "Enter the card's flavor text: (the storytelling text beneath the card text)\n*Enter END on a line (without other characters) to finish input*");
        string? flavorText = "";
        string? flavorLine;
        do
        {
            // multiline input
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

        // build a cardback object
        CardBack back = new CardBack(front, name, colorIdentity, typeLine, front.RarityLine, text, flavorText, front.Artist);

        // output the card so far,
        // then finish with special cases
        Console.WriteLine(back);
        return back;
    }
    
    public void CheckSpecialCases(Card newCard) {
        
        // start checking for the special cases
        string isCreature = "";
        do
            // handle creatures and vehicles, they have power/toughness as a card attribute
        {
            Console.WriteLine("Does the card need power and toughness added?: (Y/y for yes, N/n for no)");
            isCreature = (Console.ReadLine()).ToLower();
        } while (isCreature != "y" && isCreature != "n");


        // handle planeswalkers, they have starting loyalty as a card attribute
        string isPlaneswalker = "";
        do
        {
            Console.WriteLine("Does the card need starting loyalty added?: (Y/y for yes, N/n for no)");
            // correct for lower & uppercase
            isPlaneswalker = (Console.ReadLine()).ToLower();
        } while (isPlaneswalker != "y" && isPlaneswalker != "n");

        // handle battles, they have starting defense as a card attribute
        string isBattle = "";
        do
        {
            Console.WriteLine("Does the card need starting defense added?: (Y/y for yes, N/n for no)");
            isBattle = (Console.ReadLine()).ToLower();
        } while (isBattle != "y" && isBattle != "n");

        // handle double-face cards, they have a CardBack property
        string isDoubleFace = "";
        do
        {
            Console.WriteLine("Does the card need a back-side face added?: (Y/y for yes, N/n for no)");
            isDoubleFace = (Console.ReadLine()).ToLower();
        } while (isDoubleFace != "y" && isDoubleFace != "n");
        
        // grab defense for battles
        if (isBattle == "y")
        {
            bool valid = false;
            do
            {
                Console.WriteLine("Set defense (choose a non-negative integer):");
                valid = int.TryParse(Console.ReadLine(), out int defense);
                
                // check if it's above zero
                valid = (defense >= 0);
                
                // if both conditions are met,
                // update defense
                if (valid)
                {
                    newCard.SetDefense(defense);
                }
            } while (!valid);
        }
        
        // grab power and toughness
        // for creatures
        if (isCreature == "y")
        {
            bool valid = false;
            do
            {
                Console.WriteLine("Set power (choose an integer):");
                valid = int.TryParse(Console.ReadLine(), out int power);
                
                // update power
                if (valid)
                {
                    newCard.SetPower(power);
                }
            } while (!valid);

            // reset the boolean and move to toughness
            valid = false;
            do
            {
                Console.WriteLine("Set toughness (choose an integer):");
                valid = int.TryParse(Console.ReadLine(), out int toughness);
                
                // update defense
                if (valid)
                {
                    newCard.SetToughness(toughness);
                }
            } while (!valid);
        }
        
        // grab loyalty for planeswalkers
        if (isPlaneswalker == "y")
        {
            bool valid = false;
            do
            {
                Console.WriteLine("Set loyalty (choose a non-negative integer):");
                valid = int.TryParse(Console.ReadLine(), out int loyalty);
                
                // update power
                if (valid)
                {
                    newCard.SetLoyalty(loyalty);
                }
            } while (!valid);
        }
        
        // handle double face cards
        if (isDoubleFace == "y")
        {
            CardBack back = BuildBack(newCard);
            newCard.SetBack(back);
        }
        
        // show the card in the terminal, using the classes overridden ToString method
        Console.WriteLine(newCard); 
    }

    public void AddCard(Card card)
    {
        Cards.Add(card);
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
        Card searchCard = new Card();
        
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
            // index of last card is
            // 1 less than count
            if (i != Cards.Count - 1)
            {
                output += ",\n";
            }
        }

        return output;
    }
}