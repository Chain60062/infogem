namespace InfoGem.Exceptions;

public class FileIsNotAnImageException : Exception
{
    public FileIsNotAnImageException()
    {
    }

    public FileIsNotAnImageException(string message)
        : base(message)
    {
    }

    public FileIsNotAnImageException(string message, Exception inner)
        : base(message, inner)
    {
    }
}