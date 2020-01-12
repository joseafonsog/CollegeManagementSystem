using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagmentSystem.Infrastructure.Dtos
{
    public class TeacherDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime Birthday { get; set; }
        public List<TeacherDetailsSubjectsDto> Subjects { get; set; }
    }
}
