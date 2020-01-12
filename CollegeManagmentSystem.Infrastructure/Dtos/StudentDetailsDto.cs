using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagmentSystem.Infrastructure.Dtos
{
    public class StudentDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public List<StudentDetailsSubjectsDto> Subjects { get; set; }
    }
}
