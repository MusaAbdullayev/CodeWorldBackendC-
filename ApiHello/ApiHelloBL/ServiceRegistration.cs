using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloBL.Services.AuthService;
using ApiHelloBL.Services.CategoryService;
using ApiHelloBL.Services.ProductService;
using Microsoft.Extensions.DependencyInjection;

namespace ApiHelloBL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthServices>();
            return services;
        }
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistration));
            return services;
        }
    }
}
