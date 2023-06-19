using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.UnitTests;

public class PawnTests
{
    private Board _board;
    public PawnTests()
    {
        _board = new Board(8);
    }
    
    [Fact]
    public void White_Pawn_Cannot_Move_Backwards()
    {
        // Arrange
        var whitePawn = new Pawn(PlayerColor.White, 3, 3);
        _board.Cells[3, 3].Piece = whitePawn;

        // Act
        var legalMoves = whitePawn.GetLegalMoves(_board);

        // Assert
        Assert.DoesNotContain(new Position(2, 3), legalMoves);
        Assert.DoesNotContain(new Position(1, 3), legalMoves);
        Assert.DoesNotContain(new Position(2, 2), legalMoves);
        Assert.DoesNotContain(new Position(2, 4), legalMoves);
    }

    [Fact]
    public void Black_Pawn_Cannot_Move_Backwards()
    {
        // Arrange
        var blackPawn = new Pawn(PlayerColor.Black, 3, 3);
        _board.Cells[3, 3].Piece = blackPawn;

        // Act
        var legalMoves = blackPawn.GetLegalMoves(_board);

        // Assert
        Assert.DoesNotContain(new Position(4, 3), legalMoves);
        Assert.DoesNotContain(new Position(5, 3), legalMoves);
        Assert.DoesNotContain(new Position(4, 2), legalMoves);
        Assert.DoesNotContain(new Position(4, 4), legalMoves);
    }

    [Fact]
    public void White_Pawn_Can_Move_Forward_One_Square()
    {
        // Arrange
        var whitePawn = new Pawn(PlayerColor.White, 3, 3);
        _board.Cells[3, 3].Piece = whitePawn;

        // Act
        var legalMoves = whitePawn.GetLegalMoves(_board);

        // Assert
        Assert.Contains(new Position(4, 3), legalMoves);
    }

    [Fact]
    public void White_Pawn_Cannot_Move_Through_Friendly_Pieces()
    {
        // Arrange
        var whitePawn = new Pawn(PlayerColor.White, 3, 3);
        var whiteQueen = new Queen(PlayerColor.White, 4, 3);
        _board.Cells[3, 3].Piece = whitePawn;
        _board.Cells[4, 3].Piece = whiteQueen;

        // Act
        var legalMoves = whitePawn.GetLegalMoves(_board);

        // Assert
        Assert.DoesNotContain(new Position(4, 3), legalMoves);
    }

    [Fact]
    public void White_Pawn_Can_Move_Two_Squares_For_First_Move()
    {
        // Arrange
        var whitePawn = new Pawn(PlayerColor.White, 1, 0);
        _board.Cells[1, 0].Piece = whitePawn;

        // Act
        var legalMoves = whitePawn.GetLegalMoves(_board);

        // Assert
        Assert.Contains(new Position(3, 0), legalMoves);
        Assert.Contains(new Position(2, 0), legalMoves);
    }
}