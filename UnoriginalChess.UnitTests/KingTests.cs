using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.UnitTests;

public class KingTests
{
    private Board _board;
    public KingTests()
    {
        _board = new Board(8);
    }
    
    [Fact]
    public void King_Can_Move_In_All_Directions()
    {
        // Arrange
        var king = new King(PlayerColor.White, 3, 3);
        _board.Cells[3, 3].Piece = king;

        // Act
        var legalMoves = king.GetLegalMoves(_board);

        // Assert
        // Check moves in each direction
        Assert.Contains(new Position(4, 3), legalMoves);
        Assert.Contains(new Position(4, 4), legalMoves);
        Assert.Contains(new Position(3, 4), legalMoves);
        Assert.Contains(new Position(2, 4), legalMoves);
        Assert.Contains(new Position(2, 3), legalMoves);
        Assert.Contains(new Position(2, 2), legalMoves);
        Assert.Contains(new Position(3, 2), legalMoves);
        Assert.Contains(new Position(4, 2), legalMoves);
    }

    [Fact]
    public void King_Cannot_Move_Through_Friendly_Pieces()
    {
        var king = new King(PlayerColor.White, 3, 3);
        var pawn = new Pawn(PlayerColor.White, 3, 4);
        var rook = new Rook(PlayerColor.White, 2, 2);
        
        _board.Cells[3, 3].Piece = king;
        _board.Cells[3, 4].Piece = pawn;
        _board.Cells[2, 2].Piece = rook;

        var legalMoves = king.GetLegalMoves(_board);
        
        Assert.DoesNotContain(new Position(3, 4), legalMoves);
        Assert.DoesNotContain(new Position(2, 2), legalMoves);
    }

    [Fact]
    public void King_Should_Not_Move_Out_Of_Bounds()
    {
        var king = new King(PlayerColor.White, 3, 0);
        _board.Cells[3, 0].Piece = king;
        
        var legalMoves = king.GetLegalMoves(_board);
        
        Assert.DoesNotContain(new Position(3, -1), legalMoves);
        Assert.DoesNotContain(new Position(2, -1), legalMoves);
        Assert.DoesNotContain(new Position(4, -1), legalMoves);
    }
}