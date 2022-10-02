using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Application.Mappings;
using ProgramaStarter.Application.Services;
using ProgramaStarter.Domain.Account;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Domain.Interfaces;
using ProgramaStarter.Infra.Data.Context;
using ProgramaStarter.Infra.Data.Identity;
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

        services.AddIdentity<ApplicationUser,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

        services.AddScoped<IRepository<Programa>, ProgramaRepository>();
        services.AddScoped<IRepository<Modulo>, ModuloRepository>();
        services.AddScoped<IRepository<Tecnologia>, TecnologiaRepository>();
        services.AddScoped<IRepository<Usuario>, UsuarioRepository>();
        services.AddScoped<IRepository<Projeto>, ProjetoRepository>();
        services.AddScoped<IRepository<Starter>, StarterRepository>();
        services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();

        services.AddScoped<IProgramaService, ProgramaService>();
        services.AddScoped<IModuloService, ModuloService>();
        services.AddScoped<ITecnologiaService, TecnologiaService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IProjetoService, ProjetoService>();
        services.AddScoped<IStarterService, StarterService>();
        services.AddScoped<IAvaliacaoService, AvaliacaoService>();

        services.AddScoped<IAuthenticate, AuthenticateService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
