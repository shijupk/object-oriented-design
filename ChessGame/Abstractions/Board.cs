namespace ChessGame.Abstractions;

public class Board
{
    private readonly Piece[,] grid;

    public Board()
    {
        grid = new Piece[8, 8];
        InitializePieces();
    }

    public Piece GetPieceAt(Position position)
    {
        return grid[position.X, position.Y];
    }

    public void MovePiece(Position from, Position to)
    {
        Piece piece = GetPieceAt(from);

        if (piece != null && piece.IsValidMove(to, this))
        {
            grid[to.X, to.Y] = piece;
            grid[from.X, from.Y] = null;
            piece.Position = to;
        }
    }

    public bool IsInCheck(PieceColor kingColor)
    {
        Position kingPosition = FindKing(kingColor);

        foreach (var piece in grid)
        {
            if (piece != null && piece.Color != kingColor && piece.IsValidMove(piece.Position, kingPosition,this))
            {
                return true;
            }
        }

        return false;
    }

    public bool IsCheckmate(PieceColor kingColor)
    {
        if (!IsInCheck(kingColor))
        {
            return false;
        }

        Position kingPosition = FindKing(kingColor);

        // Try to move the king to any of the surrounding positions
        for (int x = Math.Max(0, kingPosition.X - 1); x <= Math.Min(7, kingPosition.X + 1); x++)
        {
            for (int y = Math.Max(0, kingPosition.Y - 1); y <= Math.Min(7, kingPosition.Y + 1); y++)
            {
                Position newPosition = new Position(x, y);
                if (newPosition.Equals(kingPosition))
                    continue;

                Piece originalPiece = GetPieceAt(newPosition);
                MovePiece(kingPosition, newPosition);

                if (!IsInCheck(kingColor))
                {
                    // Undo move
                    MovePiece(newPosition, kingPosition);
                    grid[newPosition.X, newPosition.Y] = originalPiece;
                    return false;
                }

                // Undo move
                MovePiece(newPosition, kingPosition);
                grid[newPosition.X, newPosition.Y] = originalPiece;
            }
        }

        // Check if any piece can block the check or capture the threatening piece
        foreach (var piece in grid)
        {
            if (piece != null && piece.Color == kingColor)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        Position from = piece.Position;
                        Position to = new Position(x, y);
                        Piece originalPiece = GetPieceAt(to);

                        if (piece.IsValidMove(to, this))
                        {
                            MovePiece(from, to);
                            if (!IsInCheck(kingColor))
                            {
                                // Undo move
                                MovePiece(to, from);
                                grid[to.X, to.Y] = originalPiece;
                                return false;
                            }
                            // Undo move
                            MovePiece(to, from);
                            grid[to.X, to.Y] = originalPiece;
                        }
                    }
                }
            }
        }

        return true; // Checkmate detected
    }

    private Position FindKing(PieceColor kingColor)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Piece piece = grid[x, y];
                if (piece is King && piece.Color == kingColor)
                {
                    return new Position(x, y);
                }
            }
        }

        throw new Exception("King not found");
    }
    private void InitializePieces()
    {
        // Place all pawns
        for (int i = 0; i < 8; i++)
        {
            grid[i, 1] = new Pawn(PieceColor.White, new Position(i, 1));
            grid[i, 6] = new Pawn(PieceColor.Black, new Position(i, 6));
        }

        // Place Rooks
        grid[0, 0] = new Rook(PieceColor.White, new Position(0, 0));
        grid[7, 0] = new Rook(PieceColor.White, new Position(7, 0));
        grid[0, 7] = new Rook(PieceColor.Black, new Position(0, 7));
        grid[7, 7] = new Rook(PieceColor.Black, new Position(7, 7));

        // Place Knights
        grid[1, 0] = new Knight(PieceColor.White, new Position(1, 0));
        grid[6, 0] = new Knight(PieceColor.White, new Position(6, 0));
        grid[1, 7] = new Knight(PieceColor.Black, new Position(1, 7));
        grid[6, 7] = new Knight(PieceColor.Black, new Position(6, 7));

        // Place Bishops
        grid[2, 0] = new Bishop(PieceColor.White, new Position(2, 0));
        grid[5, 0] = new Bishop(PieceColor.White, new Position(5, 0));
        grid[2, 7] = new Bishop(PieceColor.Black, new Position(2, 7));
        grid[5, 7] = new Bishop(PieceColor.Black, new Position(5, 7));

        // Place Queens
        grid[3, 0] = new Queen(PieceColor.White, new Position(3, 0));
        grid[3, 7] = new Queen(PieceColor.Black, new Position(3, 7));

        // Place Kings
        grid[4, 0] = new King(PieceColor.White, new Position(4, 0));
        grid[4, 7] = new King(PieceColor.Black, new Position(4, 7));
    }
    public void PrintBoard()
    {
        for (int y = 7; y >= 0; y--)
        {
            for (int x = 0; x < 8; x++)
            {
                Piece piece = grid[x, y];
                if (piece == null)
                {
                    Console.Write(". ");
                }
                else
                {
                    string symbol = piece switch
                    {
                        King => "K",
                        Queen => "Q",
                        Rook => "R",
                        Bishop => "B",
                        Knight => "N",
                        Pawn => "P",
                        _ => "?"
                    };
                    Console.Write($"{(piece.Color == PieceColor.White ? symbol : symbol.ToLower())} ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
