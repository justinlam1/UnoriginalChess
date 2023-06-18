namespace UnoriginalChess.Entities.Exceptions;

internal class InvalidPositionException : Exception
{
    public InvalidPositionException()
    {
        
    }

    public InvalidPositionException(string message) : base(message)
    {
        
    }

    public InvalidPositionException(string message, Exception innerException)
        : base(message, innerException)
    {
        
    }
}