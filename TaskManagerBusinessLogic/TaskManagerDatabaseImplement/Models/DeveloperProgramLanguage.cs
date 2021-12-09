namespace TaskManagerDatabaseImplement.Models
{
    /// <summary>
    /// Разработчик-ЯзыкПрограммирования
    /// </summary>
    public class DeveloperProgramLanguage
    {
        /// <summary>
        /// ID сущности Разработчик-ЯзыкПрограммирования
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID разработчика
        /// </summary>
        public int DeveloperId { get; set; }

        /// <summary>
        /// ID Языка программирования
        /// </summary>
        public int ProgramLanguageId { get; set; }

        /// <summary>
        /// Разработчик
        /// </summary>
        public virtual Developer Developer { get; set; }

        /// <summary>
        /// Язык программирования
        /// </summary>
        public virtual ProgramLanguage ProgramLanguage { get; set; }
    }
}
