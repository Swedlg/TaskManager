using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerDatabaseImplement.Models
{
    /// <summary>
    /// Разработчик
    /// </summary>
    public class Developer
    {
        /// <summary>
        /// ID разработчика
        /// </summary>
        [Required]
        public int? Id { get; set; }

        /// <summary>
        /// Полное имя разработчика
        /// </summary>
        [Required]
        public string FullNameOfDeveloper { get; set; }

        /// <summary>
        /// Должность разработчика
        /// </summary>
        [Required]
        public string DeveloperPosition { get; set; }

        /// <summary>
        /// Опыт работы
        /// </summary>
        [Required]
        public int WorkExperience { get; set; }

        /// <summary>
        /// Удален ли разработчик
        /// </summary>
        [Required]
        public bool isDeleted { get; set; }

        /// <summary>
        /// Этапы этого разработчика
        /// </summary>
        [ForeignKey("DeveloperId")]
        public virtual List<StageDeveloper> DeveloperStages { get; set; }

        /// <summary>
        /// Языки программирования этого разработчика
        /// </summary>
        [ForeignKey("DeveloperId")]
        public virtual List<DeveloperProgramLanguage> DeveloperProgramLanguages { get; set; }
    }
}
