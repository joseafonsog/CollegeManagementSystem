using CollegeManagementSystem.Infrastructure.Dtos;
using CollegeManagmentSystem.Admin;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace CollegeManagmentSystem.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesAdmin _coursesAdmin;
        public CoursesController(ICoursesAdmin coursesAdmin)
        {
            _coursesAdmin = coursesAdmin;
        }
        public object Index()
        {
            return JsonConvert.SerializeObject(_coursesAdmin.GetAll(), Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }

        public object Details(int id)
        {
            return JsonConvert.SerializeObject(_coursesAdmin.Get(id), Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }

        [HttpPost]
        public object Create(CreateCourseRequestDto dto)
        {
            _coursesAdmin.SaveOrUpdate(dto);
            return null;
        }

        [HttpPut]
        public object Edit(int id, CreateCourseRequestDto dto)
        {
            _coursesAdmin.SaveOrUpdate(dto, id);
            return null;
        }

        [HttpDelete]
        public object Delete(int id)
        {
            _coursesAdmin.Delete(id);
            return null;
        }
    }
}