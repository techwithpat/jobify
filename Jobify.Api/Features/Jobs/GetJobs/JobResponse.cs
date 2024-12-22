namespace Jobify.Api.Features.Jobs.GetJobs;

public sealed record JobResponse(int Id, string Title, string Description, string CompanyName);