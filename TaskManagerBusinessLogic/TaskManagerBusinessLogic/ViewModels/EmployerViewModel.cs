using System.ComponentModel;

namespace TaskManagerBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказчик
    /// </summary>
    public class EmployerViewModel
    {
        /// <summary>
        /// ID заказчика
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Полное имя закзчика
        /// </summary>
        [DisplayName("Полное имя закзчика")]
        public string FullNameOfEmployer { get; set; }

        /// <summary>
        /// Логин заказчика (почта)
        /// </summary>
        [DisplayName("Логин заказчика (почта)")]
        public string EmployerLogin { get; set; }

        /// <summary>
        /// Пароль заказчика
        /// </summary>
        [DisplayName("Пароль заказчика")]
        public string EmployerPassword { get; set; }

        /// <summary>
        /// Удален ли заказчик
        /// </summary>
        [DisplayName("Удален ли заказчик")]
        public bool isDeleted { get; set; }
    }
}
