using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore_Mentoring.BLL.Services;
using NetCore_Mentoring.BLL.Services.Interfaces;

namespace NetCore_Mentoring.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
