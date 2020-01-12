using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Infrastructure.Dtos;
using System.Collections.Generic;

namespace CollegeManagmentSystem.Admin
{
    public interface ISubjectsAdmin : IBaseAdmin<Subject>
    {
        void SaveOrUpdate(CreateSubjectRequestDto dto);
        void SaveOrUpdate(CreateSubjectRequestDto dto, int? id);
        void EnrollStudent(int id, int studentId);
        void RegisterGrade(int id, int studentId, decimal grade);
        IList<Subject> GetSubjectByCourse(int courseId);
        SubjectDetailsDto GetSubjectDetail(int id);
    }
}
