using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrutura.Orm.Compartilhado;

namespace ControleDeBar.Infraestrutura.Orm.ModuloMesa;

public class RepositorioMesaEmOrm :  RepositorioBaseEmOrm<Mesa>, IRepositorioMesa
{
    public RepositorioMesaEmOrm(ControleDeBarDbContext contexto) : base(contexto)
    {
    }
}
