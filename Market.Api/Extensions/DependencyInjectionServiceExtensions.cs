using Market.Business.Concrete;
using Market.Business.Abstract;
using Market.Data.Abstract;
using Market.Data.Concrete.Ef;

namespace Market.Api.Extensions
{
    public static class DependencyInjectionServiceExtensions
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ProductService, IProductService>();

            services.AddScoped<IProductRepository, EfProductRepository>();

            return services;
        }
    }
}