using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloConta;

public class Pedido
{
    public Guid Id { get; set; }
    public Produto Produto { get; set; }
    public Conta Conta { get; set; }
    public int QuantidadeSolicitada { get; set; }

    public Pedido() { }

    public Pedido(Produto produto, int quantidadeEscolhida, Conta conta) : this()
    {
        Id = Guid.NewGuid();
        Produto = produto;
        QuantidadeSolicitada = quantidadeEscolhida;
        Conta = conta;
    }

    public decimal CalcularTotalParcial()
    {
        return Produto.Valor * QuantidadeSolicitada;
    }

    public override string ToString()
    {
        return $"{QuantidadeSolicitada}x {Produto}";
    }
}