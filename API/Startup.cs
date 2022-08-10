using Business.Abstract;
using Business.Concrete;
using Business.Configuration.Mapper;
using DAL.Abstract;
using DAL.Concrete.EF;
using DAL.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Uygulama build olup aya�a kalk�ncaya kadar gerekli ayarlamalar� yapan yer.

        public void ConfigureServices(IServiceCollection services)
        {
            // KULLANMAK �STED��� DI y� M�DDLE WARE OLARAKTAN INJECT ET
            // Ne inject edicem?
            services.AddDbContext<ApartmentMSDBContext>(ServiceLifetime.Transient); // Her Db Context �a�r�ld���nda bu benim i�in sistem taraf�ndan new lenecek
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Uygulama aya�a kalkt�ktan sonra a�a��daki ayarlar� uygular.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
