/*
 * Card object
 *
 * Represents a Magic: The Gathering card object
 * includes a matching method to assist with
 * collection searches for individual cards
 */

namespace TermProject;

public class Card : IBattle, ICreature, IPlaneswalker
{
    protected string Name {get; set;}
    protected string ManaCost  {get; set;}
    protected string TypeLine {get; set;}
    protected string RarityLine { get; set; }
    protected string Text {get; set;}
    protected string FlavorText {get; set;}
    protected string Artist {get; set;}
    protected int MaxWidth {get; set;}
    
    // if we need these, we'll use the interfaces
    // implemented in the class header
    protected int Defense {get; set;}
    protected int Power {get; set;}
    protected int Toughness {get; set;}
    protected int Loyalty {get; set;}}

    public Card(string name, string manaCost, string typeLine, string rarityLine, string text, string flavorText, string artist) 
    {
        Name = name;
        ManaCost = manaCost;
        TypeLine = typeLine;
        RarityLine = rarityLine;
        Text = text;
        FlavorText = flavorText;
        Artist = artist;

        MaxWidth = SetMaxWidth();
    }

    // empty constructor for error handling and unit testing
    public Card()
    {
        Name = "Test Card";
        ManaCost = "{W}{U}{B}{R}{G}";
        TypeLine = "Legendary Sorcery";
        RarityLine = "Mythic Rare";
        Text = "At the beginning of your upkeep, you win the game.";
        FlavorText = "Too easy.";
        Artist = "Noah Guy";
        
        MaxWidth = SetMaxWidth();
    }

    public 

    public string GetName()
    {
        return Name;
    }

    protected int SetMaxWidth()
    {
        // find the longest length among Name+ManaCost, TypeLine, and Artist
        MaxWidth = int.Max(Name.Length + ManaCost.Length, TypeLine.Length); // compare Name+ManaCost vs TypeLine
        MaxWidth = int.Max(MaxWidth, Artist.Length); // compare the max found above with the Artist line
        MaxWidth = int.Max(MaxWidth, 38); // most cards have text lines with length no longer than 38 chars
        return MaxWidth;
    }

    public bool MatchAttr(string searchAttr, string value)
    {
        Console.WriteLine($"Searching {searchAttr} for {value}");
        bool match = false;
        switch (searchAttr)
        {
            case "name":
                if (Name == value)
                {
                    match = true;
                }
                break;
            case "manacost":
                if (ManaCost == value)
                {
                    match = true;
                }
                break;
            case "typeline":
                if (TypeLine == value)
                {
                    match = true;
                }
                break;
            case "rarityline":
                if (RarityLine == value)
                {
                    match = true;
                } 
                break;
            case "text":
                if (Text == value)
                {
                    match = true;
                }
                break;
            case "flavortext":
                if (FlavorText == value)
                {
                    match = true;
                }

                break;
            case "artist":
                if (Artist == value)
                {
                    match = true;
                }
                break;
            default:
                Console.WriteLine("error: wrong input, try again");
                break;
        }
        return match;
    }

    public override string ToString()
    {

        string top = "_";
        string bottom = "=";
        string row = " ";
        
        // // concat underscores to build the top, bottom, and empty rows of each card based on that width
        for (int i = 0; i < MaxWidth; i++)
        {
            top += "_";
            bottom += "=";
            row += " ";
        }
        
        
        // build the card printout string
        string output = $"""
                         {top}__
                        ||{(Name).PadRight(MaxWidth - (ManaCost.Length))} {ManaCost}||
                        ||{top}||
                        ||{row}||
                        ||{row}||
                        ||{row}||
                        ||{row}||
                        ||{top}||
                        ||{TypeLine.PadRight(MaxWidth - RarityLine.Length + 1)}{RarityLine}||
                        ||{Text.PadRight(MaxWidth + 1)}||
                        ||{row}||
                        ||{FlavorText.PadRight(MaxWidth + 1)}||
                        ||{("🖌️" + Artist).PadRight(MaxWidth) + 1}||
                         {bottom}==
                        """;

        return output;
    }
}


// TODO
        /*
         * Still working out the logic for cleanly splitting the text lines and flavorText lines
         * so that they neatly fit within the card frame as defined by the maxWidth
         */
        // string[] lines = Text.Split('\n');
        // string[] flavorLines = FlavorText.Split('\n');
        // string fixedText = "";
        // string fixedFlavorText = "";
        //
        // for (int i = 0; i < lines.GetLength(0); i++)
        // {
        //     // set the left pipe border for each new line
        //     fixedText += "||";
        //     
        //     // if the line doesn't exceed the maxWidth
        //     if (lines[i].Length <= maxWidth - 4)
        //     {
        //         // set the right pipe border
        //         fixedText += lines[i].PadRight(maxWidth - 4) + "||"; // 
        //         // if it's not the final line, add a newline character
        //         if (i != lines.GetLength(0))
        //         {
        //             fixedText += "\n";
        //         }
        //     }
        //     // if the line DOES exceed the maxWidth
        //     else
        //     {
        //         // check if it's safe to split the line or if we're mid-word
        //         string currLine = lines[i];
        //         int lineNo = currLine.Length / maxWidth;
        //         // if there's any remainder, count it as a line (and add it)
        //         lineNo = currLine.Length % maxWidth > 0 ? lineNo + 1 : lineNo;
        //
        //         for (int j = 0; j < lineNo; j++)
        //         {
        //             // getting tricky, we're pulling a substring that
        //             // ranges from the nth maxWidth index  and spans
        //             // one full maxWidth in length, chunking each line
        //             fixedText += currLine.Substring(maxWidth * i, maxWidth) + "||";
        //             
        //             // check if we're on the last "chunk", if not 
        //             // add a new line
        //             if (j != lineNo - 1)
        //             {
        //                 fixedText += "\n";
        //             }
        //         }
        //     }// if the line does exceed the maxWidth
        //     
        // }
        
        // // repeat for flavorText
        // for (int i = 0; i < flavorLines.GetLength(0); i++)
        // {
        //     // set the left pipe border for each new line
        //     fixedFlavorText += "||";
        //     
        //     // if the line doesn't exceed the maxWidth
        //     if (flavorLines[i].Length <= maxWidth - 4)
        //     {
        //         // set the right pipe border
        //         fixedFlavorText += flavorLines[i].PadRight(maxWidth - 4) + "||"; // 
        //         // if it's not the final line, add a newline character
        //         if (i != flavorLines.GetLength(0))
        //         {
        //             fixedFlavorText += "\n";
        //         }
        //     }
        //     // if the line DOES exceed the maxWidth
        //     else
        //     {
        //         // check if it's safe to split the line or if we're mid-word
        //         string currLine = flavorLines[i];
        //         int lineNo = currLine.Length / maxWidth;
        //         // if there's any remainder, count it as a line (and add it)
        //         lineNo = currLine.Length % maxWidth > 0 ? lineNo + 1 : lineNo;
        //
        //         for (int j = 0; j < lineNo; j++)
        //         {
        //             // getting tricky, we're pulling a substring that
        //             // ranges from the nth maxWidth index  and spans
        //             // one full maxWidth in length, chunking each line
        //             fixedFlavorText += currLine.Substring(maxWidth * i, maxWidth) + "||";
        //             
        //             // check if we're on the last "chunk", if not 
        //             // add a new line
        //             if (j != lineNo - 1)
        //             {
        //                 fixedFlavorText += "\n";
        //             }
        //         }
        //     }// if the line does exceed the maxWidth
        //     
        // }
