using System;

namespace CollegeManagementSystem.Infrastructure.Dtos
{
    public class CreateStudentRequestDto
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
