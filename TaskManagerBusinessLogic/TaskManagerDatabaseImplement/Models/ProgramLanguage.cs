using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerDatabaseImplement.Models
{
    /// <summary>
    /// Язык программирования
    /// </summary>
    public class ProgramLanguage
    {
        /// <summary>
        /// ID языка программирования
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Название языка программирования
        /// </summary>
        [Required]
        public string LanguageName { get; set; }

        /// <summary>
        /// Описание языка программирования
        /// </summary>
        [Required]
        public string LanguageDescription { get; set; }

        /// <summary>
        /// Разработчики пишущие на этом языке программирования
        /// </summary>
        [ForeignKey("ProgramLanguageId")]
        public virtual List<DeveloperProgramLanguage> ProgramLanguageDevelopers { get; set; }
    }
}
