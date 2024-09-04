using BlackJackCardGame.Abstractions;
using BlackJackCardGame.Features;

namespace BlackJackCardGame;

public class Program
{
    public static void Main(string[] args)
    {
        IDeck deck = new Deck();
        var players = new List<IPlayer>
        {
            new Player()
        };

        IGame game = new Game(deck, players);
        game.Start();
    }
}