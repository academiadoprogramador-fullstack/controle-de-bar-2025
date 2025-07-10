using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infraestrutura.Orm.ModuloGarcom;
using ControleDeBar.Infraestrutura.Orm.ModuloMesa;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infraestrutura.Orm.Compartilhado;

public class ControleDeBarDbContext : DbContext
{
    public DbSet<Mesa> Mesas { get; set; }
    public DbSet<Garcom> Garcons { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Conta> Contas { get; set; }

    public ControleDeBarDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(ControleDeBarDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }
}
