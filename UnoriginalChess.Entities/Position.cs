namespace UnoriginalChess.Entities;

public readonly record struct Position(int Row, int Column)
{
    public static Position FromChessCoordinates(string? coordinates)
    {
        if (coordinates == null)
        {
            throw new ArgumentNullException();
        }

        if (coordinates.Length != 2)
        {
            throw new ArgumentException("Coordinates must have 2 values.");
        }

        var column = char.ToLower(coordinates[0]) - 'a';
        if (column < 0 || column > 7)
        {
            throw new ArgumentException("Column out of bounds.");
        }

        if (!int.TryParse(coordinates[1].ToString(), out var row))
        {
            throw new ArgumentException("Coordinates have invalid format");
        }
        row -= 1;

        if (row < 0 || row > 7)
        {
            throw new ArgumentException("Row out of bounds");
        }

        return new Position(row, column);
    }
    
    public static string ToChessCoordinates(Position position)
    {
        if (position.Row < 0 || position.Row > 7 || position.Column < 0 || position.Column > 7)
        {
            throw new ArgumentOutOfRangeException("Position is out of range for a standard chess board.");
        }

        char columnLetter = (char)(position.Column + 'A');
        int rowNumber = position.Row + 1;  // 1-based indexing for the chess board rows

        return columnLetter + rowNumber.ToString();
    }
}
