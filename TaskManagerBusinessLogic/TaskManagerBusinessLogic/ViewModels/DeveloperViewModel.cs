using System.ComponentModel;

namespace TaskManagerBusinessLogic.ViewModels
{
    /// <summary>
    /// Разработчик
    /// </summary>
    public class DeveloperViewModel
    {
        /// <summary>
        /// ID разработчика
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Полное имя разработчика
        /// </summary>
        [DisplayName("Полное имя разработчика")]
        public string FullNameOfDeveloper { get; set; }

        /// <summary>
        /// Должность разработчика
        /// </summary>
        [DisplayName("Должность разработчика")]
        public string DeveloperPosition { get; set; }

        /// <summary>
        /// Опыт работы
        /// </summary>
        [DisplayName("Опыт работы")]
        public int WorkExperience { get; set; }

        /// <summary>
        /// Удален ли разработчик
        /// </summary>
        [DisplayName("Удален ли разработчик")]
        public bool isDeleted { get; set; }
    }
}
