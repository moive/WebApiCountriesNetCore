using Microsoft.EntityFrameworkCore;
using WebApiCountries.Models;

namespace WebApiCountries
{
    public static class Startup
    {
        public static WebApplication InitializeApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build(); 
            Configure(app);
            return app;
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("CountryDb"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        private static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // access to context
            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Countries.Any())
            {
                context.Countries.AddRange(new List<Country>()
                {
                    new Country(){Name = "Perú"},
                    new Country(){Name = "Argentina"},
                    new Country(){Name = "Uruguay"},
                    new Country(){Name = "Colombia"},
                });

                context.SaveChanges();
            }
        }
    }
}
