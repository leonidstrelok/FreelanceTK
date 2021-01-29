using System;

namespace FreelanceTK.Domain.Entities
{
    /// <summary>
    /// Открытые вакансии
    /// </summary>
    public class JobOpenings : BaseEntity
    {
        /// <summary>
        /// Название вакансии
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Безопасная сделка
        /// </summary>
        public bool SecureTransaction { get; set; }
        /// <summary>
        /// Бюджет
        /// </summary>
        public double Budget { get; set; }
        /// <summary>
        /// Дата создания 
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Какой заказчик выставил
        /// </summary>
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
