using Microsoft.Extensions.DependencyInjection;
using Task.Domain.Services.AuthDomain;
using Task.Domain.Services.ProductDomain;

namespace Task.Domain
{
    public static class MyServices
    {
        public static void AddMyDomainService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>(); 
            services.AddScoped<IProductsService, ProductsService>(); 
        }
    }
}
