using System.Collections.Generic;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.ViewModels;

namespace TaskManagerBusinessLogic.Interfaces
{
    /// <summary>
    /// Интерфейс хранилища этапов
    /// </summary>
    public interface IStagesStorage
    {
        /// <summary>
        /// Метод получения полного списка этапов
        /// </summary>
        /// <returns> Список этапов </returns>
        List<StageViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка этапов
        /// </summary>
        /// <param name="model"> Модель этапа </param>
        /// <returns> Список этапов </returns>
        List<StageViewModel> GetFilteredList(StageBindingModel model);

        /// <summary>
        /// Метод получения этапа
        /// </summary>
        /// <param name="model"> Модель этапа </param>
        /// <returns> Модель этапа </returns>
        StageViewModel GetElement(StageBindingModel model);

        /// <summary>
        /// Метод привязки разработчика к этапу
        /// </summary>
        /// <param name="StageModel"> Модель этапа </param>
        /// <param name="developerModel"> Модель разработчика </param>
        /// <returns> Удалось ли превязать </returns>
        bool LinkDeveloper(StageBindingModel StageModel, DeveloperBindingModel developerModel);

        /// <summary>
        /// Добавить новый этап
        /// </summary>
        /// <param name="model"> Модель этапа </param>
        void Insert(StageBindingModel model);

        /// <summary>
        /// Обновить этап
        /// </summary>
        /// <param name="model"> Модель этапа </param>
        void Update(StageBindingModel model);

        /// <summary>
        /// Удалить этап
        /// </summary>
        /// <param name="model"> Модель этапа </param>
        void Delete(StageBindingModel model);
    }
}
