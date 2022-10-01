using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Infra.Data.Identity;

namespace ProgramaStarter.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Starter> Starters { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Daily> Dailys { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Programa> Programas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
