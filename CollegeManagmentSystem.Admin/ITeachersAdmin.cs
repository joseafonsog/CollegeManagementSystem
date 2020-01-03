using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using System.Collections.Generic;

namespace CollegeManagmentSystem.Admin
{
    public interface ITeachersAdmin : IBaseAdmin<Teacher>
    {
        void SaveOrUpdate(CreateTeacherRequestDto dto);
        void SaveOrUpdate(CreateTeacherRequestDto dto, int? id);
        IList<Teacher> GetFreeTeachers();
    }
}
