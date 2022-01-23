using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectDAW.Utilities;
using ProiectDAW.Data.Services;
using ProiectDAW.Utilities.JWTUtilis;
using ProiectDAW.Data.Repos.MovieRepo;
using ProiectDAW.Data.Repos.GenreRepo;
using ProiectDAW.Data.Repos.TrailerRepo;
using ProiectDAW.Data.Repos.WatchListRepo;
using ProiectDAW.Data.Repos.MovieGenreRepo;
using ProiectDAW.Data.Repos.UserRepo;

namespace ProiectDAW
{
    public class Startup
    {
        private readonly string CorsAllowSpecifcOrigin="front";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProiectDAW", Version = "v1" });
            });

            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IJWTUtils, JWTUtils>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWatchListRepository, WatchListRepository>();
            services.AddTransient<IWatchListService, WatchListService>();

            /*services.AddCors(options =>

                options.AddPolicy(name: CorsAllowSpecifcOrigin, builder =>
            {
                builder.WithOrigins("https://localhost:5000").AllowAnyHeader().AllowCredentials().AllowAnyMethod();
            }
            ));*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProiectDAW v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<JWTMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
