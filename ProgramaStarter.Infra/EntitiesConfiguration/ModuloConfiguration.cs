using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramaStarter.Domain.Entities;

namespace ProgramaStarter.Infra.Data.EntitiesConfiguration;

internal class ModuloConfiguration : IEntityTypeConfiguration<Modulo>
{
    public void Configure(EntityTypeBuilder<Modulo> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Nome).HasMaxLength(100).IsRequired();
    }
}
