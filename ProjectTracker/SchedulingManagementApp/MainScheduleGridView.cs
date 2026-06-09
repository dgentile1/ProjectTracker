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
        public string? ProgrammersName { get; set; }
        public DateTime? UpdatedFinishDate { get; set; }

        public int? UpdatedPercent { get; set; }
        public DateTime? TestingStartDate { get; set; }
        public int? TestingPercent { get; set; }
        public bool? ReleasedChecked { get; set; }
        public DateTime? ReleasedDate { get; set; }

        public string Notes { get; set; }

        public bool IsModified =>

            UpdatedFinishDate != null ||
            UpdatedPercent != null ||
            !string.IsNullOrWhiteSpace(Notes);
    }
}
