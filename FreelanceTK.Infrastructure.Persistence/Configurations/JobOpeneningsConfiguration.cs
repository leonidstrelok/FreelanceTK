using FreelanceTK.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceTK.Infrastructure.Persistence.Configurations
{
    public class JobOpeneningsConfiguration : IEntityTypeConfiguration<JobOpenings>
    {
        public void Configure(EntityTypeBuilder<JobOpenings> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Budget).IsRequired();
        }
    }
}
