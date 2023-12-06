using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftStacksTechnologies.Models;

namespace SoftStacksTechnologies.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles =RolesClass.Admin)]
        public IActionResult AdminDashBoard()
        {
            return View();
        }
    }
}
