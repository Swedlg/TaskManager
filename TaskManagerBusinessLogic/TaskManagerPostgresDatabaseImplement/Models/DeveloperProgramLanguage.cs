using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerPostgresDatabaseImplement.Models
{
    public class DeveloperProgramLanguage
    {
        public int DeveloperId { get; set; }

        public int ProgramLanguageId { get; set; }

        public virtual Developer Developer { get; set; }

        public virtual ProgramLanguage ProgramLanguage { get; set; }
    }
}
