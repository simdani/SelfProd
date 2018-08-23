using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SelfProd.Entities.Models;
using SelfProd.Repositories;
using SelfProd.Repositories.Interfaces;
using SelfProd.Services;
using SelfProd.Services.Interfaces;

namespace SelfProd.Configurations
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddAllDependencies(this IServiceCollection service)
        {
            return service
                .AddRepositoryDependencies()
                .AddServicesDependencies();
        }

        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection service)
        {
            return service
                .AddScoped<IRepository<Note>, NotesRepository>();
        }

        public static IServiceCollection AddServicesDependencies(this IServiceCollection service)
        {
            return service
                .AddScoped<INotesService, NotesService>();
        }
    }
}
