using CollegeManagementSystem.Core;
using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Admin;
using CollegeManagmentSystem.Infrastructure.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CollegeManagmentSystem.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectsAdmin _subjectsAdmin;
        public SubjectsController(ISubjectsAdmin subjectsAdmin)
        {
            _subjectsAdmin = subjectsAdmin;
        }
        public object GetAll()
        {
            var subjects = _subjectsAdmin.GetAll();
            var result = JsonConvert.SerializeObject(subjects, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            return result;
        }

        public object GetById(int id)
        {
            var subjects = _subjectsAdmin.Get(id);
            var result = JsonConvert.SerializeObject(subjects, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            return result;
        }

        public object GetByCourse(int id)
        {
            var subjects = _subjectsAdmin.GetSubjectByCourse(id);
            var result = JsonConvert.SerializeObject(subjects, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            return result;
        }
        public object Details(int id)
        {
            var subjects = _subjectsAdmin.GetSubjectDetail(id);
            var result = JsonConvert.SerializeObject(subjects, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            return result;
        }

        [HttpPost]
        public object Create(CreateSubjectRequestDto dto)
        {
            _subjectsAdmin.SaveOrUpdate(dto);
            return null;
        }

        [HttpPost]
        public object Enroll(int id, int studentId)
        {
            _subjectsAdmin.EnrollStudent(id, studentId);
            return null;
        }

        [HttpPost]
        public object RegisterGrade(int id, RegisterGradeRequestDto dto)
        {
            foreach (var item in dto.Grades)
            {
                _subjectsAdmin.RegisterGrade(id, item.StudentId, item.Grade);
            }
            return null;
        }

        [HttpPut]
        public object Edit(int id, CreateSubjectRequestDto dto)
        {
            _subjectsAdmin.SaveOrUpdate(dto, id);
            return null;
        }

        [HttpDelete]
        public object Delete(int id)
        {
            _subjectsAdmin.Delete(id);
            return null;
        }
    }
}