using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.UnitTests;

public class PawnTests
{
    private Board board;
    public PawnTests()
    {
        board = new Board(8, 8);
    }
    
    [Fact]
    public void White_Pawn_Cannot_Move_Backwards()
    {
        // Arrange
        var whitePawn = new Pawn(PlayerColor.White, 3, 3);
        board.Cells[3][3].Piece = whitePawn;

        // Act
        var legalMoves = whitePawn.GetLegalMoves(board);

        // Assert
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(2, 3)), legalMoves);
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(1, 3)), legalMoves);
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(2, 2)), legalMoves);
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(2, 4)), legalMoves);
    }

    [Fact]
    public void Black_Pawn_Cannot_Move_Backwards()
    {
        // Arrange
        var blackPawn = new Pawn(PlayerColor.Black, 3, 3);
        board.Cells[3][3].Piece = blackPawn;

        // Act
        var legalMoves = blackPawn.GetLegalMoves(board);

        // Assert
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(4, 3)), legalMoves);
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(5, 3)), legalMoves);
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(4, 2)), legalMoves);
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(4, 4)), legalMoves);
    }

    [Fact]
    public void White_Pawn_Can_Move_Forward_One_Square()
    {
        // Arrange
        var whitePawn = new Pawn(PlayerColor.White, 3, 3);
        board.Cells[3][3].Piece = whitePawn;

        // Act
        var legalMoves = whitePawn.GetLegalMoves(board);

        // Assert
        Assert.Contains(new Move(new Position(3, 3), new Position(4, 3)), legalMoves);
    }

    [Fact]
    public void White_Pawn_Cannot_Move_Through_Friendly_Pieces()
    {
        // Arrange
        var whitePawn = new Pawn(PlayerColor.White, 3, 3);
        var whiteQueen = new Queen(PlayerColor.White, 4, 3);
        board.Cells[3][3].Piece = whitePawn;
        board.Cells[4][3].Piece = whiteQueen;

        // Act
        var legalMoves = whitePawn.GetLegalMoves(board);

        // Assert
        Assert.DoesNotContain(new Move(new Position(3, 3), new Position(4, 3)), legalMoves);
    }

    [Fact]
    public void White_Pawn_Can_Move_Two_Squares_For_First_Move()
    {
        // Arrange
        var whitePawn = new Pawn(PlayerColor.White, 1, 0);
        board.Cells[1][0].Piece = whitePawn;

        // Act
        var legalMoves = whitePawn.GetLegalMoves(board);

        // Assert
        Assert.Contains(new Move(new Position(1, 0), new Position(3, 0)), legalMoves);
        Assert.Contains(new Move(new Position(1, 0), new Position(2, 0)), legalMoves);
    }
}