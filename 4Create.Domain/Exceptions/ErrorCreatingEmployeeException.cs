namespace _4Create.Domain.Exceptions;

internal class ErrorCreatingEmployeeException : Exception
{
    public ErrorCreatingEmployeeException(string message)
        : base(message)
    {
    }
}