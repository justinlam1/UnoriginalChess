using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.UnitTests;

public class RookTests
{
    private Board _board;

    public RookTests()
    {
        _board = new Board(8);
    }
    
    [Fact]
    public void Rook_Can_Move_In_All_Directions()
    {
        // Arrange
        var rook = new Rook(PlayerColor.White, 3, 3);
        _board.Cells[3, 3].Piece = rook;

        // Act
        var legalMoves = rook.GetLegalMoves(_board);

        // Assert
        Assert.Contains(new Position(4, 3), legalMoves);
        Assert.Contains(new Position(3, 4), legalMoves);
        Assert.Contains(new Position(2, 3), legalMoves);
        Assert.Contains(new Position(3, 2), legalMoves);
    }

    [Fact]
    public void Rook_Cannot_Move_Through_Friendly_Pieces()
    {
        var rook = new Rook(PlayerColor.White, 3, 3);
        var pawn = new Pawn(PlayerColor.White, 3, 4);
        _board.Cells[3, 3].Piece = rook;
        _board.Cells[3, 4].Piece = pawn;

        var legalMoves = rook.GetLegalMoves(_board);
        
        Assert.DoesNotContain(new Position(3, 4), legalMoves);
    }

    [Fact]
    public void Rook_Cannot_Move_Out_Of_Bounds()
    {
        var rook = new Rook(PlayerColor.White, 3, 0);
        _board.Cells[3, 0].Piece = rook;
        
        var legalMoves = rook.GetLegalMoves(_board);
        
        Assert.DoesNotContain(new Position(3, -1), legalMoves);
    }
}