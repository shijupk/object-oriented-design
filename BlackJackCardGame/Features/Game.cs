using BlackJackCardGame.Abstractions;

namespace BlackJackCardGame.Features;

public class Game(IDeck deck, List<IPlayer> players) : IGame
{
    private readonly Dealer _dealer = new();
    public IDeck Deck { get; } = deck;

    public void Start()
    {
        Console.WriteLine("Starting Black Jack game...");
        DealInitialCards();
        PlayRound();
        End();
    }

    public void PlayRound()
    {
        foreach (var player in players)
        {
            player.PlayTurn(this);
        }

        _dealer.PlayTurn(this);
    }

    public void End()
    {
        Console.WriteLine("Ending the game.");
        foreach (var player in players)
        {
            if (player.Hand.IsBusted())
            {
                Console.WriteLine("Player busted. Dealer wins.");
            }
            else if (_dealer.Hand.IsBusted())
            {
                Console.WriteLine("Dealer busted. Player wins.");
            }
            else
            {
                var playerTotal = player.Hand.CalculateTotal();
                var dealerTotal = _dealer.Hand.CalculateTotal();

                if (playerTotal > dealerTotal)
                {
                    Console.WriteLine("Player wins.");
                }
                else if (playerTotal < dealerTotal)
                {
                    Console.WriteLine("Dealer wins.");
                }
                else
                {
                    Console.WriteLine("It's a tie.");
                }
            }
        }
    }

    private void DealInitialCards()
    {
        foreach (var player in players)
        {
            player.Hand.AddCard(Deck.DealCard());
            player.Hand.AddCard(Deck.DealCard());
        }

        _dealer.Hand.AddCard(Deck.DealCard());
        _dealer.Hand.AddCard(Deck.DealCard());

        foreach (var player in players)
        {
            Console.WriteLine($"Player's hand: {player.Hand}");
        }

        Console.WriteLine($"Dealer's hand: {_dealer.Hand}");
    }
}