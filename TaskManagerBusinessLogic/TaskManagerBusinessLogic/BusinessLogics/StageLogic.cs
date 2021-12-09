using System;
using System.Collections.Generic;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerBusinessLogic.Interfaces;

namespace TaskManagerBusinessLogic.BusinessLogics
{
    /// <summary>
    /// Логика этапов
    /// </summary>
    public class StageLogic
    {
        /// <summary>
        /// Хранилище этапов
        /// </summary>
        private readonly IStagesStorage stagesStorage;

        /// <summary>
        /// Конструктор логики этапов
        /// </summary>
        /// <param name="stagesStorage"> Хранилище этпов </param>
        public StageLogic(IStagesStorage stagesStorage)
        {
            this.stagesStorage = stagesStorage;
        }

        /// <summary>
        /// Получить список этапов
        /// </summary>
        /// <param name="model"> Модель этапа </param>
        /// <returns> Список этапов </returns>
        public List<StageViewModel> Read(StageBindingModel model)
        {
            if (model == null)
            {
                return stagesStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<StageViewModel>
                {
                    stagesStorage.GetElement(model)
                };
            }
            return stagesStorage.GetFilteredList(model);
        }

        /// <summary>
        /// Метод привязки разработчика к этапу
        /// </summary>
        /// <param name="stageModel"> Модеь этапа </param>
        /// <param name="developerModel"> Моедь разработчика </param>
        /// <returns> Получилось ли привязать </returns>
        public bool LinkDeveloper(StageBindingModel stageModel, DeveloperBindingModel developerModel)
        {
            return stagesStorage.LinkDeveloper(stageModel, developerModel);
        }

        /// <summary>
        /// Создать или обновить этап
        /// </summary>
        /// <param name="model"> Модель этапа </param>
        public void CreateOrUpdate(StageBindingModel model)
        {
            var element = stagesStorage.GetElement(new StageBindingModel
            {
                StageDescription = model.StageDescription
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть этап с таким описанием");
            }
            if (model.Id.HasValue)
            {
                stagesStorage.Update(model);
            }
            else
            {
                stagesStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить этап
        /// </summary>
        /// <param name="model"> Модель этапа </param>
        public void Delete(StageBindingModel model)
        {
            var element = stagesStorage.GetElement(new StageBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Этап не найден");
            }
            stagesStorage.Delete(model);
        }
    }
}
