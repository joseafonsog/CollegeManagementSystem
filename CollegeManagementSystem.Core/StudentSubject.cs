using Newtonsoft.Json;

namespace CollegeManagementSystem.Core
{
    public class StudentSubject
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal? Grade { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
