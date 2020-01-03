using CollegeManagmentSystem.Admin;
using CollegeManagmentSystem.Infrastructure.Data;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace CollegeManagmentSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICollegeContext, CollegeContext>(new InjectionConstructor("name=CollegeContext"));

            container.RegisterType(typeof(IBaseAdmin<>), typeof(BaseAdmin<>));
            container.RegisterType<ICoursesAdmin, CoursesAdmin>();
            container.RegisterType<ISubjectsAdmin, SubjectsAdmin>();
            container.RegisterType<IStudentsAdmin, StudentsAdmin>();
            container.RegisterType<ITeachersAdmin, TeachersAdmin>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}