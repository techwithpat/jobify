namespace Jobify.Api.Features.Jobs.CreateJob;

public record JobRequest(string Title, string Description, int CompanyId);