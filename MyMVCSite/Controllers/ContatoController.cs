using Microsoft.AspNetCore.Mvc;
using MyMVCSite.Models;
using MyMVCSite.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCSite.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            var contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarContatoId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarContatoId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try {
                bool apagado =_contatoRepositorio.ExcluirContatoId(id);
                if (apagado){
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                } else
                {
                    TempData["MensagemErro"] = "Não foi possível apagar o contato";
                }
                return RedirectToAction("Index");
            } catch (System.Exception erro){
                TempData["MensagemErro"] = "Não foi possível apagar o contato";
                return RedirectToAction("Index");
            }

            
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            } catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }

}
