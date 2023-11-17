using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace Market.Api.Extensions
{
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                var loggerConfiguration = new LoggerConfiguration()
                    //.WriteTo.Console() // Opsiyonel: Konsola log yazmak için
                    .WriteTo.File("logdosyasi.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information); // Günlük bazında dosyaya log yazmak için

                Log.Logger = loggerConfiguration.CreateLogger();

                services.AddLogging(builder =>
                {
                    builder.AddSerilog(); // ILogger'ı Serilog ile yapılandır
                });

                services.AddDependency(); // Yukarıdaki DependencyInjectionServiceExtensions'ı ekleyin
                services.AddCors();
                services.AddSwaggerGen(services => { });
            }
        }
    
}
