using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Application.Mappings;
using ProgramaStarter.Application.Services;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Domain.Interfaces;
using ProgramaStarter.Infra.Data.Context;
using ProgramaStarter.Infra.Data.Repositories;

namespace ProgramaStarter.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


        services.AddScoped<IRepository<ProgramaStart>, ProgramaStartRepository>();
        services.AddScoped<IRepository<Modulo>, ModuloRepository>();

        services.AddScoped<IProgramaStartService, ProgramaStartService>();
        services.AddScoped<IModuloService, ModuloService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
