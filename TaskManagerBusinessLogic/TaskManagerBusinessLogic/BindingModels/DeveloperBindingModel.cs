namespace TaskManagerBusinessLogic.BindingModels
{
    /// <summary>
    /// Разработчик
    /// </summary>
    public class DeveloperBindingModel
    {
        /// <summary>
        /// ID разработчика
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Полное имя разработчика
        /// </summary>
        public string FullNameOfDeveloper { get; set; }

        /// <summary>
        /// Должность разработчика
        /// </summary>
        public string DeveloperPosition { get; set; }

        /// <summary>
        /// Опыт работы
        /// </summary>
        public int WorkExperience { get; set; }

        /// <summary>
        /// Удален ли разработчик
        /// </summary>
        public bool isDeleted { get; set; }
    }
}
