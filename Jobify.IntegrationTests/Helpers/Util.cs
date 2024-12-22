using Jobify.Api.Shared.Data;
using Jobify.Api.Shared.Domain.Entities;

namespace Jobify.IntegrationTests.Helpers;

public static class Util
{
    public static void InitializeJobs(ApplicationDbContext db)
    {
        db.Jobs.AddRange(GetJobs());
        db.SaveChangesAsync();
    }

    private static List<Job> GetJobs()
    {
        var company1 = new Company
        {
            Id = 1,
            Name = "Tech Innovators Inc."
        };

        var company2 = new Company
        {
            Id = 2,
            Name = "Green Solutions Ltd."
        };

        return
        [
            new Job
            {
                Id = 1,
                Title = "Software Engineer",
                Description = "Develop and maintain web applications.",
                CompanyId = company1.Id,
                Company = company1
            },
            new Job
            {
                Id = 2,
                Title = "Environmental Analyst",
                Description = "Analyze environmental impact data and create reports.",
                CompanyId = company2.Id,
                Company = company2
            }
        ];
    }
}