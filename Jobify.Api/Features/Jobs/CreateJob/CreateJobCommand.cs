using MediatR;

namespace Jobify.Api.Features.Jobs.CreateJob;

public record CreateJobCommand(string Title, string Description, int CompanyId) 
    : IRequest<int>;