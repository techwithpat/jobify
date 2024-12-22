using MediatR;

namespace Jobify.Api.Features.Companies.CreateCompany;

public static class CreateCompanyEndpoint
{
    public static void MapCreateCompany(this IEndpointRouteBuilder app)
    {
        app.MapPost("/companies", async (IMediator mediator, CompanyRequest request) =>
        {
            var command = new CreateCompanyCommand(request.Name, request.Email);
            var companyId = await mediator.Send(command);

            return Results.Created($"/companies/{companyId}", new { Id = companyId });
        });
    }
}