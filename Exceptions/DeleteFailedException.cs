namespace InfoGem.Exceptions;

public class DeleteFailedException : Exception
{
    public DeleteFailedException()
    {
    }

    public DeleteFailedException(string message)
        : base(message)
    {
    }

    public DeleteFailedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}