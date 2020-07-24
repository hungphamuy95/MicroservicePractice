using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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
                opt.DefaultScheme = "Cookies";
                opt.DefaultChallengeScheme = "oidc";
            }).AddCookie("Cookies")
                .AddOpenIdConnect("oidc", opt =>
                {
                    opt.SignInScheme = "Cookies";
                    opt.Authority = "http://host.docker.internal:5001";
                    opt.ClientId = "oidcClient";
                    opt.ClientSecret = "SuperSecretPassword";
                    opt.RequireHttpsMetadata = false;
                    opt.ResponseType = "code";
                    opt.UsePkce = true;
                    opt.ResponseMode = "query";

                    opt.Scope.Add("openid"); // default scope
                    opt.Scope.Add("profile"); // default scope
                    opt.Scope.Add("email");
                    opt.Scope.Add("role"); // default scope
                    //opt.Scope.Add("api1.read");
                    opt.SaveTokens = true;
                    opt.Events = new OpenIdConnectEvents
                    {
                        OnRemoteFailure = (context) =>
                        {
                            context.Response.Redirect("/");
                            context.HandleResponse();

                            return Task.CompletedTask;
                        }
                    };
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

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
