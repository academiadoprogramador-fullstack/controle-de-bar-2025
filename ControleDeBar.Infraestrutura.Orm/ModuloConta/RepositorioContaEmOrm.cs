using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infraestrutura.Orm.ModuloConta;

public class RepositorioContaEmOrm : IRepositorioConta
{
    private readonly DbSet<Conta> contas;

    public RepositorioContaEmOrm(ControleDeBarDbContext contexto)
    {
        contas = contexto.Contas;
    }

    public void CadastrarConta(Conta conta)
    {
        contas.Add(conta);
    }

    public List<Conta> SelecionarContas()
    {
        return contas
            .Include(c => c.Garcom)
            .Include(c => c.Mesa)
            .ToList();
    }

    public List<Conta> SelecionarContasAbertas()
    {
        return contas
            .Where(c => c.EstaAberta)
            .Include(c => c.Garcom)
            .Include(c => c.Mesa)
            .ToList();
    }

    public List<Conta> SelecionarContasFechadas()
    {
        return contas
            .Where(c => !c.EstaAberta)
            .Include(c => c.Garcom)
            .Include(c => c.Mesa)
            .ToList();
    }

    public List<Conta> SelecionarContasPorPeriodo(DateTime data)
    {
        return contas
            .Where(c => !c.EstaAberta)
            .Where(c => c.Fechamento.GetValueOrDefault().Date.Equals(data))
            .Include(c => c.Garcom)
            .Include(c => c.Mesa)
            .ToList();
    }

    public Conta? SelecionarPorId(Guid idRegistro)
    {
        return contas
            .Include(c => c.Garcom)
            .Include(c => c.Mesa)
            .Include(c => c.Pedidos)
            .FirstOrDefault(c => c.Id.Equals(idRegistro));
    }
}