namespace TermProject;

public class Collection
{
    private List<Card> Cards { get; set; }

    public void AddCard()
    {
        Console.WriteLine("Enter the card's name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the card's mana cost: (for colored \"pips\" enclose them in <> like <R> or <U>.\nEnter \"help\" for more details)");
        string manaCost = Console.ReadLine();
        Console.WriteLine("Enter the card's text, hold shift and hit enter for new lines when necessary: ");
        string text = Console.ReadLine();
        Console.WriteLine("Enter the card's typeline: (e.g. Creature - Soldier; Artifact; Planeswalker - Liliana...");
        string typeLine = Console.ReadLine();
        Console.WriteLine("Enter the card's flavor text: (the storytelling text beneath the card text");
        string flavorText = Console.ReadLine();
        Console.WriteLine("Enter the artist's name: ");
        string artist = Console.ReadLine();

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
            Console.WriteLine("Does the card need starting loyalty added?: (Y/y for yes, N/n for no)");
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
        
        Card newCard = new Card(artist, flavorText, manaCost, name, text, typeLine, defense, loyalty, power, toughness);
        Cards.Add(newCard);
    }

    public void RemoveCard(Card card)
    {
        Cards.Remove(card);
    }
}