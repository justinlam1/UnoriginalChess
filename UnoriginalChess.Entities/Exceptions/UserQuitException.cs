namespace UnoriginalChess.Entities.Exceptions;

internal class UserQuitException : Exception
{
    public UserQuitException()
    {
        
    }

    public UserQuitException(string message) : base(message)
    {
        
    }

    public UserQuitException(string message, Exception innerException)
        : base(message, innerException)
    {
        
    }
}