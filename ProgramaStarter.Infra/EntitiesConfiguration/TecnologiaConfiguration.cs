using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgramaStarter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaStarter.Infra.Data.EntitiesConfiguration;

internal class TecnologiaConfiguration : IEntityTypeConfiguration<Tecnologia>
{
    public void Configure(EntityTypeBuilder<Tecnologia> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Descricao).HasMaxLength(400).IsRequired();
        builder.Property(t => t.Nome).HasMaxLength(100).IsRequired();

    }
}
