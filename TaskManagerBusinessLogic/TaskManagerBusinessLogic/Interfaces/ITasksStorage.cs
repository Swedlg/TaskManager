using System.Collections.Generic;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.ViewModels;

namespace TaskManagerBusinessLogic.Interfaces
{
    /// <summary>
    /// Интерфейс хранилища задач
    /// </summary>
    public interface ITasksStorage
    {
        /// <summary>
        /// Метод получения полного списка задач
        /// </summary>
        /// <returns> Список задач </returns>
        List<TaskViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка задач
        /// </summary>
        /// <param name="model"> Модель задачи </param>
        /// <returns> Список задач </returns>
        List<TaskViewModel> GetFilteredList(TaskBindingModel model);

        /// <summary>
        /// Метод получения задачи
        /// </summary>
        /// <param name="model"> Модель задачи </param>
        /// <returns> Модель задачи </returns>
        TaskViewModel GetElement(TaskBindingModel model);

        /// <summary>
        /// Добавить новую задачу
        /// </summary>
        /// <param name="model"> Модель задачи </param>
        void Insert(TaskBindingModel model);

        /// <summary>
        /// Обновить задачу
        /// </summary>
        /// <param name="model"> Модель задачи </param>
        void Update(TaskBindingModel model);

        /// <summary>
        /// Удалить задучу
        /// </summary>
        /// <param name="model"> Модель задачи </param>
        void Delete(TaskBindingModel model);
    }
}
