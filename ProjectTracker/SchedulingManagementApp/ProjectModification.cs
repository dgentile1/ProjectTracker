using System;

namespace ProjectTracker
{
    public class ProjectModification
    {
        public Guid MSProjectGuid { get; set; }
        public string? ProgrammersName { get; set; }
        public DateTime? UpdatedStartDate { get; set; }
        public DateTime? UpdatedFinishDate { get; set; }
        public DateTime? UpdatedTestingStartDate { get; set; }
        public int? UpdatedPercent { get; set; }
        public int? TestingRounds { get; set; }
        public bool ReleasedChecked { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string? Notes { get; set; }
        public string? TrelloUrl { get; set; }
    }
}