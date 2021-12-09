using System.Collections.Generic;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.ViewModels;

namespace TaskManagerBusinessLogic.Interfaces
{
    /// <summary>
    /// Интерфейс хранилища заказчиков
    /// </summary>
    public interface IEmployersStorage
    {
        /// <summary>
        /// Метод получения полного списка заказчиков
        /// </summary>
        /// <returns> Список заказчиков </returns>
        List<EmployerViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка заказчиков
        /// </summary>
        /// <param name="model"> Модель заказчика </param>
        /// <returns> Список заказчика </returns>
        //List<EmployerViewModel> GetFilteredList(EmployerBindingModel model);

        /// <summary>
        /// Метод получения заказчика
        /// </summary>
        /// <param name="model"> Модель заказчика </param>
        /// <returns> Модель заказчика </returns>
        EmployerViewModel GetElement(EmployerBindingModel model);

        /// <summary>
        /// Добавить нового заказчика
        /// </summary>
        /// <param name="model"> Модель заказчика </param>
        void Insert(EmployerBindingModel model);

        /// <summary>
        /// Обновить заказчика
        /// </summary>
        /// <param name="model"> Модель заказчика </param>
        //void Update(EmployerBindingModel model);

        /// <summary>
        /// Удалить заказчика
        /// </summary>
        /// <param name="model"> Модель заказчика </param>
        //void Delete(EmployerBindingModel model);
    }
}
