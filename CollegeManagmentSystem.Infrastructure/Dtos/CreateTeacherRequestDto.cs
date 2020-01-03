using System;

namespace CollegeManagementSystem.Infrastructure.Dtos
{
    public class CreateTeacherRequestDto
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
    }
}
