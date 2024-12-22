using MediatR;

namespace Jobify.Api.Features.Jobs.GetJobs;

public record GetJobsQuery(): IRequest<List<JobResponse>>;