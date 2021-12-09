using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskManagerDatabaseImplement.Models;

namespace TaskManagerDatabaseImplement
{
    /// <summary>
    /// Класс базы данных таск-менеджера
    /// </summary>
    public class TaskManagerDatabase : DbContext
    {
        /// <summary>
        /// Настраиваем сервер базы данных
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TaskManagerDatabase;Integrated Security=True;MultipleActiveResultSets=True;");    
                //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TaskManager;User Id=swed19;Password=postgres");
            }
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Заказчики
        /// </summary>
        public virtual DbSet<Developer> Developers { set; get; }

        /// <summary>
        /// Разработчики-ЯзыкиПрограммирования
        /// </summary>
        public virtual DbSet<DeveloperProgramLanguage> DeveloperProgramLanguage { set; get; }

        /// <summary>
        /// Заказчики
        /// </summary>
        public virtual DbSet<Employer> Employers { set; get; }

        /// <summary>
        /// Языки программирования
        /// </summary>
        public virtual DbSet<ProgramLanguage> ProgramLanguages { set; get; }

        /// <summary>
        /// Этапы
        /// </summary>
        public virtual DbSet<Stage> Stages { set; get; }

        /// <summary>
        /// Этапы-Разработчики
        /// </summary>
        public virtual DbSet<StageDeveloper> StageDeveloper { set; get; }

        /// <summary>
        /// Задачи
        /// </summary>
        public virtual DbSet<Task> Tasks { set; get; }
    }
}
