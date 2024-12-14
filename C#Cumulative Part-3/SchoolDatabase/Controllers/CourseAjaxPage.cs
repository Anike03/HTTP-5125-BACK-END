using Microsoft.AspNetCore.Mvc;

namespace SchoolDatabase.Controllers
{
    public class CourseAjaxPage : Controller
    {
       
        public IActionResult List()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
