using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.Interfaces;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerDatabaseImplement.Models;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerDatabaseImplement.Implements
{
    /// <summary>
    /// Реализация хранилища заказчиков
    /// </summary>
    public class EmployersStorage : IEmployersStorage
    {
        /// <summary>
        /// Метод получения полного списка заказчиков
        /// </summary>
        /// <returns> Список заказчиков </returns>
        public List<EmployerViewModel> GetFullList()
        {
            using (var context = new TaskManagerDatabase())
            {
                return context.Employers.Select(rec => new EmployerViewModel
                {
                    Id = (int) rec.Id,
                    FullNameOfEmployer = rec.FullNameOfEmployer,
                    EmployerLogin = rec.EmployerLogin,
                    EmployerPassword = rec.EmployerPassword,
                    isDeleted = rec.isDeleted
                })
                .ToList();
            }
        }

        /// <summary>
        /// Получить заказчика
        /// </summary>
        /// <param name="model"> Модель заказчика </param>
        /// <returns> Заказчик </returns>
        public EmployerViewModel GetElement(EmployerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskManagerDatabase())
            {

                Employer employer = null;

                if (model.Id.HasValue)
                {
                    employer = context.Employers.FirstOrDefault(rec => rec.Id == model.Id);

                }
                if (model.EmployerLogin != null && model.EmployerLogin != null)
                {
                    employer = context.Employers.FirstOrDefault(rec => rec.EmployerLogin == model.EmployerLogin && rec.EmployerPassword == model.EmployerPassword);
                }
                
                return employer != null ?
                new EmployerViewModel
                {
                    Id = (int) employer.Id,
                    FullNameOfEmployer = employer.FullNameOfEmployer,
                    EmployerLogin = employer.EmployerLogin,
                    EmployerPassword = employer.EmployerPassword,
                    isDeleted = employer.isDeleted
                } : null;
            }
        }
         
        /// <summary>
        /// Добавить нового заказчика
        /// </summary>
        /// <param name="model"> Модель заказчика </param>
        public void Insert(EmployerBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                context.Employers.Add(CreateModel(model, new Employer()));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Создать модель заказчика
        /// </summary>
        /// <param name="model"> Модель заказчика </param>
        /// <param name="employer"> Модель заказчика </param>
        /// <returns></returns>
        private Employer CreateModel(EmployerBindingModel model, Employer employer)
        {
            employer.FullNameOfEmployer = model.FullNameOfEmployer;
            employer.EmployerLogin = model.EmployerLogin;
            employer.EmployerPassword = model.EmployerPassword;
            employer.isDeleted = false;
            return employer;
        }
    }
}
