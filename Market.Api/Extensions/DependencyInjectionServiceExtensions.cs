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
            // .AddFluentValidation

            //Services
            services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IDataService, DataService>();
            //services.AddScoped<IAreasService, AreasService>();
            //services.AddScoped<IFarmerService, FarmerService>();
            //services.AddScoped<IWorkerService, WorkerService>();
            //services.AddScoped<IConsultantService, ConsultantService>();
            //services.AddScoped<IAdminService, AdminService>();


            //Repository
            services.AddScoped<IProductRepository,EfProductRepository>();
            //services.AddScoped<IUserRepository, EfUserRepository>();
            //services.AddScoped<IMailVerifyRepository, EfMailVerifyRepository>();
            //services.AddScoped<IWorkerRepository, EfWorkerRepository>();
            //services.AddScoped<IPasswordResetRepository, EfPasswordResetRepository>();
            //services.AddScoped<IAreaRepository, EfAreaRepository>();
            //services.AddScoped<IModuleRepository, EfModuleRepository>();
            //services.AddScoped<IModuleAreaRepository, EfModuleAreaRepository>();
            //services.AddScoped<IRoleRepository, EfRoleRepository>();
            //services.AddScoped<ISensorRepository, EfSensorRepository>();
            //services.AddScoped<ISensorDataRepository, EfSensorDataRepository>();
            //services.AddScoped<IConsultantRepository, EfConsultantRepository>();
            //services.AddScoped<IWeatherInfoRepository, EfWeatherInfoRepository>();
            //services.AddScoped<IGuidNameRepository, EfGuidNameRepository>();

            return services;
        }
    }
}
