using BACKSIACE.Repository;
using BACKSIACE.Services;
using Microsoft.EntityFrameworkCore;

namespace BACKSIACE
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SiaceDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Registro de repositorios genéricos
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Registro de servicios específicos
            services.AddScoped<SucursalService>();
            services.AddScoped<ProductoService>();
            services.AddScoped<VentaService>();
            services.AddScoped<ReporteService>();
            services.AddScoped<PedidoService>();

            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            // Habilitar CORS
            app.UseCors("AllowAllOrigins");

            // Uso de autenticación
            app.UseAuthentication();

            // Redireccionamiento a HTTPS
            app.UseHttpsRedirection();

            app.UseRouting();

            // Uso de autorización
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
