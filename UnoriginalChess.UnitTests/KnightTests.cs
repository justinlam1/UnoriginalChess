using UnoriginalChess.Pieces;

namespace UnoriginalChess.UnitTests;

public class KnightTests
{
    private Board board;

    public KnightTests()
    {
        board = new Board(8, 8, true);
    }
    
    [Fact]
    public void Knight_Can_Move_In_All_Directions()
    {
        // Arrange
        var knight = new Knight(PlayerColor.White, 3, 3);
        board.Cells[3][3].Piece = knight;

        // Act
        var legalMoves = knight.GetLegalMoves(board);

        // Assert
        Assert.Contains(new Move(new Position(3, 3), new Position(4, 5)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(5, 4)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(5, 2)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(4, 1)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(2, 1)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(1, 2)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(1, 4)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(2, 5)), legalMoves);
    }
    
    [Fact]
    public void Knight_Can_Move_Through_Friendly_Pieces()
    {
        var knight = new Knight(PlayerColor.White, 3, 3);
        var pawn = new Pawn(PlayerColor.White, 3, 4);
        var rook = new Rook(PlayerColor.White, 3, 2);
        var queen = new Queen(PlayerColor.White, 3, 1);
        
        board.Cells[3][3].Piece = knight;
        board.Cells[3][4].Piece = pawn;
        board.Cells[3][2].Piece = rook;
        board.Cells[3][1].Piece = queen;

        var legalMoves = knight.GetLegalMoves(board);
        
        Assert.Contains(new Move(new Position(3, 3), new Position(4, 5)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(5, 4)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(5, 2)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(4, 1)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(2, 1)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(1, 2)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(1, 4)), legalMoves);
        Assert.Contains(new Move(new Position(3, 3), new Position(2, 5)), legalMoves);
    }
    
    [Fact]
    public void Knight_Cannot_Move_Out_Of_Bounds()
    {
        var knight = new Knight(PlayerColor.White, 3, 0);
        board.Cells[3][0].Piece = knight;
        
        var legalMoves = knight.GetLegalMoves(board);
        
        Assert.DoesNotContain(new Move(new Position(3, 0), new Position(5, -1)), legalMoves);
        Assert.DoesNotContain(new Move(new Position(3, 0), new Position(4, -2)), legalMoves);
        Assert.DoesNotContain(new Move(new Position(3, 0), new Position(2, -2)), legalMoves);
        Assert.DoesNotContain(new Move(new Position(3, 0), new Position(1, -1)), legalMoves);
    }
}