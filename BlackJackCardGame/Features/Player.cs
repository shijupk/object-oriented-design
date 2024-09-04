using BlackJackCardGame.Abstractions;

namespace BlackJackCardGame.Features;

public class Player : IPlayer
{
    public IHand Hand { get; } = new Hand();

    public virtual void PlayTurn(IGame game)
    {
        // Basic player turn logic
    }
}

public class Dealer : Player
{
    public override void PlayTurn(IGame game)
    {
        while (Hand.CalculateTotal() < 17)
        {
            Console.WriteLine("Dealer hits.");
            var deck = (game as Game)?.Deck;
            if (deck != null)
            {
                Hand.AddCard(deck.DealCard());
            }

            Console.WriteLine($"Dealer's hand: {Hand}");
        }

        Console.WriteLine(Hand.IsBusted() ? "Dealer busts!" : "Dealer stands.");
    }
}