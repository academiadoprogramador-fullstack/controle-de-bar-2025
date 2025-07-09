using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrutura.OrmT.Compartilhado;

namespace ControleDeBar.Infraestrutura.OrmT.ModuloMesa;

public class RepositorioMesaEmOrm : RepositorioBaseEmOrm<Mesa>, IRepositorioMesa
{
    public RepositorioMesaEmOrm(ControleDeBarDbContext dbContext) : base(dbContext)
    {
    }
}
