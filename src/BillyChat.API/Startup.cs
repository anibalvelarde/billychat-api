using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BillyChat.API.Domain.Repositories;
using BillyChat.API.Domain.Services;
using BillyChat.API.Persistence.Contexts;
using BillyChat.API.Persistence.Repositories;
using BillyChat.API.Services;

namespace BillyChat.API
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
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("billychat-api-in-memory");
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else {
                // The default HSTS value is 30 days. You may want to change this for
                // production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // These were defaulted from dotnet new webapi template command
            // app.UseRouting();
            // app.UseAuthorization();
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
        }
    }
}
