using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramaStarter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaStarter.Infra.Data.EntitiesConfiguration;

internal class StarterConfiguration : IEntityTypeConfiguration<Starter>
{
    public void Configure(EntityTypeBuilder<Starter> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Letras).HasMaxLength(4).IsRequired();
        builder.Property(s => s.Nome).HasMaxLength(100).IsRequired();

        builder.HasOne(s => s.Grupo).WithMany(g => g.Starters)
                .HasForeignKey(s => s.GrupoId);
    }
}
