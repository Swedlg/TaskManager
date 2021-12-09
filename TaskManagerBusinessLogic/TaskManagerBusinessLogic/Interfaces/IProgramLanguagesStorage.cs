using System.Collections.Generic;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.ViewModels;

namespace TaskManagerBusinessLogic.Interfaces
{
    /// <summary>
    /// интерфейс хранилища языков программирования
    /// </summary>
    public interface IProgramLanguagesStorage
    {
        /// <summary>
        /// Метод получения полного списка языков программирования
        /// </summary>
        /// <returns> Список языков программирования </returns>
        List<ProgramLanguageViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка языков программирования
        /// </summary>
        /// <param name="model"> Модель языка программирования </param>
        /// <returns> Список языков программирования </returns>
        List<ProgramLanguageViewModel> GetFilteredList(ProgramLanguageBindingModel model);

        /// <summary>
        /// Метод получения языка программирования
        /// </summary>
        /// <param name="model"> Модель языка программирования </param>
        /// <returns> Модель языка программирования </returns>
        ProgramLanguageViewModel GetElement(ProgramLanguageBindingModel model);

        /// <summary>
        /// Добавить новый язык программирования
        /// </summary>
        /// <param name="model"> Модель языка программирования </param>
        void Insert(ProgramLanguageBindingModel model);

        /// <summary>
        /// Обновить язык программирования
        /// </summary>
        /// <param name="model"> Модель языка программирования </param>
        void Update(ProgramLanguageBindingModel model);

        /// <summary>
        /// Удалить язык программирования
        /// </summary>
        /// <param name="model"> Модель языка программирования </param>
        void Delete(ProgramLanguageBindingModel model);
    }
}
