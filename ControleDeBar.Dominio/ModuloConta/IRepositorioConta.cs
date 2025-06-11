namespace ControleDeBar.Dominio.ModuloConta;

public interface IRepositorioConta
{
    void CadastrarConta(Conta conta);

    Conta SelecionarPorId(Guid idRegistro);
    List<Conta> SelecionarContas();
}
