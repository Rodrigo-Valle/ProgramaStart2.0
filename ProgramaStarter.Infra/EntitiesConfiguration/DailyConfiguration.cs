using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramaStarter.Domain.Entities;

namespace ProgramaStarter.Infra.Data.EntitiesConfiguration;

internal class DailyConfiguration : IEntityTypeConfiguration<Daily>
{
    public void Configure(EntityTypeBuilder<Daily> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Presenca).IsRequired();
        builder.Property(d => d.Data).IsRequired();
        builder.Property(d => d.Fazendo).HasMaxLength(450);
        builder.Property(d => d.Feito).HasMaxLength(450);
        builder.Property(d => d.Impedimentos).HasMaxLength(450);

        builder.HasOne(d => d.Starter).WithMany(s => s.Daylies)
                .HasForeignKey(d => d.StarterId);
        builder.HasOne(d => d.Modulo).WithMany(m => m.Daylies)
                .HasForeignKey(d => d.ModuloId);
    }
}
