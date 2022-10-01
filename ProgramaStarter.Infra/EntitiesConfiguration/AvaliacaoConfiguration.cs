using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgramaStarter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaStarter.Infra.Data.EntitiesConfiguration;

internal class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
{
    public void Configure(EntityTypeBuilder<Avaliacao> builder)
    {
        builder.HasKey(ps => ps.Id);
        builder.Property(ps => ps.Nota).HasPrecision(2, 2).IsRequired();

        builder.HasOne(ps => ps.Starter).WithMany(s => s.Avaliacoes)
                .HasForeignKey(ps => ps.StarterId);
        builder.HasOne(ps => ps.Projeto).WithMany(p => p.Avaliacoes)
                .HasForeignKey(ps => ps.ProjetoId);
    }
}
