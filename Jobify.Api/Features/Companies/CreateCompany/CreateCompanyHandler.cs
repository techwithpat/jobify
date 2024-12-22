using Jobify.Api.Shared.Data;
using Jobify.Api.Shared.Domain.Entities;
using MediatR;

namespace Jobify.Api.Features.Companies.CreateCompany;

public class CreateCompanyHandler(ApplicationDbContext db)
    : IRequestHandler<CreateCompanyCommand, int>
{
    public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company
        {
            Name = request.Name,
            Email = request.Email
        };
        db.Companies.Add(company);
        await db.SaveChangesAsync(cancellationToken);
        return company.Id;
    }
}