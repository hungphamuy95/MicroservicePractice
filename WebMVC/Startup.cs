using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebMVC
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
            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = "cookie";
                opt.DefaultScheme = "oidc";
            }).AddCookie("cookie")
                .AddOpenIdConnect("oidc", opt =>
                {
                    opt.Authority = "https://localhost:32777/";
                    opt.ClientId = "oidcClient";
                    opt.ClientSecret = "SuperSecretPassword";

                    opt.ResponseType = "code";
                    opt.UsePkce = true;
                    opt.ResponseMode = "query";

                    // options.CallbackPath = "/signin-oidc"; // default redirect URI

                    // options.Scope.Add("oidc"); // default scope
                    // options.Scope.Add("profile"); // default scope
                    opt.Scope.Add("api1.read");
                    opt.SaveTokens = true;
                });
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
