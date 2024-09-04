using BlackJackCardGame.Abstractions;

namespace BlackJackCardGame.Features;

public class Deck : IDeck
{
    private List<ICard> _cards;

    public Deck()
    {
        _cards = InitializeDeck();
        Shuffle();
    }

    public ICard DealCard()
    {
        var card = _cards.First();
        _cards.RemoveAt(0);
        return card;
    }

    public void Shuffle()
    {
        var rnd = new Random();
        _cards = _cards.OrderBy(x => rnd.Next()).ToList();
    }

    private static List<ICard> InitializeDeck()
    {
        var cards = new List<ICard>();
        foreach (var suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (var rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card((Suit)suit, (Rank)rank));
            }
        }

        return cards;
    }
}