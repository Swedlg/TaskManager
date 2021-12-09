using System;
using System.ComponentModel;

namespace TaskManagerBusinessLogic.ViewModels
{
    /// <summary>
    /// Задача
    /// </summary>
    public class TaskViewModel
    {
        /// <summary>
        /// ID задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        [DisplayName("Название задачи")]
        public string TaskName { get; set; }

        /// <summary>
        /// Дата начала задачи
        /// </summary>
        [DisplayName("Дата начала задачи")]
        public DateTime TaskStartDate { get; set; }

        /// <summary>
        /// Дата окончания задачи
        /// </summary>
        [DisplayName("Дата окончания задачи")]
        public DateTime? TaskFinishDate { get; set; }

        /// <summary>
        /// Удалена ли задача
        /// </summary>
        [DisplayName("Удалена ли задача")]
        public bool isDeleted { get; set; }

        /// <summary>
        /// ID заказчика
        /// </summary>
        [DisplayName("ID заказчика")]
        public int EmployerId { get; set; }
    }
}
