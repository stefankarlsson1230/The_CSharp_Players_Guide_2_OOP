
Card[] deck = new Card[56];

int index = 0;

foreach(CardColor color in Enum.GetValues(typeof(CardColor)))
{
    foreach(CardRank rank in Enum.GetValues(typeof(CardRank)))
    {
        deck[index] = new Card(color, rank);
        index++;
    }
}


foreach(Card card in deck)
{
    Console.WriteLine($"The {card.CardColor} {card.CardRank}");
}





// Classes
internal class Card
{
    // Properties
    public CardColor CardColor { get; }
    public CardRank CardRank { get; }


    // Constructors
    public Card (CardColor color, CardRank rank)
    {
        CardColor = color;
        CardRank = rank;
    }


    // Methods
    public bool IsSymbolCard(Card card)
    {
        return card.CardRank switch
        {
            CardRank.Dollar => true,
            CardRank.Percent => true,
            CardRank.Caret => true,
            CardRank.Ampersand => true,
            _ => false,
        };
    }
}




// Enums
enum CardColor { Red, Green, Blue, Yellow, }
enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand }

