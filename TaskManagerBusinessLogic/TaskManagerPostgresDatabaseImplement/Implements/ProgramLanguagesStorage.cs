using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.Interfaces;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerPostgresDatabaseImplement.Models;
using System.Collections.Generic;
using System.Linq;
using System;


namespace TaskManagerPostgresDatabaseImplement.Implements
{
    public class ProgramLanguagesStorage : IProgramLanguagesStorage
    {
        public List<ProgramLanguageViewModel> GetFullList()
        {
            using (var context = new TaskManagerDatabase())
            {
                return context.ProgramLanguages.Select(rec => new ProgramLanguageViewModel
                {
                    Id = (int)rec.Id,
                    LanguageDescription = rec.LanguageDescription,
                    LanguageName = rec.LanguageName
                })
                .ToList();
            }
        }



        public List<ProgramLanguageViewModel> GetFilteredList(ProgramLanguageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskManagerDatabase())
            {
                return context.ProgramLanguages
                    .Where(rec => rec.LanguageName.Contains(model.LanguageName))
                    .ToList()
                    .Select(rec => new ProgramLanguageViewModel
                    {
                        Id = (int)rec.Id,
                        LanguageDescription = rec.LanguageDescription,
                        LanguageName = rec.LanguageName
                    })
                    .ToList();
            }
        }


        public ProgramLanguageViewModel GetElement(ProgramLanguageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskManagerDatabase())
            {
                ProgramLanguage programLanguage = context.ProgramLanguages
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.LanguageName == model.LanguageName);
                return programLanguage != null ?
                new ProgramLanguageViewModel
                {
                    Id = (int)programLanguage.Id,
                    LanguageDescription = programLanguage.LanguageDescription,
                    LanguageName = programLanguage.LanguageName
                } : null;
            }
        }


        public void Insert(ProgramLanguageBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                try
                {
                    context.ProgramLanguages.Add(CreateModel(model, new ProgramLanguage(), context));
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
        }

        public void Update(ProgramLanguageBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ProgramLanguage element = context.ProgramLanguages.FirstOrDefault(rec => rec.Id == model.Id || rec.LanguageName == model.LanguageName);
                        if (element == null)
                        {
                            throw new Exception("Язык программирования не найден");
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

        public void Delete(ProgramLanguageBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                ProgramLanguage element = context.ProgramLanguages.FirstOrDefault(rec => rec.Id == model.Id || rec.LanguageName == model.LanguageName);
                if (element != null)
                {
                    context.ProgramLanguages.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Язык программирования не найден");
                }
            }
        }

        private ProgramLanguage CreateModel(ProgramLanguageBindingModel model, ProgramLanguage programLanguage, TaskManagerDatabase context)
        {
            programLanguage.LanguageName = model.LanguageName;
            programLanguage.LanguageDescription = model.LanguageDescription;
            return programLanguage;
        }
    }
}
