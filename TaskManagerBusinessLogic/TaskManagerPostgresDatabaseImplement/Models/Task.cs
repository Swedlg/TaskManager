using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerPostgresDatabaseImplement.Models
{
    public class Task
    {

        public Task()
        {
            Stages = new HashSet<Stage>();
        }

        public int Id { get; set; }

        public string TaskName { get; set; }

        public DateTime TaskStartDate { get; set; }

        public DateTime? TaskFinishDate { get; set; }

        public bool isDeleted { get; set; }

        public int EmployerId { get; set; }

        public virtual Employer Employer { get; set; }

        public virtual ICollection<Stage> Stages { get; set; }
    }
}
