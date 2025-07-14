using ControleDeBar.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.WebApp.Orm;

public static class DatabaseOperations
{
    public static void ApplyMigrations(this IHost app)
    {
        var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ControleDeBarDbContext>();

        dbContext.Database.Migrate();
    }
}
