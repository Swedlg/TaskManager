using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerPostgresDatabaseImplement.Models
{
    public class Employer
    {
        public Employer()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }

        public string FullNameOfEmployer { get; set; }

        public string EmployerLogin { get; set; }

        public string EmployerPassword { get; set; }

        public bool isDeleted { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
