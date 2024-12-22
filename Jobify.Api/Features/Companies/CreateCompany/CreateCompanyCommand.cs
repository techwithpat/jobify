using MediatR;

namespace Jobify.Api.Features.Companies.CreateCompany;

public record CreateCompanyCommand(string Name, string Email) : IRequest<int>;