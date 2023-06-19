using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.UnitTests;

public class BishopTests
{
    private Board _board;

    public BishopTests()
    {
        _board = new Board(8);
    }
    
    [Fact]
    public void Bishop_Can_Move_In_All_Directions()
    {
        // Arrange
        var bishop = new Bishop(PlayerColor.White, 3, 3);
        _board.Cells[3, 3].Piece = bishop;

        // Act
        var legalMoves = bishop.GetLegalMoves(_board);

        // Assert
        Assert.Contains(new Position(4, 4), legalMoves);
        Assert.Contains(new Position(4, 2), legalMoves);
        Assert.Contains(new Position(2, 2), legalMoves);
        Assert.Contains(new Position(2, 4), legalMoves);
    }
    
    [Fact]
    public void Bishop_Cannot_Move_Through_Friendly_Pieces()
    {
        var bishop = new Bishop(PlayerColor.White, 3, 3);
        var pawn = new Pawn(PlayerColor.White, 4, 4);
        _board.Cells[3, 3].Piece = bishop;
        _board.Cells[4, 4].Piece = pawn;

        var legalMoves = bishop.GetLegalMoves(_board);
        
        Assert.DoesNotContain(new Position(4, 4), legalMoves);
    }

    [Fact]
    public void Bishop_Cannot_Move_Out_Of_Bounds()
    {
        var bishop = new Bishop(PlayerColor.White, 3, 0);
        _board.Cells[3, 0].Piece = bishop;
        
        var legalMoves = bishop.GetLegalMoves(_board);
        
        Assert.DoesNotContain(new Position(4, -1), legalMoves);
        Assert.DoesNotContain(new Position(2, -1), legalMoves);
    }
}