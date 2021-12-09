using System;

namespace TaskManagerBusinessLogic.BindingModels
{
    /// <summary>
    /// Этап
    /// </summary>
    public class StageBindingModel
    {
        /// <summary>
        /// ID этапа
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Описание этапа
        /// </summary>
        public string StageDescription { get; set; }

        /// <summary>
        /// Дата начала этапа
        /// </summary>
        public DateTime StageStartDate { get; set; }

        /// <summary>
        /// Дата окончания этапа
        /// </summary>
        public DateTime? StageFinishDate { get; set; }

        /// <summary>
        /// Завершен ли этап
        /// </summary>
        public bool isComplited { get; set; }

        /// <summary>
        /// Удален ли этап
        /// </summary>
        public bool isDeleted { get; set; }

        /// <summary>
        /// ID задачи
        /// </summary>
        public int TaskId { get; set; }
    }
}
