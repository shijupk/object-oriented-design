using ChessGame.Abstractions;
using ChessGame.Features;

namespace ChessGame;

public class Program
{
    public static void Main(string[] args)
    {
        var player1 = new Player("Alice", PieceColor.White);
        var player2 = new Player("Bob", PieceColor.Black);

        var game = new Game(player1, player2);
        game.Start();
    }
}
