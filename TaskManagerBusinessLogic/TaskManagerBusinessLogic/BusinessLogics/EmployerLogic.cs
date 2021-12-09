using System;
using System.Collections.Generic;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerBusinessLogic.Interfaces;

namespace TaskManagerBusinessLogic.BusinessLogics
{
    /// <summary>
    /// Логика заказчика
    /// </summary>
    public class EmployerLogic
    {
        /// <summary>
        /// Хранилище заказчиков
        /// </summary>
        private readonly IEmployersStorage  employersStorage;

        /// <summary>
        /// Конструктор логики заказчиков
        /// </summary>
        /// <param name="employersStorage"> Хранилище заказчиков </param>
        public EmployerLogic(IEmployersStorage employersStorage)
        {
            this.employersStorage = employersStorage;
        }

        /// <summary>
        /// Получить список заказчиков (либо одного заказчика)
        /// </summary>
        /// <param name="model"> Модель заказчика </param>
        /// <returns> Список заказчиков </returns>
        public List<EmployerViewModel> Read(EmployerBindingModel model)
        {
            if (model == null)
            {
                return employersStorage.GetFullList();
            }
            if ((model.EmployerLogin != null && model.EmployerLogin != null) || model.Id.HasValue)
            {
                return new List<EmployerViewModel>
                {
                    employersStorage.GetElement(model)
                };
            }
            return null;
        }

        /// <summary>
        /// Создать или обновить заказчика
        /// </summary>
        /// <param name="model"> Модель заказчика </param>
        public void CreateOrUpdate(EmployerBindingModel model)
        {
            var element = employersStorage.GetElement(new EmployerBindingModel
            {
                EmployerLogin = model.EmployerLogin
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть заказчик с таким логином");
            }
            else
            {
                employersStorage.Insert(model);
            }
        }     
    }
}
