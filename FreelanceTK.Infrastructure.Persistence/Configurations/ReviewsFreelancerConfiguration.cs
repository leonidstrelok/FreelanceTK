using FreelanceTK.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceTK.Infrastructure.Persistence.Configurations
{
    public class ReviewsFreelancerConfiguration : IEntityTypeConfiguration<ReviewsFreelancer>
    {
        public void Configure(EntityTypeBuilder<ReviewsFreelancer> builder)
        {
        }
    }
}
