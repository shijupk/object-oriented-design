using BlackJackCardGame.Abstractions;

namespace BlackJackCardGame.Features;

public class Card(Suit suit, Rank rank) : ICard
{
    public Suit Suit { get; } = suit;
    public Rank Rank { get; } = rank;

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}