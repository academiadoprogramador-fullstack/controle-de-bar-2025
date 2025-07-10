﻿using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infraestrutura.Orm.Compartilhado;
using ControleDeBar.WebApp.Extensions;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

[Route("garcons")]
public class GarcomController : Controller
{
    private readonly ControleDeBarDbContext contexto;
    private readonly IRepositorioGarcom repositorioGarcom;

    public GarcomController(ControleDeBarDbContext contexto, IRepositorioGarcom repositorioGarcom)
    {
        this.contexto = contexto;
        this.repositorioGarcom = repositorioGarcom;
    }

    public IActionResult Index()
    {
        var registros = repositorioGarcom.SelecionarRegistros();

        var visualizarVM = new VisualizarGarconsViewModel(registros);

        return View(visualizarVM);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarGarcomViewModel();

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(CadastrarGarcomViewModel cadastrarVM)
    {
        var registros = repositorioGarcom.SelecionarRegistros();

        foreach (var item in registros)
        {
            if (item.Nome.Equals(cadastrarVM.Nome))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe um garçom registrado com este nome.");
                break;
            }

            if (item.Cpf.Equals(cadastrarVM.Cpf))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe um garçom registrado com este CPF.");
                break;
            }
        }

        if (!ModelState.IsValid)
            return View(cadastrarVM);

        var entidade = cadastrarVM.ParaEntidade();

        var transacao = contexto.Database.BeginTransaction();

        try
        {
            repositorioGarcom.CadastrarRegistro(entidade);

            contexto.SaveChanges();

            transacao.Commit();
        }
        catch
        {
            transacao.Rollback();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public ActionResult Editar(Guid id)
    {
        var registroSelecionado = repositorioGarcom.SelecionarRegistroPorId(id);

        var editarVM = new EditarGarcomViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Cpf
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    [ValidateAntiForgeryToken]
    public ActionResult Editar(Guid id, EditarGarcomViewModel editarVM)
    {
        var registros = repositorioGarcom.SelecionarRegistros();

        foreach (var item in registros)
        {
            if (!item.Id.Equals(id) && item.Nome.Equals(editarVM.Nome))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe um garçom registrado com este nome.");
                break;
            }

            if (!item.Id.Equals(id) && item.Cpf.Equals(editarVM.Cpf))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe um garçom registrado com este CPF.");
                break;
            }
        }

        if (!ModelState.IsValid)
            return View(editarVM);

        var entidadeEditada = editarVM.ParaEntidade();

        var transacao = contexto.Database.BeginTransaction();

        try
        {
            repositorioGarcom.EditarRegistro(id, entidadeEditada);

            contexto.SaveChanges();

            transacao.Commit();
        }
        catch 
        {
            transacao.Rollback();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id)
    {
        var registroSelecionado = repositorioGarcom.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirGarcomViewModel(registroSelecionado.Id, registroSelecionado.Nome);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    public IActionResult ExcluirConfirmado(Guid id)
    {
        var transacao = contexto.Database.BeginTransaction();

        try
        {
            repositorioGarcom.ExcluirRegistro(id);

            contexto.SaveChanges();

            transacao.Commit();
        }
        catch
        {
            transacao.Rollback();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("detalhes/{id:guid}")]
    public IActionResult Detalhes(Guid id)
    {
        var registroSelecionado = repositorioGarcom.SelecionarRegistroPorId(id);

        var detalhesVM = new DetalhesGarcomViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Cpf
        );

        return View(detalhesVM);
    }
}
