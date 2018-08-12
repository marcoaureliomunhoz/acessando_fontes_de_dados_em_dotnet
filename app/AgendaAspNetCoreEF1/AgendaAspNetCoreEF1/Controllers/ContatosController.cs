using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaAspNetCoreEF1.Data;
using AgendaAspNetCoreEF1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAspNetCoreEF1.Controllers
{
    public class ContatosController : Controller
    {
        ContextoGeral db;

        public ContatosController(ContextoGeral db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var model = db.Contatos.ToList();
            return View(model);
        }

        public IActionResult Cadastro(int id)
        {
            ViewBag.Estados = null;
            var model = new Contato();

            ViewBag.Estados = db.Estados.ToList();
            if (id > 0)
            {
                model = db.Contatos.FirstOrDefault(x => x.ContatoId == id);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(Contato contato)
        {
            bool resultOperacao = false;

            ViewBag.problemas = new List<string>();

            if (string.IsNullOrEmpty(contato.Nome))
                ViewBag.problemas.Add("Informe o nome!");

            if (string.IsNullOrEmpty(contato.Valor))
                ViewBag.problemas.Add("Informe o valor!");

            if (string.IsNullOrEmpty(contato.UF))
                ViewBag.problemas.Add("Informe a UF!");

            ViewBag.Estados = db.Estados.ToList();
            if (ViewBag.problemas.Count <= 0)
            {
                if (contato.ContatoId > 0)
                {
                    var cadastro = db.Contatos.FirstOrDefault(x => x.ContatoId == contato.ContatoId);
                    if (cadastro != null)
                    {
                        cadastro.Nome = contato.Nome;
                        cadastro.Valor = contato.Valor;
                        cadastro.UF = contato.UF;
                        resultOperacao = db.SaveChanges() > 0;
                    }
                }
                else
                {
                    db.Contatos.Add(contato);
                    resultOperacao = db.SaveChanges() > 0;
                }
            }
            if (resultOperacao)
                return RedirectToAction("Index");

            return View(contato);
        }

        public IActionResult Excluir(int id)
        {
            if (id > 0)
            {
                var cadastro = db.Contatos.FirstOrDefault(x => x.ContatoId == id);
                if (cadastro != null)
                {
                    db.Contatos.Remove(cadastro);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}