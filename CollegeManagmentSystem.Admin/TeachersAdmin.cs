using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace CollegeManagmentSystem.Admin
{
    public class TeachersAdmin : BaseAdmin<Teacher>, ITeachersAdmin
    {
        private readonly ICollegeContext _db;
        public TeachersAdmin(ICollegeContext db) : base(db)
        {
            _db = db;
        }

        public IList<Teacher> GetFreeTeachers()
        {
            return _db.Teachers.Where(t => t.SubjectId == null).ToList();
        }
        public void SaveOrUpdate(CreateTeacherRequestDto dto) => SaveOrUpdate(dto, null);
        public void SaveOrUpdate(CreateTeacherRequestDto dto, int? id)
        {
            if (id == null || id <= 0)
            {
                var teacher = new Teacher
                {
                    Name = dto.Name,
                    Birthday = dto.Birthday,
                    Salary = dto.Salary
                };
                Add(teacher);
            }
            else
            {
                var teacher = Get(id.Value);
                teacher.Name = dto.Name;
                teacher.Birthday = dto.Birthday;
                teacher.Salary = dto.Salary;
                Update(teacher);
            }
        }
    }
}
