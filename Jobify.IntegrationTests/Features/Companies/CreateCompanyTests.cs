using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Jobify.Api.Features.Companies.CreateCompany;
using Jobify.IntegrationTests.Factories;

namespace Jobify.IntegrationTests.Features.Companies;

public class CreateCompanyTests(JobifyWebApplicationFactory<Program> factory)
    : IClassFixture<JobifyWebApplicationFactory<Program>>
{
    [Fact]
    public async Task CreateCompanyEndpoint_Return_CreatedResult()
    {
        // Arrange
        var client = factory.CreateClient();
        var request = new CompanyRequest("Tech Innovators Inc.", "contact@techinnovators.com");
        
        // Act
        var response = await client.PostAsJsonAsync("/companies", request);
        
        //Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}