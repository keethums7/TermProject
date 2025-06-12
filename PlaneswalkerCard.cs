namespace TermProject;

public class PlaneswalkerCard : Card
{
    protected int Loyalty { get; set; }

    // empty constructor for unit testing
    public PlaneswalkerCard()
    {
        Name = "Test, the Planeswalker";
        ManaCost = "{U}{B}";
        TypeLine = "Planeswalker - Test";
        RarityLine = "Mythic Rare";
        Text = $"""
                +1: {this.Name} Creates a copy of itself, except it has 1 starting loyalty.
                -1: Draw 2 cards, then each player discards a card.
                """;
        FlavorText = "";
        Artist = "Noah Guy";
        Loyalty = 2;
    }

    public override string ToString()
    {
        string cardStr = base.ToString();
        string[] stats = cardStr.Split("\n"); // 
        string bottom = stats[-1];
        stats[-1] = $"||{Loyalty}||";
        return cardStr;
    }
}