
namespace Logix_Movie_Application.Extensions
{
    public static class AppExtension
    {
        public static void RegisterCORS(this IServiceCollection services, IConfiguration configuration)
        {
            var allowSpecificOrigin = configuration.GetSection("AllowSpecificOrigin").Get<string>();
            services.AddCors(options =>
            {
                options.AddPolicy(allowSpecificOrigin, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}
