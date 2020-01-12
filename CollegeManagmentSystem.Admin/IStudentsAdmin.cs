using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Infrastructure.Dtos;

namespace CollegeManagmentSystem.Admin
{
    public interface IStudentsAdmin : IBaseAdmin<Student>
    {
        void SaveOrUpdate(CreateStudentRequestDto dto);
        void SaveOrUpdate(CreateStudentRequestDto dto, int? id);
        StudentDetailsDto GetStudentDetail(int id);
    }
}
