namespace TermProject;

class Program
{
    static void Main(string[] args)
    {
        Collection deck = new Collection();
        bool valid = false;
        int choice;
        
        do
        {
            Console.WriteLine(@"Choose from among the options below:
                              1. Create an MTG card to add to collection.
                              2. Search collection for a card. (Optional: Delete card)
                              3. List entire collection.
                              4. Exit.");
            
             valid = int.TryParse(Console.ReadLine(), out choice);
        } while (!valid);

        switch(choice)
        {
            // add new card with user entry for each stat line
            case 1: 
                deck.AddCard();
                break;
            case 2:
                // Deck.CardSearch();
                break;
            case 3: 
                Console.WriteLine(deck.ToString());
                break;
            default:
                throw new Exception("error: couldn't parse choice from main menu");
                break;
        }
    }
}