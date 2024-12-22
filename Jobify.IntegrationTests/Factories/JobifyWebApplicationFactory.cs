using Jobify.Api.Shared.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jobify.IntegrationTests.Factories;

public class JobifyWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<ApplicationDbContext>));
            
            if(dbContextDescriptor != null)
                services.Remove(dbContextDescriptor);
            
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseInMemoryDatabase("InMemoryDbForTesting"));
        });
        
        builder.UseEnvironment("Development");
    }
}