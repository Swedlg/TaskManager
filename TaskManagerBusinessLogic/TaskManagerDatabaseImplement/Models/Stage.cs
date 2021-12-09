using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerDatabaseImplement.Models
{
    /// <summary>
    /// Этап
    /// </summary>
    public class Stage
    {
        /// <summary>
        /// ID этапа
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Описание этапа
        /// </summary>
        [Required]
        public string StageDescription { get; set; }

        /// <summary>
        /// Дата начала этапа
        /// </summary>
        [Required]
        public DateTime StageStartDate { get; set; }

        /// <summary>
        /// Дата окончания этапа
        /// </summary>
        [Required]
        public DateTime? StageFinishDate { get; set; }

        /// <summary>
        /// Завершен ли этап
        /// </summary>
        [Required]
        public bool isComplited { get; set; }

        /// <summary>
        /// Удален ли этап
        /// </summary>
        [Required]
        public bool isDeleted { get; set; }

        /// <summary>
        /// ID задачи
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Та задача, к которой относится этот этап
        /// </summary>
        public virtual Task Task { get; set; }

        /// <summary>
        /// Разработчики этого этапа
        /// </summary>
        [ForeignKey("StageId")]
        public virtual List<StageDeveloper> StageDevelopers { get; set; }
    }
}
