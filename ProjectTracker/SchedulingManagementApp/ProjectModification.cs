using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTracker
{
    public class ProjectModification
    {
        public Guid MSProjectGuid { get; set; }
        public string? ProgrammersName { get; set; }
        public DateTime? UpdatedFinishDate { get; set; }
        public int? UpdatedPercent { get; set; }
        public int? TestingPercent { get; set; }
        public bool ReleasedChecked { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string? Notes { get; set; }
    }
}
