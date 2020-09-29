using APITareas.Models.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using APITareas.Models.Services;

namespace APITareas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<TareasServicios>();
            services.AddScoped<ColaboradorServicios>();
            services.AddControllers();
            
            services.AddDbContext<PRUEBASContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MiConexion")));

            services.AddCors(opciones =>
            {
                opciones.AddPolicy("PermitirTodo", acceso => acceso.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Version ="v1", Title="Documentation web API JLC",Description="CRUD Operation"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/Swagger/v1/swagger.json", "Version v1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //El permiso
            app.UseCors("PermitirTodo");
        }
    }
}
