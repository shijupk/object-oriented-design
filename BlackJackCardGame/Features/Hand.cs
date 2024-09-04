using BlackJackCardGame.Abstractions;

namespace BlackJackCardGame.Features;

public class Hand : IHand
{
    private readonly List<ICard> _cards = new();

    public void AddCard(ICard card)
    {
        _cards.Add(card);
    }

    public int CalculateTotal()
    {
        var total = 0;
        var aces = 0;

        foreach (var card in _cards)
        {
            if (card.Rank is >= Rank.Two and <= Rank.Ten)
            {
                total += (int)card.Rank;
            }
            else if (card.Rank is >= Rank.Jack and <= Rank.King)
            {
                total += 10;
            }
            else if (card.Rank == Rank.Ace)
            {
                aces++;
                total += 11;
            }
        }

        while (total > 21 && aces > 0)
        {
            total -= 10;
            aces--;
        }

        return total;
    }

    public bool IsBusted()
    {
        return CalculateTotal() > 21;
    }

    public bool HasBlackjack()
    {
        return CalculateTotal() == 21 && _cards.Count == 2;
    }

    public override string ToString()
    {
        return string.Join(", ", _cards);
    }
}