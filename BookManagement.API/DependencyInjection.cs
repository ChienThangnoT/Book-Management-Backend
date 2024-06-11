using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BookManagement.API
{
    public static class DependencyInjection
    {
        public static void AddWebAPIService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            });

            services.AddEndpointsApiExplorer();

            //add cors
            services.AddCors(options =>
            {
                options.AddPolicy("app-cors",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination")
                        .AllowAnyMethod();
                    });
            });
        }
    }
}
