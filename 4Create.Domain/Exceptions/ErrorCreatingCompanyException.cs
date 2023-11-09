namespace _4Create.Domain.Exceptions;

internal class ErrorCreatingCompanyException : Exception
{
    public ErrorCreatingCompanyException(string message)
        : base(message)
    {
    }
}
