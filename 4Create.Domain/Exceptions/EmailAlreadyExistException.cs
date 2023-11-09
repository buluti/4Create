namespace _4Create.Domain.Exceptions;
public class  EmailAlreadyExistException : Exception
{
    public EmailAlreadyExistException(string email)
        : base($"The Employee eith email {email} was not found.")
    {
    }
}
