using UnoriginalChess.Entities.Pieces;
using UnoriginalChess.Entities.Exceptions;

namespace UnoriginalChess.Entities;

public class Board
{
    public Cell[,] Cells { get; private set; }
    public int Size { get; private set; }
    public Stack<Move> Moves { get; private set; }

    public Board(int size = 8, bool isEmpty = false)
    {
        Size = size;
        Cells = new Cell[Size, Size];
        Moves = new Stack<Move>();
        
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                Cells[row, column] = new Cell(row, column, null);
            }
        }

        if (!isEmpty)
        {
            InitializeStandardBoard();
        }
        
    }

    private void InitializeStandardBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            Cells[6, i].Piece = new Pawn(PlayerColor.Black, 6, i);
            Cells[1, i].Piece = new Pawn(PlayerColor.White, 1, i);
        }

        Cells[0, 0].Piece = new Rook(PlayerColor.White, 0, 0);
        Cells[0, 1].Piece = new Knight(PlayerColor.White, 0, 1);
        Cells[0, 2].Piece = new Bishop(PlayerColor.White, 0, 2);
        Cells[0, 3].Piece = new Queen(PlayerColor.White, 0, 3);
        Cells[0, 4].Piece = new King(PlayerColor.White, 0, 4);
        Cells[0, 5].Piece = new Bishop(PlayerColor.White, 0, 5);
        Cells[0, 6].Piece = new Knight(PlayerColor.White, 0, 6);
        Cells[0, 7].Piece = new Rook(PlayerColor.White, 0, 7);

        Cells[7, 0].Piece = new Rook(PlayerColor.Black, 7, 0);
        Cells[7, 1].Piece = new Knight(PlayerColor.Black, 7, 1);
        Cells[7, 2].Piece = new Bishop(PlayerColor.Black, 7, 2);
        Cells[7, 3].Piece = new Queen(PlayerColor.Black, 7, 3);
        Cells[7, 4].Piece = new King(PlayerColor.Black, 7, 4);
        Cells[7, 5].Piece = new Bishop(PlayerColor.Black, 7, 5);
        Cells[7, 6].Piece = new Knight(PlayerColor.Black, 7, 6);
        Cells[7, 7].Piece = new Rook(PlayerColor.Black, 7, 7);
    }

    public Piece? GetPieceAt(Position position)
    {
        ValidatePosition(position);
        return Cells[position.Row, position.Column].Piece;
    }

    public void MovePiece(Position start, Position end)
    {
        ValidatePosition(start);
        ValidatePosition(end);

        var piece = Cells[start.Row, start.Column].Piece;
        if (piece == null)
        {
            throw new InvalidMoveException("No piece at the starting position");
        }

        Cells[start.Row, start.Column].Piece = null;
        Cells[end.Row, end.Column].Piece = piece;
        
        var capturedPiece = Cells[end.Row, end.Column].Piece;
        Moves.Push(new Move(start, end, capturedPiece));
    }

    private void ValidatePosition(Position position)
    {
        if (position.Row < 0 || position.Row >= Size || position.Column < 0 || position.Column >= Size)
        {
            throw new InvalidPositionException("Position is out of bounds");
        }
    }
    
    public List<Piece> GetPieces(Player player)
    {
        var pieces = new List<Piece>();

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                var piece = Cells[i, j].Piece;
                if (piece != null && piece.Color == player.Color)
                {
                    pieces.Add(piece);
                }
            }
        }

        return pieces;
    }

    public Position GetKingPosition(Player player)
    {
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                var piece = Cells[row, column].Piece;
                if (piece != null && piece is King && piece.Color == player.Color)
                {
                    return new Position(row, column);
                }
            }
        }

        throw new Exception("The king for the player " + player.Color + " was not found on the board.");
    }
    
    public void UndoMove()
    {
        if (Moves.Count == 0)
        {
            throw new InvalidOperationException("No moves to undo.");
        }

        var lastMove = Moves.Pop();

        // Move the piece back to its original position
        var piece = Cells[lastMove.End.Row, lastMove.End.Column].Piece;
        Cells[lastMove.Start.Row, lastMove.Start.Column].Piece = piece;
        piece.Position = lastMove.Start;

        // If a piece was captured, restore it
        if (lastMove.CapturedPiece != null)
        {
            Cells[lastMove.End.Row, lastMove.End.Column].Piece = lastMove.CapturedPiece;
            lastMove.CapturedPiece.Position = lastMove.End;
        }
        else
        {
            Cells[lastMove.End.Row, lastMove.End.Column].Piece = null;
        }
    }

}