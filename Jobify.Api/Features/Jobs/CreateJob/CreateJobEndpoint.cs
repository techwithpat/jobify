using MediatR;

namespace Jobify.Api.Features.Jobs.CreateJob;

public static class CreateJobEndpoint
{
    public static void MapCreateJob(this IEndpointRouteBuilder app)
    {
        app.MapPost("/jobs", async (IMediator mediator, JobRequest request) =>
        {
            var command = new CreateJobCommand(request.Title, request.Description, request.CompanyId);
            var jobId = await mediator.Send(command);

            return Results.Created($"/jobs/{jobId}", new { Id = jobId });
        });
    }
}