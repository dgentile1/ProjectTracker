using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTracker
{
    public class MSProjectFields
    {
        public Guid? MSProjectGuid { get; set; }
        public int? Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public double? Duration { get; set; }
        public double? PercentComplete { get; set; }
    }

}
