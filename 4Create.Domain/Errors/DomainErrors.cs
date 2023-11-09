using _4Create.Domain.Shared;

namespace _4Create.Domain.Errors;

public static class DomainErrors
{
    public static class Member
    {
        public static readonly Error EmailAlreadyInUse = new Error(
            "CreateCompany.EmailIsNotUnique", "The email you have specified already exists");
    }
}
