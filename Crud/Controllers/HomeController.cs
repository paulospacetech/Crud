using Crud.Aplicacao;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        private PessoaAplicacao pessoaAplicacao; 

        public HomeController()
        {
            pessoaAplicacao = new PessoaAplicacao();
        }
        // GET: Home
        public ActionResult Index()
        {
            var lista = pessoaAplicacao.ListarTodos();

            return View(lista);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cadastrar(Pessoa p)
        {
            if (ModelState.IsValid)
            {
                pessoaAplicacao.Salvar(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult Editar(int id)
        {
            var pessoa = pessoaAplicacao.ListarPorId(id);
            if(pessoa == null)
                return HttpNotFound();
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Editar(Pessoa p)
        {
            if (ModelState.IsValid)
            {
                pessoaAplicacao.Salvar(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult Detalhe(int id)
        {
            var p = pessoaAplicacao.ListarPorId(id);
            if(p == null)
            {
                return HttpNotFound();

            }
            return View(p);
        }

        public ActionResult Excluir(int id)
        {
            var p = pessoaAplicacao.ListarPorId(id);
            if(p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult confirmarExclusao(int id)
        {
            pessoaAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}