using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.BusinessLayer.Container;
using TraversalTourProject.BusinessLayer.ValidationRules;
using TraversalTourProject.DataAccessLayer.Abstract;
using TraversalTourProject.DataAccessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;
using TraversalTourProject.EntityLayer.Concrete;
using TraversalTourProject.Presentation.Models;

namespace TraversalTourProject.Presentation
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
            //Loglama i�im kullan�lacak olan k�s�m
            services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });
            //HEm Identity hem de proje seviyesinde autontication uygulamak..
            services.AddDbContext<Context>();

            //CustomIdentityValidator olu�turduktan sonra ekleme yap�yoruz. Bu k�sma ekleme yap�lacak.
            //AddErrorDescriber<Modelimizin ad� olacak> ve Entityfreameworkstores tekrar eklenecek.
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>()
                .AddEntityFrameworkStores<Context>();

            //Business Katman�na Container klas�r�n i�erisne tan�mlad���m�z method geliyor.
            //Buradan kontrol edebilirsin.
            services.ContainerDependencies();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));

            });
            services.AddMvc();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //Loglama yap�lacak dosya yolunu yazmam�z gerekiyor.
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");


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
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //UseAuthorization dan �nce eklemek gerekiyor.  NEDEN�:
            //Kimlik"Authentication" do�rulanmadan  Yetki "Authorize" verilmez.
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

        }
    }
}
