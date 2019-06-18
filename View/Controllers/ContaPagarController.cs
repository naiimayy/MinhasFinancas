using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ContaPagarController : Controller
    {
        // GET: ContaPagar
        public ActionResult Index(string pesquisa)
        {
            ContaPagarRepositorio repositorio = new ContaPagarRepositorio();
            List<ContaPagar> contas = repositorio.ObterTodos(pesquisa);
            ViewBag.ContasPagar = contas;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, decimal valor, string tipo, string descricao, string status)
        {
            ContaPagar conta = new ContaPagar();
            conta.Nome = nome;
            conta.Valor = valor;
            conta.Tipo = tipo;
            conta.Descricao = descricao;
            conta.Status = status;

            ContaPagarRepositorio repositorio = new ContaPagarRepositorio();
            repositorio.Inserir(conta);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            ContaPagarRepositorio repositorio = new ContaPagarRepositorio();
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            ContaPagarRepositorio repositorio = new ContaPagarRepositorio();
            ContaPagar conta = repositorio.ObterPeloId(id);
            ViewBag.ContaPagar = conta;
            return View();
        }

        public ActionResult Update(int id, string nome, decimal valor, string tipo, string descricao, string status)
        {
            ContaPagar conta = new ContaPagar();
            conta.Nome = nome;
            conta.Valor = valor;
            conta.Tipo = tipo;
            conta.Descricao = descricao;
            conta.Status = status;
            conta.Id = id;
            ContaPagarRepositorio repositorio = new ContaPagarRepositorio();
            repositorio.Atualizar(conta);
            return RedirectToAction("Index");

        }
    }
}