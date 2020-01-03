using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Admin;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace CollegeManagmentSystem.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeachersAdmin _teachersAdmin;
        public TeachersController(ITeachersAdmin teachersAdmin)
        {
            _teachersAdmin = teachersAdmin;
        }

        public object Index()
        {
            return JsonConvert.SerializeObject(_teachersAdmin.GetAll(), Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }

        public object FreeTeachers()
        {
            return JsonConvert.SerializeObject(_teachersAdmin.GetFreeTeachers(), Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }

        public object Details(int id)
        {
            return JsonConvert.SerializeObject(_teachersAdmin.Get(id), Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }

        [HttpPost]
        public object Create(CreateTeacherRequestDto dto)
        {
            _teachersAdmin.SaveOrUpdate(dto);
            return null;
        }

        [HttpPut]
        public object Edit(int id, CreateTeacherRequestDto dto)
        {
            _teachersAdmin.SaveOrUpdate(dto, id);
            return null;
        }

        [HttpDelete]
        public object Delete(int id)
        {
            _teachersAdmin.Delete(id);
            return null;
        }
    }
}