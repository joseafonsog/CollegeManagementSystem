using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Infrastructure.Data;
using CollegeManagmentSystem.Infrastructure.Dtos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CollegeManagmentSystem.Admin
{
    public class CoursesAdmin : BaseAdmin<Course>, ICoursesAdmin
    {
        private readonly ICollegeContext _db;
        public CoursesAdmin(ICollegeContext db) : base(db)
        {
            _db = db;
        }

        public IList<CourseDto> GetAllWithAdditionalData()
        {
            var courses = GetAll().Select(c =>
            {
                var teachers = c.Subjects.Select(s => s.TeacherId).Distinct();
                var studentSubjects = new List<StudentSubject>();
                foreach (var item in c.Subjects)
                {
                    var studentSubs = _db.StudentSubjects.Where(ss => ss.SubjectId == item.Id);
                    studentSubjects.AddRange(studentSubs);
                }
                var students = studentSubjects.Select(ss => ss.StudentId).Distinct();

                return new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Teachers = teachers.Count(),
                    Students = students.Count(),
                };

            }).ToList();


            return courses;
        }

        public CourseDetailsDto GetCourseDetail(int id)
        {
            var course = _db.Courses
                .Include(x => x.Subjects)
                .Include("Subjects.StudentSubjects")
                .FirstOrDefault(c => c.Id == id);
            var teachers = course.Subjects.Select(s => s.TeacherId).Distinct();
            var studentSubjects = new List<StudentSubject>();
            var subjects = new List<CourseDetailsSubjectsDto>();
            foreach (var item in course.Subjects)
            {
                subjects.Add(new CourseDetailsSubjectsDto
                {
                    Subject = item,
                    AvgGrade = item.StudentSubjects.Average(ss => ss.Grade) ?? 0
                });
                studentSubjects.AddRange(item.StudentSubjects);
            }
            var students = studentSubjects.Select(ss => ss.StudentId).Distinct();


            var result = new CourseDetailsDto
            {
                Id = course.Id,
                Name = course.Name,
                Teachers = teachers.Count(),
                Students = students.Count(),
                Subjects = subjects
            };



            return result;
        }

        public void SaveOrUpdate(CreateCourseRequestDto dto) => SaveOrUpdate(dto, null);
        public void SaveOrUpdate(CreateCourseRequestDto dto, int? id)
        {
            if (id == null || id <= 0)
            {
                var course = new Course
                {
                    Name = dto.Name
                };
                Add(course);
            }
            else
            {
                var course = Get(id.Value);
                course.Name = dto.Name;
                Update(course);
            }
        }
    }
}
