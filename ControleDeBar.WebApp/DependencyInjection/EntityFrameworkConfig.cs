using ControleDeBar.Infraestrutura.OrmT.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.WebApp.DependencyInjection;

public static class EntityFrameworkConfig
{
    public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["SQL_CONNECTION_STRING"];

        services.AddDbContext<ControleDeBarDbContext>(
            options => options.UseSqlServer(connectionString));
    }
}
