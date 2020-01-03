using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagmentSystem.Infrastructure.Dtos
{
    public class RegisterGradeRequestDto
    {
        public IList<GradeDto> Grades { get; set; }
    }
}
