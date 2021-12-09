namespace TaskManagerBusinessLogic.BindingModels
{
    /// <summary>
    /// Заказчик
    /// </summary>
    public class EmployerBindingModel
    {
        /// <summary>
        /// ID заказчика
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Полное имя закзчика
        /// </summary>
        public string FullNameOfEmployer { get; set; }

        /// <summary>
        /// Логин заказчика (почта)
        /// </summary>
        public string EmployerLogin { get; set; }

        /// <summary>
        /// Пароль заказчика
        /// </summary>
        public string EmployerPassword { get; set; }

        /// <summary>
        /// Удален ли заказчик
        /// </summary>
        public bool isDeleted { get; set; }
    }
}
