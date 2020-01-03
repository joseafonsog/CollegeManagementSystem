using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Infrastructure.Data;

namespace CollegeManagmentSystem.Admin
{
    public class CoursesAdmin : BaseAdmin<Course>, ICoursesAdmin
    {
        public CoursesAdmin(ICollegeContext db) : base(db)
        {
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
