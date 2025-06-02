/*
 * Entrypoint into the program
 *
 * Instantiates a Deck/collection object
 * then tracks the object as cards are added/removed
 * allows user to continue input until they choose to exit
 */
namespace TermProject;

class Program
{
    static void Main(string[] args)
    {
        Deck deck = new Deck();
        bool complete = false;
        do
        {
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

            switch (choice)
            {
                // add new card with user entry for each stat line
                case 1:
                    deck.AddCard();
                    break;
                case 2:
                    Card searchCard = deck.SearchCard();
                    if (searchCard.GetName() == "")
                    {
                        // no cards added to collection
                        break;
                    }
                    Console.WriteLine("Delete card?: (Y/y for yes, N/n for no)");
                    valid = false;
                    do
                    {
                        string deleteCard = Console.ReadLine();
                        switch (deleteCard)
                        {
                            case "Y":
                            case "y":
                                deck.RemoveCard(searchCard);
                                Console.WriteLine("\nCard deleted.\n");
                                valid = true;
                                break;
                            case "N":
                            case "n":
                                valid = true;
                                break;
                            default:
                                Console.WriteLine("error: wrong input, try again\n");
                                break;
                        }
                    } while (!valid);

                    break;
                case 3:
                    Console.WriteLine(deck.ToString());
                    break;
                case 4:
                    complete = true;
                    break;
                default:
                    throw new Exception("error: couldn't parse choice from main menu");
                    break;
            }
        } while (!(complete));
    }
}