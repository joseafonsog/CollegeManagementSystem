using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagmentSystem.Infrastructure.Dtos
{
    public class CourseDetailsDto : CourseDto
    {
        public List<CourseDetailsSubjectsDto> Subjects { get; set; }
    }
}
