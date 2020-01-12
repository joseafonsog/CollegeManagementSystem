using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Infrastructure.Data;
using CollegeManagmentSystem.Infrastructure.Dtos;
using System.Collections.Generic;
using System.Data.Entity;
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

        public TeacherDetailsDto GetTeacherDetail(int id)
        {
            var subjects = _db.Subjects
                .Where(c => c.TeacherId == id)
                .Include(x => x.Teacher)
                .Include(x => x.StudentSubjects)
                
                .ToList();
            var subjectsResult = new List<TeacherDetailsSubjectsDto>();
            foreach (var item in subjects)
            {
                subjectsResult.Add(new TeacherDetailsSubjectsDto
                {
                    Subject = item,
                    AvgGrade = item.StudentSubjects.Average(ss => ss.Grade) ?? 0
                });
            }

            var teacher = subjects.FirstOrDefault().Teacher ?? _db.Teachers.FirstOrDefault(s => s.Id == id) ?? new Teacher();

            var result = new TeacherDetailsDto
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Salary = teacher.Salary,
                Birthday = teacher.Birthday,
                Subjects = subjectsResult
            };



            return result;
        }
    }
}
