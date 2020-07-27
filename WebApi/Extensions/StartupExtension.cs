using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;
using WebApi.Repositories.Implements;
using WebApi.Repositories.Interfaces;
using WebApi.Services.Implements;
using WebApi.Services.Interfaces;

namespace WebApi.Extensions
{
    public static class StartupExtension
    {
        public static void ResolveRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        public static void ResolveService(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();
        }
    }
}
