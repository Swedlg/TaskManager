using TaskManagerBusinessLogic.BusinessLogics;
using TaskManagerBusinessLogic.ViewModels;
using TaskManagerBusinessLogic.Interfaces;
using TaskManagerPostgresDatabaseImplement.Implements;
using System.Windows;
using System.Configuration;
using System;
using Unity;
using Unity.Lifetime;

namespace TaskManagerWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        /// <summary>
        /// Врач, который работает с приложением
        /// </summary>
        public static EmployerViewModel Employer { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = BuildUnityContainer();
            var authWindow = container.Resolve<AuthorizationWindow>();
            authWindow.ShowDialog();
        }

        /// <summary>
        /// Настроить контейнер
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IEmployersStorage, EmployersStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITasksStorage, TasksStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStagesStorage, StagesStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDevelopersStorage, DevelopersStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProgramLanguagesStorage, ProgramLanguagesStorage>(new HierarchicalLifetimeManager());
            
            currentContainer.RegisterType<EmployerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<TaskLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<StageLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<DeveloperLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProgramLanguageLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
