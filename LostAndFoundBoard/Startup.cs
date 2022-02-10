using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using LostAndFoundLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using LostAndFoundBoard.Infrastructure;
using LostAndFoundBoard.Application.Requests;

namespace LostAndFoundBoard
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
            services.AddControllersWithViews();

            services.AddDbContext<Context>(
                options => options.UseSqlServer(@"Data Source=DESKTOP-BCNRBLD\SQLEXPRESS01;Initial Catalog=DESKTOP-BCNRBLD\SQLEXPRESS01;Integrated Security=True;Pooling=False;"));

            services.AddMediatR(typeof(IndexHandlerRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EditItemHandlerRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EditItemCommandRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateItemCommandRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ItemDetailHandlerRequest).GetTypeInfo().Assembly);

            services.AddScoped(typeof(IContext), typeof(Context));
            services.AddScoped(typeof(IndexHandlerRequest));
            services.AddScoped(typeof(EditItemHandlerRequest));
            services.AddScoped(typeof(EditItemCommandRequest));
            services.AddScoped(typeof(CreateItemCommandRequest));
            services.AddScoped(typeof(ItemDetailHandlerRequest));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
