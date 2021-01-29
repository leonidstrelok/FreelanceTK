namespace FreelanceTK.Domain.Entities
{
    /// <summary>
    /// Отзывы фрилансеров
    /// </summary>
    public class ReviewsFreelancer : BaseEntity
    {
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Положительный результат
        /// </summary>
        public int PositiveResult { get; set; }
        /// <summary>
        /// Отрицательный результат
        /// </summary>
        public int NegativeResult { get; set; }
        /// <summary>
        /// Средний результат
        /// </summary>
        public int AverageResult { get; set; }
    }
}
