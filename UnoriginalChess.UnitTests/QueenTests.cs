using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.UnitTests;

public class QueenTests
{
    private Board _board;
    public QueenTests()
    {
        _board = new Board(8);
    }
    
    [Fact]
    public void Queen_Can_Move_In_All_Directions()
    {
        // Arrange
        var queen = new Queen(PlayerColor.White, 3, 3);
        _board.Cells[3, 3].Piece = queen;

        // Act
        var legalMoves = queen.GetLegalMoves(_board);

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
    public void Queen_Cannot_Move_Through_Friendly_Pieces()
    {
        var queen = new Queen(PlayerColor.White, 3, 3);
        var pawn = new Pawn(PlayerColor.White, 3, 4);
        _board.Cells[3, 3].Piece = queen;
        _board.Cells[3, 4].Piece = pawn;

        var legalMoves = queen.GetLegalMoves(_board);
        
        Assert.DoesNotContain(new Position(3, 4), legalMoves);
    }

    [Fact]
    public void Queen_Should_Not_Move_Out_Of_Bounds()
    {
        var queen = new Queen(PlayerColor.White, 3, 0);
        _board.Cells[3, 0].Piece = queen;
        
        var legalMoves = queen.GetLegalMoves(_board);
        
        Assert.DoesNotContain(new Position(3, -1), legalMoves);
        Assert.DoesNotContain(new Position(2, -1), legalMoves);
        Assert.DoesNotContain(new Position(4, -1), legalMoves);
    }
}