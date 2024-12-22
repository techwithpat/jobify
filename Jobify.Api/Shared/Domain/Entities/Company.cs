namespace Jobify.Api.Shared.Domain.Entities;

public class Company
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}