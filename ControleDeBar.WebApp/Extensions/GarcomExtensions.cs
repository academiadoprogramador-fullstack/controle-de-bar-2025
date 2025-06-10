using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.WebApp.Models;

namespace ControleDeBar.WebApp.Extensions;

public static class GarcomExtensions
{
    public static Garcom ParaEntidade(this FormularioGarcomViewModel formularioVM)
    {
        return new Garcom(formularioVM.Nome, formularioVM.Cpf);
    }

    public static DetalhesGarcomViewModel ParaDetalhesVM(this Garcom mesa)
    {
        return new DetalhesGarcomViewModel(
                mesa.Id,
                mesa.Nome,
                mesa.Cpf
        );
    }
}
