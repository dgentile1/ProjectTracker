using System;

namespace ProjectTracker.Models
{
    public class Programmers
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(LastName))
                return base.ToString();
            if (string.IsNullOrWhiteSpace(LastName))
                return FirstName;
            return $"{FirstName} {LastName}";
        }
    }
}
