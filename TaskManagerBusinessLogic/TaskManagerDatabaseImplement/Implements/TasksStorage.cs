using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.Interfaces;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerDatabaseImplement.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TaskManagerDatabaseImplement.Implements
{
    /// <summary>
    /// Реализация хранилища задач
    /// </summary>
    public class TasksStorage : ITasksStorage
    {
        /// <summary>
        /// Метод получения полного списка заказчиков
        /// </summary>
        /// <returns> Список заказчиков </returns>
        public List<TaskViewModel> GetFullList()
        {
            using (var context = new TaskManagerDatabase())
            {
                return context.Tasks.Select(rec => new TaskViewModel
                {
                    Id = (int) rec.Id,
                    TaskName = rec.TaskName,
                    TaskStartDate = rec.TaskStartDate,
                    TaskFinishDate = rec.TaskFinishDate,
                    isDeleted = rec.isDeleted,
                    EmployerId = rec.EmployerId
                })
                .ToList();
            }
        }


        public List<TaskViewModel> GetFilteredList(TaskBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskManagerDatabase())
            {
                return context.Tasks
                    .Where(rec => rec.EmployerId == model.EmployerId)
                    .ToList()
                    .Select(rec => new TaskViewModel
                    {
                        Id = (int) rec.Id,
                        TaskName = rec.TaskName,
                        TaskStartDate = rec.TaskStartDate,
                        TaskFinishDate = rec.TaskFinishDate,
                        isDeleted = rec.isDeleted,
                        EmployerId = rec.EmployerId
                    })
                    .ToList();
            }
        }





        public TaskViewModel GetElement(TaskBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskManagerDatabase())
            {
                Task task = context.Tasks
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.TaskName == model.TaskName);
                return task != null ?
                new TaskViewModel
                {
                    Id = (int) task.Id,
                    TaskName = task.TaskName,
                    TaskStartDate = task.TaskStartDate,
                    TaskFinishDate = task.TaskFinishDate,
                    isDeleted = task.isDeleted,
                    EmployerId = task.EmployerId
                } : null;
            }
        }





        public void Insert(TaskBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                try
                {
                    context.Tasks.Add(CreateModel(model, new Task(), context));
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
        }



        public void Update(TaskBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Task element = context.Tasks.FirstOrDefault(rec => rec.Id == model.Id || rec.TaskName == model.TaskName);
                        if (element == null)
                        {
                            throw new Exception("Задача не найдена");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }





        public void Delete(TaskBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                Task element = context.Tasks.FirstOrDefault(rec => rec.Id == model.Id || rec.TaskName == model.TaskName);
                if (element != null)
                {
                    context.Tasks.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Задача не найдена");
                }
            }
        }

        
        private Task CreateModel(TaskBindingModel model, Task task, TaskManagerDatabase context)
        {
            task.TaskName = model.TaskName;
            task.TaskStartDate = model.TaskStartDate;
            task.TaskFinishDate = model.TaskFinishDate;
            task.isDeleted = model.isDeleted;
            task.EmployerId = model.EmployerId;
            return task;
        }
    }
}
