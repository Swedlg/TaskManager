using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerPostgresDatabaseImplement.Models
{
    public class Developer
    {
        public Developer()
        {
            DeveloperStages = new HashSet<StageDeveloper>();
            DeveloperProgramLanguages = new HashSet<DeveloperProgramLanguage>();
        }

        public int Id { get; set; }

        public string FullNameOfDeveloper { get; set; }

        public string DeveloperPosition { get; set; }

        public int WorkExperience { get; set; }

        public bool isDeleted { get; set; }

        public virtual ICollection<StageDeveloper> DeveloperStages { get; set; }

        public virtual ICollection<DeveloperProgramLanguage> DeveloperProgramLanguages { get; set; }
    }
}
