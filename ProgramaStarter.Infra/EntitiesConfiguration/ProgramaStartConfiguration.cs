using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgramaStarter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaStarter.Infra.Data.EntitiesConfiguration;

internal class ProgramaStartConfiguration : IEntityTypeConfiguration<ProgramaStart>
{
    public void Configure(EntityTypeBuilder<ProgramaStart> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
        builder.Property(p => p.DataInicio).IsRequired();
        builder.Property(p => p.DataFim).IsRequired();
    }
}

