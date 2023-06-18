using UnoriginalChess.Entities;

namespace UnoriginalChess.UI.Pages;

internal static class Utility
{
    public static Position ToPosition(this string identifier)
    {
        if (identifier.Length != 2)
        {
            throw new ArgumentException("Identifier must be 2 digits in length.");
        }

        if (!int.TryParse(identifier, out int parsed))
        {
            throw new ArgumentException("Identifier cannot be parsed as integer");
        }

        return new Position(parsed / 10, parsed % 10);
    }
}