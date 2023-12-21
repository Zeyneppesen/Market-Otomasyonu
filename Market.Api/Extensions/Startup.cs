using Market.Business.Abstract;
using Market.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

namespace Market.Api.Extensions
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Market API", Version = "v1" });
                //c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Market API", Version = "v1" });

            }
            );

            var loggerConfiguration = new LoggerConfiguration()
                //.WriteTo.Console() // Opsiyonel: Konsola log yazmak için
                .WriteTo.File("logdosyasi.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information); // Günlük bazında dosyaya log yazmak için

            Log.Logger = loggerConfiguration.CreateLogger();

            services.AddLogging(builder =>
            {
                builder.AddSerilog(); // ILogger'ı Serilog ile yapılandır
                builder.AddSerilog();
            });

            services.AddCors();

            services.AddDependency();
            services.AddSwaggerDocumentation();

        }
    }
}