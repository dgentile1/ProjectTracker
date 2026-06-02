using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTracker
{
    public class MainScheduleGridView
    {
        // From MPP
        public Guid? MSProjectGuid { get; set; }

        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? CurrentFinishDate { get; set; }

        public int CurrentPercent { get; set; }

        // From JSON
        public DateTime? UpdatedFinishDate { get; set; }

        public int? UpdatedPercent { get; set; }

        public double? Duration { get; set; }

        public string Notes { get; set; }

        public bool IsModified =>
            UpdatedFinishDate != null ||
            UpdatedPercent != null ||
            !string.IsNullOrWhiteSpace(Notes);
    }
}
