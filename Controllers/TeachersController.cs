using Microsoft.AspNetCore.Mvc;

namespace SoftStacksTechnologies.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult TeacherDashBoard()
        {
            return View();
        }
    }
}
