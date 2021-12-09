namespace TaskManagerDatabaseImplement.Models
{
    /// <summary>
    /// Этап-Разработчик
    /// </summary>
    public class StageDeveloper
    {
        /// <summary>
        /// ID сущности Этап-Разработчик
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID Этапа
        /// </summary>
        public int StageId { get; set; }

        /// <summary>
        /// ID разработчика
        /// </summary>
        public int DeveloperId { get; set; }

        /// <summary>
        /// Этап
        /// </summary>
        public virtual Stage Stage { get; set; }

        /// <summary>
        /// Разработчик
        /// </summary>
        public virtual Developer Developer { get; set; }
    }
}
