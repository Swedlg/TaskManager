using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerPostgresDatabaseImplement.Models
{
    public class Stage
    {
        public Stage()
        {
            StageDevelopers = new HashSet<StageDeveloper>();
        }

        public int Id { get; set; }

        public string StageDescription { get; set; }

        public DateTime StageStartDate { get; set; }

        public DateTime? StageFinishDate { get; set; }

        public bool isComplited { get; set; }

        public bool isDeleted { get; set; }

        public int TaskId { get; set; }

        public virtual Task Task { get; set; }

        public virtual ICollection<StageDeveloper> StageDevelopers { get; set; }
    }
}
