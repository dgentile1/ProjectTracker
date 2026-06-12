using System;

namespace ProjectTracker
{
    public class MainScheduleGridView
    {
        // From MPP
        public Guid? MSProjectGuid { get; set; }
        public string? ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CurrentFinishDate { get; set; }
        public int? CurrentPercent { get; set; }

        // From JSON
        public string? ProgrammersName { get; set; }
        public DateTime? UpdatedStartDate { get; set; }
        public DateTime? UpdatedFinishDate { get; set; }
        public DateTime? UpdatedTestingStartDate { get; set; }
        public int? UpdatedPercent { get; set; }
        public DateTime? TestingStartDate { get; set; }
        public int? TestingRounds { get; set; }
        public bool? ReleasedChecked { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string? Notes { get; set; }
        public string? TrelloUrl { get; set; }
        public bool IsModified => false;
    }
}