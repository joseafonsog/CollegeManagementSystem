using Newtonsoft.Json;
using System;

namespace CollegeManagementSystem.Core
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public int? SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
