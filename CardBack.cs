namespace TermProject;

public class CardBack : Card 
{
    // properties necessary for card backs
    public string[] ColorIdentity { get; set; } = [];
    public Card Front { get; set; } = new Card();

    public CardBack(Card front, string name, string[] colorIdentity, string typeLine, string rarityLine,
        string text, string flavorText, string artist)
    {
        Front = front;
        Name = name;
        ColorIdentity = colorIdentity;
        TypeLine = typeLine;
        RarityLine = rarityLine;
        Text = text;
        FlavorText = flavorText;
        Artist = artist;

        ManaCost = "";
    }
    
    // default/test constructor
    public CardBack()
    {
        Name = "CardBack";
    }

    // interface methods - IBattle
    public Card GetBack()
    {
        return Front;
    }

    public int GetDefense()
    {
        return Defense;
    }

    // unlikely this ever gets used
    public void SetBack(Card front)
    {
        Front = front;
    }

    public void SetDefense(int defense)
    {
        Defense = defense;
    }
    
    // interface methods - ICreature
    public int GetPower()
    {
        return Power;
    }
    
    public int GetToughness()
    {
        return Toughness;
    }

    public void SetPower(int power)
    {
        Power = power;
    }
    
    public void SetToughness(int toughness)
    {
        Toughness = toughness;
    }
    
    // interface methods - IPlaneswalker
    public int GetLoyalty()
    {
        return Loyalty;
    }

    public void SetLoyalty(int loyalty)
    {
        Loyalty = loyalty;
    }
}