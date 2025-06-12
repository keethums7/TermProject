namespace TermProject;

public class CreatureCard : Card
{
    protected int Power { get; set; }
    protected int Toughness { get; set; }

    // Name = name;
    // ManaCost = manaCost;
    // TypeLine = typeLine;
    // RarityLine = rarityLine;
    // Text = text;
    // FlavorText = flavorText;
    // Artist = artist;

    // empty constructor for test cases
    public CreatureCard()
    {
        Name = "Test-thopter";
        ManaCost = "1";
        TypeLine = "Artifact Creature";
        RarityLine = "Uncommon";
        Text = "Hexproof, Flying, Lifelink";
        FlavorText = "\"Thopter sighted!\" - Kase, Veteran Archer";
        Artist = "Art Ist";

        Power = 1;
        Toughness = 1;
    }

}