namespace _4Create.Contracts.Companies

{
    public record CreateCompanyResponse(
        Guid Id,
        string Name,
        DateTime CreatedAt
    );
}