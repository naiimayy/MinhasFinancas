using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ClientePessoaFisicaController : Controller
    {
        // GET: ClientePessoaFisica
        public ActionResult Index(string pesquisa)
        {
            ClientePessoaFisicaRepositorio repositorio = new ClientePessoaFisicaRepositorio();
            List<ClientePessoaFisica> clientes = repositorio.ObterTodos(pesquisa);
            ViewBag.ClientePessoaFisica = clientes;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, string cpf, DateTime dataNascimento, string rg, string sexo)
        {
            ClientePessoaFisica cliente = new ClientePessoaFisica();
            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.Data_nascimento = dataNascimento;
            cliente.Rg = rg;
            cliente.Sexo = sexo;

            ClientePessoaFisicaRepositorio repositorio = new ClientePessoaFisicaRepositorio();
            repositorio.Inserir(cliente);
            return RedirectToAction("Index");
        }

    }
}