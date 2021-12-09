using System;
using System.Collections.Generic;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerBusinessLogic.Interfaces;

namespace TaskManagerBusinessLogic.BusinessLogics
{
    /// <summary>
    /// Логика задачи
    /// </summary>
    public class TaskLogic
    {
        /// <summary>
        /// Хранилище задач
        /// </summary>
        private readonly ITasksStorage tasksStorage;

        /// <summary>
        /// Конструктор логики задач
        /// </summary>
        /// <param name="tasksStorage"> Хранилище задач </param>
        public TaskLogic(ITasksStorage tasksStorage)
        {
            this.tasksStorage = tasksStorage;
        }

        /// <summary>
        /// Получить список задач
        /// </summary>
        /// <param name="model"> Модель задачи </param>
        /// <returns> Список задач </returns>
        public List<TaskViewModel> Read(TaskBindingModel model)
        {
            if (model == null)
            {
                return tasksStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TaskViewModel>
                {
                    tasksStorage.GetElement(model)
                };
            }
            return tasksStorage.GetFilteredList(model);
        }

        /// <summary>
        /// Создать или обновить задачу
        /// </summary>
        /// <param name="model"> Модель задачи </param>
        public void CreateOrUpdate(TaskBindingModel model)
        {
            var element = tasksStorage.GetElement(new TaskBindingModel
            {
                TaskName = model.TaskName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть задача с таким названием");
            }
            if (model.Id.HasValue)
            {
                tasksStorage.Update(model);
            }
            else
            {
                tasksStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="model"> Модель задачи </param>
        public void Delete(TaskBindingModel model)
        {
            var element = tasksStorage.GetElement(new TaskBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Задача не найдена");
            }
            tasksStorage.Delete(model);
        }
    }
}
