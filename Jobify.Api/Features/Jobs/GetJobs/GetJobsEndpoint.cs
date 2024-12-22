using MediatR;

namespace Jobify.Api.Features.Jobs.GetJobs;

public static class GetJobsEndpoint
{
    public static void MapGetJobs(this IEndpointRouteBuilder app)
    {
        app.MapGet("/jobs", async (IMediator mediator) =>
        {
            var query = new GetJobsQuery();
            var jobs = await mediator.Send(query);

            return Results.Ok(jobs);
        });
    }
}