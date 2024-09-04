using ChessGame.Abstractions;

namespace ChessGame.Features;

public class Game
{
    private readonly Player[] players;
    private readonly Board board;
    private int currentPlayerIndex;

    public Game(Player player1, Player player2)
    {
        players = new[] { player1, player2 };
        board = new Board();
        currentPlayerIndex = 0;
    }

    public void Start()
    {
        while (true)
        {
            board.PrintBoard();
            Player currentPlayer = players[currentPlayerIndex];
            Console.WriteLine($"{currentPlayer.Name}'s turn ({currentPlayer.Color})");

            // Check if the current player is in check
            if (board.IsInCheck(currentPlayer.Color))
            {
                Console.WriteLine($"{currentPlayer.Name} is in check!");
            }

            if (board.IsCheckmate(currentPlayer.Color))
            {
                Console.WriteLine($"{currentPlayer.Name} is in checkmate! Game over.");
                return;
            }

            Console.Write("Enter your move (e.g., e2 e4): ");
            string move = Console.ReadLine();
            if (move == null) continue;

            string[] positions = move.Split();
            if (positions.Length != 2)
            {
                Console.WriteLine("Invalid move format. Try again.");
                continue;
            }

            Position from = ParsePosition(positions[0]);
            Position to = ParsePosition(positions[1]);

            Piece piece = board.GetPieceAt(from);
            if (piece == null || piece.Color != currentPlayer.Color)
            {
                Console.WriteLine("Invalid piece selection. Try again.");
                continue;
            }

            if (!piece.IsValidMove(to, board))
            {
                Console.WriteLine("Invalid move. Try again.");
                continue;
            }

            board.MovePiece(from, to);

            // Check for checkmate or stalemate here...

            currentPlayerIndex = (currentPlayerIndex + 1) % 2;
        }
    }

    private Position ParsePosition(string position)
    {
        int x = position[0] - 'a';
        int y = int.Parse(position[1].ToString()) - 1;
        return new Position(x, y);
    }
}
