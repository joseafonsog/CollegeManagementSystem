using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Infrastructure.Data;

namespace CollegeManagmentSystem.Admin
{
    public class StudentsAdmin : BaseAdmin<Student>, IStudentsAdmin
    {
        public StudentsAdmin(ICollegeContext db) : base(db)
        {
        }

        public void SaveOrUpdate(CreateStudentRequestDto dto) => SaveOrUpdate(dto, null);
        public void SaveOrUpdate(CreateStudentRequestDto dto, int? id)
        {
            if (id == null || id <= 0)
            {
                var student = new Student
                {
                    Name = dto.Name,
                    Birthday = dto.Birthday
                };
                Add(student);
            }
            else
            {
                var student = Get(id.Value);
                student.Name = dto.Name;
                student.Birthday = dto.Birthday;
                Update(student);
            }
        }
    }
}
