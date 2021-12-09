using System;
using System.ComponentModel;

namespace TaskManagerBusinessLogic.ViewModels
{
    /// <summary>
    /// Этап
    /// </summary>
    public class StageViewModel
    {
        /// <summary>
        /// ID этапа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Описание этапа
        /// </summary>
        [DisplayName("Описание этапа")]
        public string StageDescription { get; set; }

        /// <summary>
        /// Дата начала этапа
        /// </summary>
        [DisplayName("Дата начала этапа")]
        public DateTime StageStartDate { get; set; }

        /// <summary>
        /// Дата окончания этапа
        /// </summary>
        [DisplayName("Дата окончания этапа")]
        public DateTime? StageFinishDate { get; set; }

        /// <summary>
        /// Завершен ли этап
        /// </summary>
        [DisplayName("Завершен ли этап")]
        public bool isComplited { get; set; }

        /// <summary>
        /// Удален ли этап
        /// </summary>
        [DisplayName("Удален ли этап")]
        public bool isDeleted { get; set; }

        /// <summary>
        /// ID задачи
        /// </summary>
        [DisplayName("ID задачи")]
        public int TaskId { get; set; }
    }
}
