namespace Jobify.Api.Shared.Domain.Entities;

public class Job
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    public string ApplicationLink { get; init; } = string.Empty;

    public int CompanyId { get; set; }
    public Company Company { get; init; }
}