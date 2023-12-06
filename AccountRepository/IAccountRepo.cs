using Microsoft.AspNetCore.Identity;
using SoftStacksTechnologies.Models;

namespace SoftStacksTechnologies.AccountRepository
{
    public interface IAccountRepo
    {
        Task<IdentityResult> SignUp(SignUpModel signup);
        Task<SignInResult> SignIn(SignInModel signin);
        Task SignOut();
    }
}
