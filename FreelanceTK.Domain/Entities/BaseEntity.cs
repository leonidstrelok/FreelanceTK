using FreelanceTK.Domain.Entities.Enums;
using System.Collections.Generic;

namespace FreelanceTK.Domain.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int Id { get; set; }
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
