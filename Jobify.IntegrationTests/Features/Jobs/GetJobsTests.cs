using System.Diagnostics;
using System.Net;
using FluentAssertions;
using Jobify.Api.Shared.Data;
using Jobify.IntegrationTests.Factories;
using Jobify.IntegrationTests.Helpers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Jobify.IntegrationTests.Features.Jobs;

public class GetJobsTests(JobifyWebApplicationFactory<Program> factory)
    : IClassFixture<JobifyWebApplicationFactory<Program>>
{
    private readonly HttpClient client = factory.WithWebHostBuilder(builder =>
    {
        builder.ConfigureTestServices(services =>
        {
            var sp = services.BuildServiceProvider();
            
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.EnsureCreated();

            try
            {
                Util.InitializeJobs(db);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error seeding the database: {0}", e.Message);
            }
        });
    }).CreateClient();

    [Fact]
    public async Task GetJobsEndpoint_Return_SuccessResult()
    {
        var response = await client.GetAsync("/jobs");

        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}