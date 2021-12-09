using System;

namespace TaskManagerBusinessLogic.BindingModels
{
    /// <summary>
    /// Задача
    /// </summary>
    public class TaskBindingModel
    {
        /// <summary>
        /// ID задачи
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Дата начала задачи
        /// </summary>
        public DateTime TaskStartDate { get; set; }

        /// <summary>
        /// Дата окончания задачи
        /// </summary>
        public DateTime? TaskFinishDate { get; set; }

        /// <summary>
        /// Удалена ли задача
        /// </summary>
        public bool isDeleted { get; set; }

        /// <summary>
        /// ID заказчика
        /// </summary>
        public int EmployerId { get; set; }
    }
}
