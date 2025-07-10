using ControleDeBar.Dominio.ModuloConta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeBar.Infraestrutura.Orm.ModuloConta;

public class MapeadorPedidoEmOrm : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.QuantidadeSolicitada)
            .IsRequired();

        builder.HasOne(p => p.Produto)
            .WithMany(pr => pr.Pedidos)
            .IsRequired();
    }
}
