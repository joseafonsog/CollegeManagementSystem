using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Core
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}
