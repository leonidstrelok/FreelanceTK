using System;

namespace FreelanceTK.Domain.Entities
{
    /// <summary>
    /// Сообщения
    /// </summary>
    public class Message : BaseEntity
    {
        /// <summary>
        /// Сообщение
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Дата создания сообщения
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Фильтрация сообщений
        /// </summary>
        public FilterMessage FilterMessage { get; set; }


        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
