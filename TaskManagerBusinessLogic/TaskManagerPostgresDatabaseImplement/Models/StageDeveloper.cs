using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerPostgresDatabaseImplement.Models
{
    public class StageDeveloper
    {
        public int StageId { get; set; }

        public int DeveloperId { get; set; }

        public virtual Stage Stage { get; set; }

        public virtual Developer Developer { get; set; }
    }
}
