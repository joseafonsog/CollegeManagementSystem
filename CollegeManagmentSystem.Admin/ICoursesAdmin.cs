using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Infrastructure.Dtos;
using System.Collections.Generic;

namespace CollegeManagmentSystem.Admin
{
    public interface ICoursesAdmin : IBaseAdmin<Course>
    {
        void SaveOrUpdate(CreateCourseRequestDto dto);
        void SaveOrUpdate(CreateCourseRequestDto dto, int? id);
        IList<CourseDto> GetAllWithAdditionalData();
        CourseDetailsDto GetCourseDetail(int id);
    }
}
