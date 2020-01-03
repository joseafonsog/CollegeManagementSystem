using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;

namespace CollegeManagmentSystem.Admin
{
    public interface ICoursesAdmin : IBaseAdmin<Course>
    {
        void SaveOrUpdate(CreateCourseRequestDto dto);
        void SaveOrUpdate(CreateCourseRequestDto dto, int? id);
    }
}
