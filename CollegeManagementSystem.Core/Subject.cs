using Newtonsoft.Json;
using System.Collections.Generic;

namespace CollegeManagementSystem.Core
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}
