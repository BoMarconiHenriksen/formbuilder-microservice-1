using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace R3NextGenBackend.Extensions
{
    public static class ServiceExtensions
    {
        // For CORS
        //public static void ConfigureCors(this IServiceCollection services)
        //{
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy("CorsPolicy",
        //            builder => builder.AllowAnyOrigin()
        //            .AllowAnyMethod()
        //            .AllowAnyHeader()
        //            .AllowCredentials());
        //    });
        //}

        // configure an IIS integration which will help us with the IIS deployment. 
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }


    }
}
