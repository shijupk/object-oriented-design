namespace ChessGame.Abstractions;

public class King : Piece
{
    public King(PieceColor color, Position position) : base(color, position)
    {
    }

    public override bool IsValidMove(Position newPosition, Board board)
    {
        var xDiff = Math.Abs(Position.X - newPosition.X);
        var yDiff = Math.Abs(Position.Y - newPosition.Y);

        return xDiff <= 1 && yDiff <= 1;
    }
}

public class Queen : Piece
{
    public Queen(PieceColor color, Position position) : base(color, position)
    {
    }

    public override bool IsValidMove(Position newPosition, Board board)
    {
        return new Rook(Color, Position).IsValidMove(newPosition, board) ||
               new Bishop(Color, Position).IsValidMove(newPosition, board);
    }
}

public class Rook : Piece
{
    public Rook(PieceColor color, Position position) : base(color, position)
    {
    }

    public override bool IsValidMove(Position newPosition, Board board)
    {
        return Position.X == newPosition.X || Position.Y == newPosition.Y;
    }
}

public class Bishop : Piece
{
    public Bishop(PieceColor color, Position position) : base(color, position)
    {
    }

    public override bool IsValidMove(Position newPosition, Board board)
    {
        return Math.Abs(Position.X - newPosition.X) == Math.Abs(Position.Y - newPosition.Y);
    }
}

public class Knight : Piece
{
    public Knight(PieceColor color, Position position) : base(color, position)
    {
    }

    public override bool IsValidMove(Position newPosition, Board board)
    {
        var xDiff = Math.Abs(Position.X - newPosition.X);
        var yDiff = Math.Abs(Position.Y - newPosition.Y);

        return (xDiff == 2 && yDiff == 1) || (xDiff == 1 && yDiff == 2);
    }
}

public class Pawn : Piece
{
    public Pawn(PieceColor color, Position position) : base(color, position)
    {
    }

    public override bool IsValidMove(Position newPosition, Board board)
    {
        // Simplified logic: Only allows forward moves, not captures or en passant
        var direction = Color == PieceColor.White ? 1 : -1;
        return Position.Y + direction == newPosition.Y && Position.X == newPosition.X;
    }
}