using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Infrastructure.Dtos
{
    public class CreateStudentRequestDto
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public List<int> EnrollSubjects { get; set; }
        public List<int> UnEnrollSubjects { get; set; }
    }
}
