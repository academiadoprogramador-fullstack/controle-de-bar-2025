using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infraestrutura.Orm.Compartilhado;

namespace ControleDeBar.Infraestrutura.Orm.ModuloGarcom;

public class RepositorioGarcomEmOrm : RepositorioBaseEmOrm<Garcom>, IRepositorioGarcom
{
    public RepositorioGarcomEmOrm(ControleDeBarDbContext contexto) : base(contexto) { }
}