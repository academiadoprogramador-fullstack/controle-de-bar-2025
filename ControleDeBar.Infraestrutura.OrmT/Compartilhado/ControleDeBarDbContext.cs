using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infraestrutura.OrmT.Compartilhado;

public class ControleDeBarDbContext : DbContext
{
    public ControleDeBarDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(ControleDeBarDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }
}
