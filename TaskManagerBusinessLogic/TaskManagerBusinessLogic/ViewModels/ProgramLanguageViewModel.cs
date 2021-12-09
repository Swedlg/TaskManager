using System.ComponentModel;

namespace TaskManagerBusinessLogic.ViewModels
{
    /// <summary>
    /// Язык программирования
    /// </summary>
    public class ProgramLanguageViewModel
    {

        /// <summary>
        /// ID языка программирования
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название языка программирования
        /// </summary>
        [DisplayName("Название языка программирования")]
        public string LanguageName { get; set; }

        /// <summary>
        /// Описание языка программирования
        /// </summary>
        [DisplayName("Описание языка программирования")]
        public string LanguageDescription { get; set; }
    }
}
