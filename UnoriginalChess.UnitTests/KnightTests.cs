using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.UnitTests;

public class KnightTests
{
    private Board _board;

    public KnightTests()
    {
        _board = new Board(8);
    }
    
    [Fact]
    public void Knight_Can_Move_In_All_Directions()
    {
        // Arrange
        var knight = new Knight(PlayerColor.White, 3, 3);
        _board.Cells[3, 3].Piece = knight;

        // Act
        var legalMoves = knight.GetLegalMoves(_board);

        // Assert
        Assert.Contains(new Position(4, 5), legalMoves);
        Assert.Contains(new Position(5, 4), legalMoves);
        Assert.Contains(new Position(5, 2), legalMoves);
        Assert.Contains(new Position(4, 1), legalMoves);
        Assert.Contains(new Position(2, 1), legalMoves);
        Assert.Contains(new Position(1, 2), legalMoves);
        Assert.Contains(new Position(1, 4), legalMoves);
        Assert.Contains(new Position(2, 5), legalMoves);
    }
    
    [Fact]
    public void Knight_Can_Move_Through_Friendly_Pieces()
    {
        var knight = new Knight(PlayerColor.White, 3, 3);
        var pawn = new Pawn(PlayerColor.White, 3, 4);
        var rook = new Rook(PlayerColor.White, 3, 2);
        var queen = new Queen(PlayerColor.White, 3, 1);
        
        _board.Cells[3, 3].Piece = knight;
        _board.Cells[3, 4].Piece = pawn;
        _board.Cells[3, 2].Piece = rook;
        _board.Cells[3, 1].Piece = queen;

        var legalMoves = knight.GetLegalMoves(_board);
        
        Assert.Contains(new Position(4, 5), legalMoves);
        Assert.Contains(new Position(5, 4), legalMoves);
        Assert.Contains(new Position(5, 2), legalMoves);
        Assert.Contains(new Position(4, 1), legalMoves);
        Assert.Contains(new Position(2, 1), legalMoves);
        Assert.Contains(new Position(1, 2), legalMoves);
        Assert.Contains(new Position(1, 4), legalMoves);
        Assert.Contains(new Position(2, 5), legalMoves);
    }
    
    [Fact]
    public void Knight_Cannot_Move_Out_Of_Bounds()
    {
        var knight = new Knight(PlayerColor.White, 3, 0);
        _board.Cells[3, 0].Piece = knight;
        
        var legalMoves = knight.GetLegalMoves(_board);
        
        Assert.DoesNotContain(new Position(5, -1), legalMoves);
        Assert.DoesNotContain(new Position(4, -2), legalMoves);
        Assert.DoesNotContain(new Position(2, -2), legalMoves);
        Assert.DoesNotContain(new Position(1, -1), legalMoves);
    }
}