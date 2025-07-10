using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infraestrutura.Orm.Compartilhado;

namespace ControleDeBar.Infraestrutura.Orm.ModuloProduto;

public class RepositorioProdutoEmOrm : RepositorioBaseEmOrm<Produto>, IRepositorioProduto
{
    public RepositorioProdutoEmOrm(ControleDeBarDbContext contexto) : base(contexto)
    {
    }
}