using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer.Areas.Identity.Data;
using IdentityServer.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IdentityServer.Areas.Identity.IdentityHostingStartup))]
namespace IdentityServer.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TodoistContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TodoistContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TodoistContext>()
                    .AddDefaultTokenProviders();
                //.AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();
            });
        }
    }

    public class CustomClaimsPrincipalFactory : IUserClaimsPrincipalFactory<ApplicationUser>
    {
        public async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = new ClaimsPrincipal();
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
            });
            return await Task.FromResult(principal);
        }
    }
}