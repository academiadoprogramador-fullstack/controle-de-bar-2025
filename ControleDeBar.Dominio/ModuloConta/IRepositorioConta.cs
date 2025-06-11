namespace ControleDeBar.Dominio.ModuloConta;

public interface IRepositorioConta
{
    void CadastrarConta(Conta conta);
    void Atualizar();
    Conta SelecionarPorId(Guid idRegistro);
    List<Conta> SelecionarContas();
}
