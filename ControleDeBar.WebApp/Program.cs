using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloConta;
using ControleDeBar.Infraestrutura.Arquivos.ModuloProduto;
using ControleDeBar.Infraestrutura.Orm.ModuloGarcom;
using ControleDeBar.Infraestrutura.Orm.ModuloMesa;
using ControleDeBar.Infraestrutura.Orm.ModuloProduto;
using ControleDeBar.WebApp.DependencyInjection;

namespace ControleDeBar.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped(_ => new ContextoDados(true));
        builder.Services.AddScoped<IRepositorioMesa, RepositorioMesaEmOrm>();
        builder.Services.AddScoped<IRepositorioGarcom, RepositorioGarcomEmOrm>();
        builder.Services.AddScoped<IRepositorioProduto, RepositorioProdutoEmOrm>();
        builder.Services.AddScoped<IRepositorioConta, RepositorioContaEmArquivo>();

        builder.Services.AddEntityFrameworkConfig(builder.Configuration);
        builder.Services.AddSerilogConfig(builder.Logging);

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.UseAntiforgery();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapDefaultControllerRoute();

        app.Run();
    }
}
