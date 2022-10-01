using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgramaStarter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaStarter.Infra.Data.EntitiesConfiguration;

internal class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
{
    public void Configure(EntityTypeBuilder<Grupo> builder)
    {
        builder.HasKey(g => g.Id);

        builder.HasOne(g => g.Programa).WithMany(p => p.Grupos)
                .HasForeignKey(g => g.ProgramaId);
        builder.HasOne(g => g.Tecnologia).WithMany(t => t.Grupos)
                .HasForeignKey(g => g.ProgramaId);

        builder.HasOne(g => g.ScrumMaster).WithOne(u => u.Grupo);
                
        
    }
}

