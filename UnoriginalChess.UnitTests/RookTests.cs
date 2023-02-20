using UnoriginalChess.Pieces;

namespace UnoriginalChess.UnitTests;

public class RookTests
{
    private Board board;

    public RookTests()
    {
        board = new Board(8, 8);
    }
    
    [Fact]
    public void Rook_Can_Move_In_All_Directions()
    {
        // Arrange
        var rook = new Rook(PlayerColor.White, 3, 3);
        board.Cells[3][3].Piece = rook;

        // Act
        var legalMoves = rook.GetLegalMoves(board);

        // Assert
        Assert.Contains(new Move(new Position(3, 3), new Position(4, 3)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(3, 4)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(2, 3)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(3, 2)), legalMoves);
    }

    [Fact]
    public void Rook_Cannot_Move_Through_Friendly_Pieces()
    {
        var rook = new Rook(PlayerColor.White, 3, 3);
        var pawn = new Pawn(PlayerColor.White, 3, 4);
        board.Cells[3][3].Piece = rook;
        board.Cells[3][4].Piece = pawn;

        var legalMoves = rook.GetLegalMoves(board);
        
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(3, 4)), legalMoves);
    }

    [Fact]
    public void Rook_Cannot_Move_Out_Of_Bounds()
    {
        var rook = new Rook(PlayerColor.White, 3, 0);
        board.Cells[3][0].Piece = rook;
        
        var legalMoves = rook.GetLegalMoves(board);
        
        Assert.DoesNotContain(new Move(new Position(3, 0), new Position(3, -1)), legalMoves);
    }
}