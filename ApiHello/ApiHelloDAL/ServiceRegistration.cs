using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloCore.Repositories;
using ApiHelloDAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ApiHelloDAL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IContactRepository,ContactRepository>();
            services.AddScoped<ISlideRepository,SlideRepository>();
            return services;
        }
    }
}
