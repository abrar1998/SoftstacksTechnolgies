using Microsoft.AspNetCore.Mvc;

namespace SoftStacksTechnologies.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult StudentDashBoard()
        {
            return View();
        }
    }
}
