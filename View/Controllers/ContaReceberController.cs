using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Model;

namespace View.Controllers
{
    public class ContaReceberController : Controller
    {
        // GET: ContaReceber
        public ActionResult Index(string pesquisa)
        {
            ContaReceberRepositorio repositorio = new ContaReceberRepositorio();
            List<ContaReceber> contas = repositorio.ObterTodos(pesquisa);
            ViewBag.ContasReceber = contas;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, decimal valor, string tipo, string descricao, string status)
        {
            ContaReceber conta = new ContaReceber();
            conta.Nome = nome;
            conta.Valor = valor;
            conta.Tipo = tipo;
            conta.Descricao = descricao;
            conta.Status = status;

            ContaReceberRepositorio repositorio = new ContaReceberRepositorio();
            repositorio.Inserir(conta);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            ContaReceberRepositorio repositorio = new ContaReceberRepositorio();
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            ContaReceberRepositorio repositorio = new ContaReceberRepositorio();
            ContaReceber conta = repositorio.ObterPeloId(id);
            ViewBag.ContaReceber = conta;
            return View();
        }

        public ActionResult Update(int id, string nome, decimal valor, string tipo, string descricao, string status)
        {
            ContaReceber conta = new ContaReceber();
            conta.Nome = nome;
            conta.Valor = valor;
            conta.Tipo = tipo;
            conta.Descricao = descricao;
            conta.Status = status;
            conta.Id = id;
            ContaReceberRepositorio repositorio = new ContaReceberRepositorio();
            repositorio.Atualizar(conta);
            return RedirectToAction("Index");
        }
    }
}