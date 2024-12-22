using Jobify.Api.Shared.Data;
using Jobify.Api.Shared.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jobify.Api.Features.Jobs.CreateJob;

public class CreateJobHandler(ApplicationDbContext db) : IRequestHandler<CreateJobCommand, int>
{
    public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        // Validate that the Company exists
        var companyExists = await db.Companies
            .AnyAsync(c => c.Id == request.CompanyId, cancellationToken);

        if (!companyExists)
        {
            throw new ArgumentException("Invalid CompanyId");
        }

        var job = new Job
        {
            Title = request.Title,
            Description = request.Description,
            CompanyId = request.CompanyId
        };

        db.Jobs.Add(job);
        await db.SaveChangesAsync(cancellationToken);

        return job.Id;
    }
}