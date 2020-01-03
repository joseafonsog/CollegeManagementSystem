using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Infrastructure.Data;
using System.Linq;

namespace CollegeManagmentSystem.Admin
{
    public class SubjectsAdmin : BaseAdmin<Subject>, ISubjectsAdmin
    {
        private readonly ICollegeContext _db;
        public SubjectsAdmin(ICollegeContext db) : base(db)
        {
            _db = db;
        }

        public void EnrollStudent(int id, int studentId)
        {
            var subject = _db.Subjects.FirstOrDefault(s => s.Id == id);
            var student = _db.Students.FirstOrDefault(s => s.Id == id);

            var studentsubject = new StudentSubject
            {
                Student = student,
                Subject = subject
            };

            _db.StudentSubjects.Add(studentsubject);
            _db.SaveChanges();
        }
        public void RegisterGrade(int id, int studentId, decimal grade)
        {
            var studentsubject = _db.StudentSubjects.FirstOrDefault(s => s.SubjectId == id && s.StudentId == studentId);
            studentsubject.Grade = grade;
            _db.SaveChanges();
        }

        public void SaveOrUpdate(CreateSubjectRequestDto dto) => SaveOrUpdate(dto, null);
        public void SaveOrUpdate(CreateSubjectRequestDto dto, int? id)
        {
            if (id == null || id <= 0)
            {
                var teacher = _db.Teachers.FirstOrDefault(t => t.Id == dto.TeacherId);
                var course = _db.Courses.FirstOrDefault(t => t.Id == dto.CourseId);
                var subject = new Subject
                {
                    Name = dto.Name,
                    Course = course,
                    Teacher = teacher
                };
                Add(subject);
            }
            else
            {
                var subject = Get(id.Value);
                subject.Name = dto.Name;
                subject.CourseId = dto.CourseId;
                subject.TeacherId = dto.TeacherId;
                Update(subject);
            }
        }
    }
}
