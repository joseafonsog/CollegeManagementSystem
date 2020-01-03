using System.Web;
using System.Web.Optimization;

namespace CollegeManagmentSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Scripts/toastr.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/toastr.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.min.js",
                      "~/Scripts/angular-route.min.js",
                      "~/Scripts/app/app.js",
                      "~/Scripts/app/shared/services/coursesService.js",
                      "~/Scripts/app/shared/services/studentsService.js",
                      "~/Scripts/app/shared/services/subjectsService.js",
                      "~/Scripts/app/shared/services/teachersService.js",
                      "~/Scripts/app/controllers/coursesCtrl.js",
                      "~/Scripts/app/controllers/studentsCtrl.js",
                      "~/Scripts/app/controllers/subjectsCtrl.js",
                      "~/Scripts/app/controllers/teachersCtrl.js"));
        }
    }
}
