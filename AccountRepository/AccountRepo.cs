using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftStacksTechnologies.Models;

namespace SoftStacksTechnologies.AccountRepository
{
    public class AccountRepo:IAccountRepo
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountRepo(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole>  roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

       

        public async Task<IdentityResult> SignUp(SignUpModel signup)
        {
            var user = new IdentityUser()
            {
                UserName = signup.Email,
                Email = signup.Email
            };

            var result = await _userManager.CreateAsync(user, signup.Password);
            if(!String.IsNullOrEmpty(signup.Role.ToString()))
            {
                await _userManager.AddToRoleAsync(user, signup.Role.ToString());
            }
            else
            {
                await _userManager.AddToRoleAsync(user, RolesClass.Student);
            }
            return result;
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> SignIn(SignInModel singin)
        {
            var result = await _signInManager.PasswordSignInAsync(singin.Email, singin.Password, singin.RememberMe, false);
            return result;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }




    }
}
