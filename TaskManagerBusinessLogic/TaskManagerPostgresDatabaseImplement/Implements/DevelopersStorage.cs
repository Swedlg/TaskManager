using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.Interfaces;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerPostgresDatabaseImplement.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TaskManagerPostgresDatabaseImplement.Implements
{
    public class DevelopersStorage : IDevelopersStorage
    {
        public List<DeveloperViewModel> GetFullList()
        {
            using (var context = new TaskManagerDatabase())
            {
                return context.Developers.Select(rec => new DeveloperViewModel
                {
                    Id = (int)rec.Id,
                    FullNameOfDeveloper = rec.FullNameOfDeveloper,
                    DeveloperPosition = rec.DeveloperPosition,
                    WorkExperience = rec.WorkExperience,
                    isDeleted = rec.isDeleted
                })
                .ToList();
            }
        }


        public List<DeveloperViewModel> GetFilteredList(DeveloperBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskManagerDatabase())
            {
                return context.Developers
                    .Where(rec => rec.FullNameOfDeveloper.Contains(model.FullNameOfDeveloper))
                    .ToList()
                    .Select(rec => new DeveloperViewModel
                    {
                        Id = (int)rec.Id,
                        FullNameOfDeveloper = rec.FullNameOfDeveloper,
                        DeveloperPosition = rec.DeveloperPosition,
                        WorkExperience = rec.WorkExperience,
                        isDeleted = rec.isDeleted
                    })
                    .ToList();
            }
        }


        public DeveloperViewModel GetElement(DeveloperBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskManagerDatabase())
            {
                Developer developer = context.Developers
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.FullNameOfDeveloper == model.FullNameOfDeveloper);
                return developer != null ?
                new DeveloperViewModel
                {
                    Id = (int)developer.Id,
                    FullNameOfDeveloper = developer.FullNameOfDeveloper,
                    DeveloperPosition = developer.DeveloperPosition,
                    WorkExperience = developer.WorkExperience,
                    isDeleted = developer.isDeleted
                } : null;
            }
        }


        public bool LinkProgramLanguage(DeveloperBindingModel developerModel, ProgramLanguageBindingModel programLanguageModel)
        {
            using (var context = new TaskManagerDatabase())
            {

                DeveloperProgramLanguage element = null;

                if (context.DeveloperProgramLanguage.Count() != 0)
                {
                    element = context.DeveloperProgramLanguage.FirstOrDefault(rec => rec.DeveloperId == developerModel.Id && rec.ProgramLanguageId == programLanguageModel.Id);
                }
                if (element != null)
                {
                    return false;
                }
                else
                {
                    context.DeveloperProgramLanguage.Add(new DeveloperProgramLanguage
                    {
                        DeveloperId = (int)developerModel.Id,
                        ProgramLanguageId = (int)programLanguageModel.Id
                    });

                    context.SaveChanges();

                    return true;
                }
            }
        }



        public void Insert(DeveloperBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                try
                {
                    context.Developers.Add(CreateModel(model, new Developer(), context));
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
        }

        public void Update(DeveloperBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Developer element = context.Developers.FirstOrDefault(rec => rec.Id == model.Id || rec.FullNameOfDeveloper == model.FullNameOfDeveloper);
                        if (element == null)
                        {
                            throw new Exception("Разработчик не найден");
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

        public void Delete(DeveloperBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                Developer element = context.Developers.FirstOrDefault(rec => rec.Id == model.Id || rec.FullNameOfDeveloper == model.FullNameOfDeveloper);
                if (element != null)
                {
                    context.Developers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Разработчик не найден");
                }
            }
        }

        private Developer CreateModel(DeveloperBindingModel model, Developer developer, TaskManagerDatabase context)
        {
            developer.FullNameOfDeveloper = model.FullNameOfDeveloper;
            developer.DeveloperPosition = model.DeveloperPosition;
            developer.isDeleted = model.isDeleted;
            developer.WorkExperience = model.WorkExperience;
            return developer;
        }


    }
}
