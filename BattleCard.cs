namespace TermProject;

public class BattleCard : Card
{
    protected int Defense { get; set; }
    protected CardBack Back  { get; set; }

    // default (empty) constructor
    public BattleCard()
    {
        Name = "Siege of the Tests";
        ManaCost = "2{B}{R}{G}";
        TypeLine = "Battle - Siege";
        RarityLine = "Rare";
        Text =
            "(As a Siege enters, choose an opponent to protect it. You and others can attack it. When it’s defeated, exile it, then cast it transformed.)\nWhen Siege of the Tests enters, create three 2/2 Test creature tokens.";
        FlavorText = "";
        Artist = "Noah Guy";
        Defense = 3;
        CardBack Back = new CardBack();
    }
}