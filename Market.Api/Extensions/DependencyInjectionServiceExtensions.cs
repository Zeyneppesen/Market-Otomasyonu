using FluentAssertions.Common;
using Market.Business.Abstract;
using Market.Business.Concrete;
using Market.Data.Abstract;
using Market.Data.Concrete.Ef;
using Serilog.Events;
using Serilog;

namespace Market.Api.Extensions
{
    public static class DependencyInjectionServiceExtensions
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            //services.AddMvc();
            services.AddHttpContextAccessor();

            //services.AddControllersWithViews();
            // .AddFluentValidation

            var loggerConfiguration = new LoggerConfiguration()
                   //.WriteTo.Console() // Opsiyonel: Konsola log yazmak için
                   .WriteTo.File("logdosyasi.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information); // Günlük bazında dosyaya log yazmak için

            Log.Logger = loggerConfiguration.CreateLogger();

            services.AddLogging(builder =>
            {
                builder.AddConsole(); // Logları konsola yazdır
            });
            //Services
            services.AddScoped<IProductService, ProductService>();
            
           


            //Repository
            services.AddScoped<IProductRepository,EfProductRepository>();

            AddDependency(services);

            return services;
        }
    }
}
