using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.Interfaces;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerDatabaseImplement.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TaskManagerDatabaseImplement.Implements
{
    public class StagesStorage : IStagesStorage
    {
        public List<StageViewModel> GetFullList()
        {
            using (var context = new TaskManagerDatabase())
            {
                return context.Stages.Select(rec => new StageViewModel
                {
                    Id = (int) rec.Id,
                    StageDescription = rec.StageDescription,
                    StageStartDate = rec.StageStartDate,
                    StageFinishDate = rec.StageFinishDate,
                    isDeleted = rec.isDeleted,
                    isComplited = rec.isComplited,
                    TaskId = rec.TaskId
                })
                .ToList();
            }
        }

        

        public List<StageViewModel> GetFilteredList(StageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskManagerDatabase())
            {
                return context.Stages
                    .Where(rec => rec.StageDescription.Contains(model.StageDescription))
                    .ToList()
                    .Select(rec => new StageViewModel
                    {
                        Id = (int) rec.Id,
                        StageDescription = rec.StageDescription,
                        StageStartDate = rec.StageStartDate,
                        StageFinishDate = rec.StageFinishDate,
                        isDeleted = rec.isDeleted,
                        isComplited = rec.isComplited,
                        TaskId = rec.TaskId
                    })
                    .ToList();
            }
        }


        public StageViewModel GetElement(StageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TaskManagerDatabase())
            {
                Stage stage = context.Stages
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.StageDescription == model.StageDescription);
                return stage != null ?
                new StageViewModel
                {
                    Id = (int) stage.Id,
                    StageDescription = stage.StageDescription,
                    StageStartDate = stage.StageStartDate,
                    StageFinishDate = stage.StageFinishDate,
                    isDeleted = stage.isDeleted,
                    isComplited = stage.isComplited,
                    TaskId = stage.TaskId
                } : null;
            }
        }

        public bool LinkDeveloper(StageBindingModel stageModel, DeveloperBindingModel developerModel)
        {
            using (var context = new TaskManagerDatabase())
            {
                StageDeveloper element = context.StageDeveloper.First(rec => rec.StageId == stageModel.Id && rec.DeveloperId == developerModel.Id);

                if (element != null)
                {
                    return false;
                }
                else
                {
                    context.StageDeveloper.Add(new StageDeveloper
                    {
                        StageId = (int) stageModel.Id,
                        DeveloperId = (int) developerModel.Id,
                    });

                    context.SaveChanges();
                    return true;
                }
            }
        }

        public void Insert(StageBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                try
                {
                    context.Stages.Add(CreateModel(model, new Stage(), context));
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
        }

        public void Update(StageBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Stage element = context.Stages.FirstOrDefault(rec => rec.Id == model.Id || rec.StageDescription == model.StageDescription);
                        if (element == null)
                        {
                            throw new Exception("Этап не найден");
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

        public void Delete(StageBindingModel model)
        {
            using (var context = new TaskManagerDatabase())
            {
                Stage element = context.Stages.FirstOrDefault(rec => rec.Id == model.Id || rec.StageDescription == model.StageDescription);
                if (element != null)
                {
                    context.Stages.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Этап не найден");
                }
            }
        }

        private Stage CreateModel(StageBindingModel model, Stage stage, TaskManagerDatabase context)
        {
            stage.StageDescription = model.StageDescription;
            stage.StageStartDate = model.StageStartDate;
            stage.StageFinishDate = model.StageFinishDate;
            stage.isDeleted = model.isDeleted;
            stage.isComplited = model.isComplited;
            stage.TaskId = model.TaskId;
            return stage;
        }

    }
}
