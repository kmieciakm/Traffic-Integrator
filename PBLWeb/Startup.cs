using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PBLWeb.Areas.Identity.Repository;
using PBLWeb.Data;
using PBLWeb.Services;
using Supplier.Model;

namespace PBLWeb {
    public class Startup {
        public Startup( IConfiguration configuration, IWebHostEnvironment env ) {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services ) {
            services.AddSwaggerGen(config => {
                config.SwaggerDoc("1.0", new Microsoft.OpenApi.Models.OpenApiInfo { 
                    Title = "Traffic Integrator API",
                    Version = "1.0",
                    Description = "Result API of integrating traffic suppliers APIs"
                });
                config.EnableAnnotations();
            });

            services.AddControllersWithViews();
            services.AddApiVersioning();
            services.AddHttpClient();

            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DBContextConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AppDBContext>();

            services.AddScoped<ISupplierDataRepository, SupplierDataRepository>();

            services.AddScoped(provider =>
            {
                return new SupplierService<Yanosik>(
                        new Yanosik(Path.Combine(Environment.WebRootPath, "data", "yanosikDbGPS.json"))
                    );
            });
            services.AddScoped(provider => {
                return new SupplierService<AiT>(
                        new AiT(Path.Combine(Environment.WebRootPath, "data", "aitDb.json"))
                    );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env ) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/1.0/swagger.json", "Traffic Integrator API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
