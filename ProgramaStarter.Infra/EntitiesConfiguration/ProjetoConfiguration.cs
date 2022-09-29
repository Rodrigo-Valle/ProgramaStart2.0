using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramaStarter.Domain.Entities;

namespace ProgramaStarter.Infra.Data.EntitiesConfiguration;

internal class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
{
    public void Configure(EntityTypeBuilder<Projeto> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Etapa).HasMaxLength(100).IsRequired();

        builder.HasOne(d => d.Modulo).WithMany(m => m.Projetos)
                .HasForeignKey(d => d.ModuloId);
    }
}
