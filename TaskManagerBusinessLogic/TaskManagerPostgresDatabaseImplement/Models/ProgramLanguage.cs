using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerPostgresDatabaseImplement.Models
{
    public class ProgramLanguage
    {
        public ProgramLanguage()
        {
            ProgramLanguageDevelopers = new HashSet<DeveloperProgramLanguage>();
        }

        public int Id { get; set; }

        public string LanguageName { get; set; }

        public string LanguageDescription { get; set; }

        public virtual ICollection<DeveloperProgramLanguage> ProgramLanguageDevelopers { get; set; }
    }
}
