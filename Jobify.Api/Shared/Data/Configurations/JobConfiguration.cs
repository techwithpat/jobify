using Jobify.Api.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobify.Api.Shared.Data.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.Property(j => j.Title).IsRequired().HasMaxLength(100);
        builder.Property(j => j.Description).IsRequired();
        builder.Property(j => j.ApplicationLink).IsRequired().HasMaxLength(500);
    }
}