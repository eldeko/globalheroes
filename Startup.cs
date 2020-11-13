using GlobalHeroes.Helpers;
using GlobalHeroes.Persistance;
using GlobalHeroes.Repositories;
using GlobalHeroes.Services;
using GlobalHeroes.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GlobalHeroes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .AddJsonFile("MarvelAPISettings.json")
             .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MarvelAPISettings>(Configuration.GetSection("MarvelAPISettings"));
            services.AddControllers();
            // services.AddRazorPages();

            //Dependency Injection
            //MARVEL'S API
            services.AddSingleton<IMarvelDataService, MarvelDataService>();
            services.AddSingleton<IMarvelAPIHelper, MarvelAPIHelper>();
           

            //LOCAL 
            services.AddSingleton<ICharactersService, CharactersService>();
            services.AddSingleton<ICustomCharactersRepository, CustomCharactersRepository>();
            services.AddSingleton<IDiskIO, DiskIO>();
            services.AddSingleton<IFakeDB, FakeDB>();

            //SWAGGER
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
