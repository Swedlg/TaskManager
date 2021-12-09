using System.Collections.Generic;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.ViewModels;

namespace TaskManagerBusinessLogic.Interfaces
{
    /// <summary>
    /// Интерфейс хранилища разработчиков
    /// </summary>
    public interface IDevelopersStorage
    {
        /// <summary>
        /// Метод получения полного списка разработчиков
        /// </summary>
        /// <returns> Список разработчиков </returns>
        List<DeveloperViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка разработчиков
        /// </summary>
        /// <param name="model"> Модель разработчика </param>
        /// <returns> Список разработчиков </returns>
        List<DeveloperViewModel> GetFilteredList(DeveloperBindingModel model);

        /// <summary>
        /// Метод получения разработчика
        /// </summary>
        /// <param name="model"> Модель разработчика </param>
        /// <returns> Модель разработчика </returns>
        DeveloperViewModel GetElement(DeveloperBindingModel model);

        /// <summary>
        /// Метод привязки языка программирования к разработчику
        /// </summary>
        /// <param name="developerModel"> Модель разработчика </param>
        /// <param name="programLanguageModel"> Модель языка программирования </param>
        /// <returns> Удалось ли превязать </returns>
        bool LinkProgramLanguage(DeveloperBindingModel developerModel, ProgramLanguageBindingModel programLanguageModel);

        /// <summary>
        /// Добавить нового разработчика
        /// </summary>
        /// <param name="model"> Модель разработчика </param>
        void Insert(DeveloperBindingModel model);

        /// <summary>
        /// Обновить разработчика
        /// </summary>
        /// <param name="model"> Модель разработчика </param>
        void Update(DeveloperBindingModel model);

        /// <summary>
        /// Удалить разработчика
        /// </summary>
        /// <param name="model"> Модель рзработчика </param>
        void Delete(DeveloperBindingModel model);
    }
}
