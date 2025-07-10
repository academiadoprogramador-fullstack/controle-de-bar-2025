using ControleDeBar.Dominio.ModuloConta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeBar.Infraestrutura.Orm.ModuloConta;

public class MapeadorContaEmOrm : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Titular)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Abertura)
            .IsRequired();

        builder.Property(x => x.Fechamento)
            .IsRequired(false);

        builder.Property(x => x.EstaAberta)
            .IsRequired();

        builder.HasOne(c => c.Garcom)
            .WithMany();

        builder.HasOne(c => c.Mesa)
            .WithMany();

        builder.HasMany(c => c.Pedidos)
            .WithOne(p => p.Conta);
    }
}
