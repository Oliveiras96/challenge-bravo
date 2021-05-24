using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using src.Data;

namespace src
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string AllowAnyOrigins = "_allowAnyOrigins";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Expose the DbContext
            services.AddDbContext<CurrencyConvertionContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CurrencyConvertionAPIContext")));
            
            // Enable CORS
            services.AddCors(options => 
            {
                options.AddPolicy(name: AllowAnyOrigins, builder => 
                {
                    builder.AllowAnyOrigin().AllowAnyMethod();
                });
            });

            services.AddControllers();

            // Customize Swagger Header page:
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo 
                {   
                    Version = "v1",
                    Title = "currency conversion API",
                    Description = "A API that converts currencies",
                    Contact = new OpenApiContact
                    {
                        Name = "Caique Campos de Oliveira",
                        Email = "kaique.campos13@gmail.com"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                // Make Swagger the home page of the application:
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "currency_conversion_bravo v1");
                    c.RoutePrefix = string.Empty;
                });            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AllowAnyOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
