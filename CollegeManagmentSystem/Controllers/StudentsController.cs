using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Admin;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace CollegeManagmentSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsAdmin _studentsAdmin;
        public StudentsController(IStudentsAdmin studentsAdmin)
        {
            _studentsAdmin = studentsAdmin;
        }
        public object GetAll()
        {
            return JsonConvert.SerializeObject(_studentsAdmin.GetAll(), Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }

        public object GetById(int id)
        {
            return JsonConvert.SerializeObject(_studentsAdmin.Get(id), Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }

        public object Details(int id)
        {
            return JsonConvert.SerializeObject(_studentsAdmin.GetStudentDetail(id), Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }

        [HttpPost]
        public object Create(CreateStudentRequestDto dto)
        {
            _studentsAdmin.SaveOrUpdate(dto);
            return null;
        }

        [HttpPut]
        public object Edit(int id, CreateStudentRequestDto dto)
        {
            _studentsAdmin.SaveOrUpdate(dto, id);
            return null;
        }

        [HttpDelete]
        public object Delete(int id)
        {
            _studentsAdmin.Delete(id);
            return null;
        }
    }
}