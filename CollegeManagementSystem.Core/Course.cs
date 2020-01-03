using Newtonsoft.Json;
using System.Collections.Generic;

namespace CollegeManagementSystem.Core
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
