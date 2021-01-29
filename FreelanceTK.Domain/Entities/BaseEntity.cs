using FreelanceTK.Domain.Entities.Enums;

namespace FreelanceTK.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
}
