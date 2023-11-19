
using FizooHelper.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Text;
using Task.Domain.Services.AuthDomain.Models;
namespace Task.Domain.Services.AuthDomain
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public bool iSValidEmail(string email)
        {
            try
            {
                MailAddress e = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public async Task<Respond<LoginViewModel>> Login(LoginViewModel dto)
        {
            var userName = dto.Email;
            if (iSValidEmail(dto.Email))
            {
                var user = await userManager.FindByEmailAsync(dto.Email);
                if (user != null)
                    userName = user.UserName;
            }

            var result = await signInManager.PasswordSignInAsync(userName, dto.Password,false,false);
            if (!result.Succeeded)
            {
                return new Respond<LoginViewModel>()
                {
                    IsSuccess = false,
                    Message = "wrong password or email"
                };
            }
            else
            {
                return new Respond<LoginViewModel>()
                {
                    IsSuccess = true,
                    Data = dto
                };
            }
        }

        public async Task<Respond<User>> Register(User dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.Name,
                Email = dto.Email,
            };
            var result = await userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder errors = new();
                foreach (var error in result.Errors)
                    errors.AppendLine(error.Description);
                return new Respond<User>()
                {
                    IsSuccess = false,
                    Message = errors.ToString(),
                };
            }

            await signInManager.SignInAsync(user, isPersistent: false);
            return new()
            {
                IsSuccess = true,
            };
        }
    }
}
