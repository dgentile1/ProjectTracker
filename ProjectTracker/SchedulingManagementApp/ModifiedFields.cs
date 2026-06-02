using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTracker
{
    internal class ModifiedFields
    {
        public Guid TaskGuid { get; set; }
        public string Programmer { get; set; }
        public string ProjectName { get; set; }
        public DateTime? CurrentFinishDate { get; set; }
        public DateTime? UpdatedFinishDate { get; set; }
        public int CurrentPercent { get; set; }
        public int? UpdatedPercent { get; set; }
        public string Notes { get; set; }

        public bool NeedsUpdate =>
            CurrentFinishDate != UpdatedFinishDate ||
            CurrentPercent != UpdatedPercent;

        public bool IsModified =>
           UpdatedFinishDate != null ||
           UpdatedPercent != null ||
           !string.IsNullOrWhiteSpace(Notes);
    }
}
