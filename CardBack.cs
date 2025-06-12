namespace TermProject;

public class CardBack : Card 
{
    // default/test constructor
    public string[] ColorIdentity { get; set; }
    public CardBack()
    {
        Name = "Boolean, Legendary Test";
        ColorIdentity = ["White", "Blue"];
        ManaCost = "{W}{U}";
        TypeLine = "Legendary Creature - Weird Tester";
        RarityLine = "Uncommon";
        Text = "Boolean can't be countered.";
        FlavorText = "Don't test me.";
    }
}