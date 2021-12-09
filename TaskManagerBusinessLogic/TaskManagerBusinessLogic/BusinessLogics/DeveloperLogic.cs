using System;
using System.Collections.Generic;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerBusinessLogic.Interfaces;

namespace TaskManagerBusinessLogic.BusinessLogics
{
    /// <summary>
    /// Логика разработчиков
    /// </summary>
    public class DeveloperLogic
    {
        /// <summary>
        /// Хранилище разработчиков
        /// </summary>
        private readonly IDevelopersStorage developersStorage;

        /// <summary>
        /// Конструктор логики разработчиков
        /// </summary>
        /// <param name="developersStorage"> Хранилище разработчиков </param>
        public DeveloperLogic(IDevelopersStorage developersStorage)
        {
            this.developersStorage = developersStorage;
        }

        /// <summary>
        /// Получить список разработчиков
        /// </summary>
        /// <param name="model"> Модель разработчика </param>
        /// <returns> Список разработчиков </returns>
        public List<DeveloperViewModel> Read(DeveloperBindingModel model)
        {
            if (model == null)
            {
                return developersStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DeveloperViewModel>
                {
                    developersStorage.GetElement(model)
                };
            }
            return developersStorage.GetFilteredList(model);
        }

        /// <summary>
        /// метод привязки языка программирования к разработчику
        /// </summary>
        /// <param name="developerModel"> Модель разработчика </param>
        /// <param name="programLanguageModel"> Модель языка программирования </param>
        /// <returns> Получилось ли привязать </returns>
        public bool LinkProgramLanguage(DeveloperBindingModel developerModel, ProgramLanguageBindingModel programLanguageModel)
        {
            return developersStorage.LinkProgramLanguage(developerModel, programLanguageModel);
        }

        /// <summary>
        /// Создать или обновить разрабочтка
        /// </summary>
        /// <param name="model"> Модель разработчика </param>
        public void CreateOrUpdate(DeveloperBindingModel model)
        {
            var element = developersStorage.GetElement(new DeveloperBindingModel
            {
                FullNameOfDeveloper = model.FullNameOfDeveloper
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть разработчик с таким именем");
            }
            if (model.Id.HasValue)
            {
                developersStorage.Update(model);
            }
            else
            {
                developersStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить разработчика
        /// </summary>
        /// <param name="model"> Модель разработчика </param>
        public void Delete(DeveloperBindingModel model)
        {
            var element = developersStorage.GetElement(new DeveloperBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Разработчик не найден");
            }
            developersStorage.Delete(model);
        }
    }
}
