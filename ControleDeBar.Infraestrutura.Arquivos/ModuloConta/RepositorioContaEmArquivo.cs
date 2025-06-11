using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;

namespace ControleDeBar.Infraestrutura.Arquivos.ModuloConta;

public class RepositorioContaEmArquivo : IRepositorioConta
{
    private readonly ContextoDados contexto;
    protected readonly List<Conta> registros;

    public RepositorioContaEmArquivo(ContextoDados contexto)
    {
        this.contexto = contexto;
        registros = contexto.Contas;
    }

    public void CadastrarConta(Conta novaConta)
    {
        registros.Add(novaConta);

        contexto.Salvar();
    }

    public List<Conta> SelecionarContas()
    {
        return registros;
    }

    public Conta SelecionarPorId(Guid idRegistro)
    {
        foreach (var item in registros)
        {
            if (item.Id == idRegistro)
                return item;
        }

        return null;
    }
}
