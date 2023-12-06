using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SoftStacksTechnologies.AccountRepository;
using SoftStacksTechnologies.Models;

namespace SoftStacksTechnologies.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepo _repo;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IAccountRepo repo, RoleManager<IdentityRole> roleManager)
        {
            this._repo = repo;
            this._roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignUpModel signup)
        {
            if (ModelState.IsValid)
            {
                var res = await _repo.SignUp(signup);
                if(!res.Succeeded)
                {
                    foreach (var item in res.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                else
                {
                    return RedirectToAction("Signin", "Account");
                }
            }
            return View(signup);
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(SignInModel signin)
        {
            if(ModelState.IsValid)
            {
                var res = await _repo.SignIn(signin);
                if(res.Succeeded)
                {
                    if(User.IsInRole(RolesClass.Admin))
                    {
                        return RedirectToAction("AdminDashBoard", "Admin");
                    }
                    else if(User.IsInRole(RolesClass.Teacher))
                    {
                        return RedirectToAction("TeacherDashBoard", "Teachers");
                    }
                    else if(User.IsInRole(RolesClass.Student))
                    {
                        return RedirectToAction("StudentDashBoard", "Students");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            return View(signin);
        }

        [HttpGet]
        public IActionResult Signout()
        {
            _repo.SignOut();
            return RedirectToAction("Signin", "Account");
        }

        [HttpGet]
        public string AddRoles()
        {
            _roleManager.CreateAsync(new IdentityRole(RolesClass.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(RolesClass.Teacher)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(RolesClass.Student)).GetAwaiter().GetResult();

            return "Roles Added SuccessFully...";
        }

    }
}
