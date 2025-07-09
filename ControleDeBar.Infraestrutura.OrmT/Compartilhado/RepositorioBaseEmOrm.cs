using ControleDeBar.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infraestrutura.OrmT.Compartilhado;

public class RepositorioBaseEmOrm<T> where T : EntidadeBase<T>
{
    protected readonly DbSet<T> registros;

    public RepositorioBaseEmOrm(ControleDeBarDbContext dbContext)
    {
        registros = dbContext.Set<T>();
    }

    public void CadastrarRegistro(T novoRegistro)
    {
        registros.Add(novoRegistro);
    }

    public bool EditarRegistro(Guid idRegistro, T registroEditado)
    {
        var registroSelecionado = registros.FirstOrDefault(x => x.Id == idRegistro);

        if (registroSelecionado is null)
            return false;

        registroSelecionado.AtualizarRegistro(registroEditado);

        return true;
    }

    public bool ExcluirRegistro(Guid idRegistro)
    {
        var registroSelecionado = registros
            .FirstOrDefault(x => x.Id.Equals(idRegistro));

        if (registroSelecionado is null)
            return false;

        registros.Remove(registroSelecionado);

        return true;
    }

    public T? SelecionarRegistroPorId(Guid idRegistro)
    {
        return registros
            .FirstOrDefault(x => x.Id.Equals(idRegistro));
    }

    public List<T> SelecionarRegistros()
    {
        return registros.ToList();
    }
}
