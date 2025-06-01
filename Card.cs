namespace TermProject;

public class Card
{
    private string Artist {get; set;}
    private string FlavorText {get; set;}
    private string ManaCost  {get; set;}
    private string Name {get; set;}
    private string Text {get; set;}
    private string TypeLine {get; set;}
    
    private int Defense {get; set;}
    private int Loyalty {get; set;}
    private int Power {get; set;}
    private int Toughness {get; set;}

    public Card(string artist, string flavorText, string manaCost, string name, string text, string typeLine,
        int defense, int loyalty, int power, int toughness)
    {
        Artist = artist;
        FlavorText = flavorText;
        ManaCost = manaCost;
        Name = name;
        Text = text;
        TypeLine = typeLine;
        
        Defense = defense;
        Loyalty = loyalty;
        Power = power;
        Toughness = toughness;
    }

    public override string ToString()
    {
        int nameLen = Name.Length;
        int manaLen = ManaCost.Length;

        string top = "_";
        string bottom = "=";
        
        // concat underscores to build the top and bottom of each card
        for (int i = 0; i < (nameLen + manaLen + 4); i++)
        {
            top += top;
            bottom += bottom;
        }
        
        Console.WriteLine("top: " + top);
        Console.WriteLine("bottom: " + bottom);

        return "test";
    }
}