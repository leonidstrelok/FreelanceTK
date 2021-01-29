using FreelanceTK.Domain.Entities.Enums;
using System.Collections.Generic;

namespace FreelanceTK.Domain.Entities
{
    /// <summary>
    /// Пользователь приложения
    /// </summary>
    public class ApplicationUser : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Почтовый адрес
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Напишите о себе
        /// </summary>
        public string AboutYourself { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public Country Country { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public City City { get; set; }
        /// <summary>
        /// Ваше фото
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Категория
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// Специализация
        /// </summary>
        public Specialization Specialization { get; set; }
        /// <summary>
        /// Фрилансер или Заказчик
        /// </summary>
        public TypeExecutor TypeExecutor { get; set; }
        public string UserId { get; set; }
        /// <summary>
        /// Сообщения пользователя
        /// </summary>
        public IEnumerable<Message> Messages { get; set; }


    }
}
