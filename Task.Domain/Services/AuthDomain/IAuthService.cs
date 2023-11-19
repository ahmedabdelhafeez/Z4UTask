

using FizooHelper.Models;
using Task.Domain.Services.AuthDomain.Models;


namespace Task.Domain.Services.AuthDomain
{
    public interface IAuthService 
    {
        Task<Respond<User>> Register(User user);
        Task<Respond<LoginViewModel>> Login(LoginViewModel model);
    }
}
