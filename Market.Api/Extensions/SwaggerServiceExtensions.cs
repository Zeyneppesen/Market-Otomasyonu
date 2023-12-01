using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Market.Api.Extensions
{
    //public static class SwaggerServiceExtensions
    //{
        //private static string GesApiVersion = "v1";
        //private static string GesApiName = "Market API";
        //private static string GesApiDesc = "Welcome to Market API";


        //public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        //{

        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc(GesApiVersion, new OpenApiInfo
        //        {
        //            Version = GesApiVersion,
        //            Title = GesApiName,
        //            Description = GesApiDesc
        //        });
        //        c.EnableAnnotations();
        //        // Authorize => Bearer <token>  
        //        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //        {
        //            Description = @"JWT Authorization header using the Bearer scheme. Example: Authorization: Bearer {token}",
        //            Name = "Authorization",
        //            In = ParameterLocation.Header,
        //            Type = SecuritySchemeType.ApiKey,
        //            Scheme = "Bearer"
        //        });

        //        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //        {
        //            {
        //                new OpenApiSecurityScheme
        //                {
        //                    Reference = new OpenApiReference
        //                    {
        //                        Type = ReferenceType.SecurityScheme,
        //                        Id = "Bearer"
        //                    }
        //                },
        //            Array.Empty<string>()
        //            }
        //        });
        //    });


        //    return services;
        //}
        //public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI(c =>
        //    {
        //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Market API V1");
        //    });


        //    app.UseDeveloperExceptionPage();
        //    app.UseSwagger();
        //    app.UseSwaggerUI(c =>
        //    {
        //        c.SwaggerEndpoint("/swagger/v1/swagger.json", GesApiName);
        //        c.DocumentTitle = GesApiDesc;
        //        c.DocExpansion(DocExpansion.None);
        //    });
        //    return app;
        //}



        public static class SwaggerServiceExtensions
        {
            private static string GesApiVersion = "v1";
            private static string GesApiName = "Market API";
            private static string GesApiDesc = "Welcome to Market API";

            public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(GesApiVersion, new OpenApiInfo
                    {
                        Version = GesApiVersion,
                        Title = GesApiName,
                        Description = GesApiDesc
                    });

                    c.EnableAnnotations();

                    // Authorize => Bearer <token>  
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = @"JWT Authorization header using the Bearer scheme. Example: Authorization: Bearer {token}",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,  // Changed from ApiKey to Http
                        Scheme = "Bearer"
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    System.Array.Empty<string>()
                }
            });
                });

                return services;
            }

            public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Market API V1");
                    c.DocumentTitle = GesApiDesc;
                    c.DocExpansion(DocExpansion.None);
                });

                return app;
            }
        }

    
}