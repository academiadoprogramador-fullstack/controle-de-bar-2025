using ControleDeBar.Dominio.ModuloProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeBar.Infraestrutura.Orm.ModuloProduto;

public class MapeadorProdutoEmOrm : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Nome)
            .IsRequired();

        builder.Property(x => x.Valor)
            .IsRequired();
    }
}