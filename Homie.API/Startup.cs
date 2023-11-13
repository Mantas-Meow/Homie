using Homie.API.Repositories;
using Homie.API.Repositories.Interfaces;
using Homie.API.Services;
using Homie.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Homie.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            string connectionString = configuration.GetConnectionString("MainDatabaseConnection");

            services.AddDbContext<HomieDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddTransient<HomieDbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
