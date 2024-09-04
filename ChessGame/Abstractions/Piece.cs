namespace ChessGame.Abstractions;

public enum PieceType
{
    King,
    Queen,
    Rook,
    Bishop,
    Knight,
    Pawn
}

public enum PieceColor
{
    White,
    Black
}

public abstract class Piece
{
    public PieceColor Color { get; private set; }
    public Position Position { get; set; }

    protected Piece(PieceColor color, Position position)
    {
        Color = color;
        Position = position;
    }

    public abstract bool IsValidMove(Position newPosition, Board board);
    public  bool IsValidMove(Position newPosition, Position kingPosition, Board board)
    {
        return true;
    }
}