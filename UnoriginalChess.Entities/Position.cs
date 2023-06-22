namespace UnoriginalChess.Entities;

public readonly record struct Position(int Row, int Column);

public static class PositionHelper
{
    public static Position? FromChessCoordinates(string coordinates)
    {
        if (coordinates.Length != 2)
        {
            return null;
        }

        var column = char.ToLower(coordinates[0]) - 'a';
        if (column < 0 || column > 7)
        {
            return null;
        }

        if (!int.TryParse(coordinates[1].ToString(), out var row))
        {
            return null;
        }
        row -= 1;

        if (row < 0 || row > 7)
        {
            return null;
        }

        return new Position(row, column);
    }
}
