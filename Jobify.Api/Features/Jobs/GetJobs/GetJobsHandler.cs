using Jobify.Api.Shared.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jobify.Api.Features.Jobs.GetJobs;

public class GetJobsHandler (ApplicationDbContext db) 
    : IRequestHandler<GetJobsQuery, List<JobResponse>>
{
    public async Task<List<JobResponse>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await db.Jobs
            .AsNoTracking()
            .Include(j => j.Company)    
            .Select(job => new JobResponse(job.Id, job.Title, job.Description, job.Company.Name))
            .ToListAsync(cancellationToken);

        return jobs;
    }
}