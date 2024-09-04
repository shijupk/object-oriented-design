using ChessGame.Abstractions;

namespace ChessGame.Features;

public class Player
{
    public string Name { get; private set; }
    public PieceColor Color { get; private set; }

    public Player(string name, PieceColor color)
    {
        Name = name;
        Color = color;
    }
}