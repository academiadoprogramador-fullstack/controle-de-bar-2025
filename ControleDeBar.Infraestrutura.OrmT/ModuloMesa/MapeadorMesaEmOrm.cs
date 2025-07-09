﻿using ControleDeBar.Dominio.ModuloMesa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeBar.Infraestrutura.OrmT.ModuloMesa;

public class MapeadorMesaEmOrm : IEntityTypeConfiguration<Mesa>
{
    public void Configure(EntityTypeBuilder<Mesa> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Numero)
            .IsRequired();

        builder.Property(x => x.Capacidade)
            .IsRequired();

        builder.Property(x => x.EstaOcupada)
            .IsRequired();
    }
}
