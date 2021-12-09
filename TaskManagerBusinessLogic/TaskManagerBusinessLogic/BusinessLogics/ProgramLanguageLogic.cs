using System;
using System.Collections.Generic;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerBusinessLogic.Interfaces;

namespace TaskManagerBusinessLogic.BusinessLogics
{
    /// <summary>
    /// Логика языков программирования
    /// </summary>
    public class ProgramLanguageLogic
    {
        /// <summary>
        /// Хранилище языков программирования
        /// </summary>
        private readonly IProgramLanguagesStorage programLanguagesStorage;

        /// <summary>
        /// Конструктор логики языков программирования
        /// </summary>
        /// <param name="programLanguagesStorage"> Хранилище языков программирования </param>
        public ProgramLanguageLogic(IProgramLanguagesStorage programLanguagesStorage)
        {
            this.programLanguagesStorage = programLanguagesStorage;
        }

        /// <summary>
        /// Получить список языков программирования
        /// </summary>
        /// <param name="model"> Модель языка программирования </param>
        /// <returns> Список языков программирования </returns>
        public List<ProgramLanguageViewModel> Read(ProgramLanguageBindingModel model)
        {
            if (model == null)
            {
                return programLanguagesStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProgramLanguageViewModel>
                {
                    programLanguagesStorage.GetElement(model)
                };
            }
            return programLanguagesStorage.GetFilteredList(model);
        }

        /// <summary>
        /// Создать или обновить языка программирования
        /// </summary>
        /// <param name="model"> Модель зыка программирования </param>
        public void CreateOrUpdate(ProgramLanguageBindingModel model)
        {
            var element = programLanguagesStorage.GetElement(new ProgramLanguageBindingModel
            {
                LanguageName = model.LanguageName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть язык программирования с таким названием");
            }
            if (model.Id.HasValue)
            {
                programLanguagesStorage.Update(model);
            }
            else
            {
                programLanguagesStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить язык программирования
        /// </summary>
        /// <param name="model"> Модель языка программирования </param>
        public void Delete(ProgramLanguageBindingModel model)
        {
            var element = programLanguagesStorage.GetElement(new ProgramLanguageBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Язык программирования не найден");
            }
            programLanguagesStorage.Delete(model);
        }
    }
}
