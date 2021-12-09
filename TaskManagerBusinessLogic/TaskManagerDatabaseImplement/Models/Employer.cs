using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerDatabaseImplement.Models
{
    /// <summary>
    /// Заказчик
    /// </summary>
    public class Employer
    {
        /// <summary>
        /// ID заказчика
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Полное имя закзчика
        /// </summary>
        [Required]
        public string FullNameOfEmployer { get; set; }

        /// <summary>
        /// Логин заказчика (почта)
        /// </summary>
        [Required]
        public string EmployerLogin { get; set; }

        /// <summary>
        /// Пароль заказчика
        /// </summary>
        [Required]
        public string EmployerPassword { get; set; }

        /// <summary>
        /// Удален ли заказчик
        /// </summary>
        [Required]
        public bool isDeleted { get; set; }

        /// <summary>
        /// Задачи этого заказчика
        /// </summary>

        [ForeignKey("EmployerId")]
        public virtual List<Task> Tasks { get; set; }
    }
}
