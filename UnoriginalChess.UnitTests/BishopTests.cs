using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.UnitTests;

public class BishopTests
{
    private Board board;

    public BishopTests()
    {
        board = new Board(8, 8);
    }
    
    [Fact]
    public void Bishop_Can_Move_In_All_Directions()
    {
        // Arrange
        var bishop = new Bishop(PlayerColor.White, 3, 3);
        board.Cells[3][3].Piece = bishop;

        // Act
        var legalMoves = bishop.GetLegalMoves(board);

        // Assert
        Assert.Contains(new Move(new Position(3, 3), new Position(4, 4)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(4, 2)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(2, 2)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(2, 4)), legalMoves);
    }
    
    [Fact]
    public void Bishop_Cannot_Move_Through_Friendly_Pieces()
    {
        var bishop = new Bishop(PlayerColor.White, 3, 3);
        var pawn = new Pawn(PlayerColor.White, 4, 4);
        board.Cells[3][3].Piece = bishop;
        board.Cells[4][4].Piece = pawn;

        var legalMoves = bishop.GetLegalMoves(board);
        
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(4, 4)), legalMoves);
    }

    [Fact]
    public void Bishop_Cannot_Move_Out_Of_Bounds()
    {
        var bishop = new Bishop(PlayerColor.White, 3, 0);
        board.Cells[3][0].Piece = bishop;
        
        var legalMoves = bishop.GetLegalMoves(board);
        
        Assert.DoesNotContain(new Move(new Position(3, 0), new Position(4, -1)), legalMoves);
        Assert.DoesNotContain(new Move(new Position(3, 0), new Position(2, -1)), legalMoves);
    }
}