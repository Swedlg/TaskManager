namespace TaskManagerBusinessLogic.BindingModels
{
    /// <summary>
    /// Язык программирования
    /// </summary>
    public class ProgramLanguageBindingModel
    {
        /// <summary>
        /// ID языка программирования
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Название языка программирования
        /// </summary>
        public string LanguageName { get; set; }

        /// <summary>
        /// Описание языка программирования
        /// </summary>
        public string LanguageDescription { get; set; }   
    }
}
