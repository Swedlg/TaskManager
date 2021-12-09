using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerDatabaseImplement.Models
{
    /// <summary>
    /// Задача
    /// </summary>
    public class Task
    {
        /// <summary>
        /// ID задачи
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        [Required]
        public string TaskName { get; set; }

        /// <summary>
        /// Дата начала задачи
        /// </summary>
        [Required]
        public DateTime TaskStartDate { get; set; }

        /// <summary>
        /// Дата окончания задачи
        /// </summary>
        [Required]
        public DateTime? TaskFinishDate { get; set; }

        /// <summary>
        /// Удалена ли задача
        /// </summary>
        [Required]
        public bool isDeleted { get; set; }

        /// <summary>
        /// ID заказчика
        /// </summary>
        [Required]
        public int EmployerId { get; set; }

        /// <summary>
        /// Заказчик этой задачи
        /// </summary>
        public virtual Employer Employer { get; set; }

        /// <summary>
        /// Этапы этой задачи
        /// </summary>

        [ForeignKey("TaskId")]
        public virtual List<Stage> Stages { get; set; }
    }
}
