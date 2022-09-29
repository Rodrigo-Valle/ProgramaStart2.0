using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgramaStarter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaStarter.Infra.Data.EntitiesConfiguration;

internal class ProjetoStarterConfiguration : IEntityTypeConfiguration<ProjetoStarter>
{
    public void Configure(EntityTypeBuilder<ProjetoStarter> builder)
    {
        builder.HasKey(ps => ps.Id);
        builder.Property(ps => ps.Avaliacao).HasPrecision(2, 2).IsRequired();

        builder.HasOne(ps => ps.Starter).WithMany(s => s.ProjetoStarter)
                .HasForeignKey(ps => ps.StarterId);
        builder.HasOne(ps => ps.Projeto).WithMany(p => p.ProjetoStarter)
                .HasForeignKey(ps => ps.ProjetoId);
    }
}
