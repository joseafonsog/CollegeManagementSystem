using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Infrastructure.Data;
using CollegeManagmentSystem.Infrastructure.Dtos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CollegeManagmentSystem.Admin
{
    public class StudentsAdmin : BaseAdmin<Student>, IStudentsAdmin
    {
        private readonly ICollegeContext _db;
        public StudentsAdmin(ICollegeContext db) : base(db)
        {
            _db = db;
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

                if (dto.EnrollSubjects.Any())
                {
                    var studentSubjects = new List<StudentSubject>();
                    foreach (var item in dto.EnrollSubjects)
                    {
                        var subject = _db.Subjects.FirstOrDefault(s => s.Id == item);

                        if (subject == null) continue;

                        studentSubjects.Add(new StudentSubject
                        {
                            Subject = subject,
                            Grade = 0
                        });
                    }
                    student.StudentSubjects = studentSubjects;
                }
                Add(student);
            }
            else
            {
                var student = Get(id.Value);
                student.Name = dto.Name;
                student.Birthday = dto.Birthday;

                if (dto.UnEnrollSubjects.Any())
                {
                    foreach (var item in dto.EnrollSubjects)
                    {
                        var studentSubject = _db.StudentSubjects.FirstOrDefault(s => s.SubjectId == item);
                        
                        if (studentSubject == null) continue;

                        student.StudentSubjects.Remove(studentSubject);
                    }
                }

                if (dto.EnrollSubjects.Any())
                {
                    foreach (var item in dto.EnrollSubjects)
                    {
                        var subject = _db.Subjects.FirstOrDefault(s => s.Id == item);

                        if (subject == null) continue;

                        student.StudentSubjects.Add(new StudentSubject
                        {
                            Subject = subject,
                            Grade = 0
                        });
                    }
                }

                Update(student);
            }
        }

        public StudentDetailsDto GetStudentDetail(int id)
        {
            var studentSubjects = _db.StudentSubjects
                .Where(c => c.StudentId == id)
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .ToList();
            var subjects = new List<StudentDetailsSubjectsDto>();
            foreach (var item in studentSubjects)
            {
                subjects.Add(new StudentDetailsSubjectsDto
                {
                    Subject = item.Subject,
                    Grade = item.Grade ?? 0
                });
            }

            var student = studentSubjects.FirstOrDefault().Student ?? _db.Students.FirstOrDefault(s => s.Id == id) ?? new Student();
            
            var result = new StudentDetailsDto
            {
                Id = student.Id,
                Name = student.Name,
                Birthday = student.Birthday,
                Subjects = subjects
            };

            return result;
        }
    }
}
