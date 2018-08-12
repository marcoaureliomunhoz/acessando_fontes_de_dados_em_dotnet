using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaAspNetCoreEF1.Data;
using AgendaAspNetCoreEF1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAspNetCoreEF1.Controllers
{
    public class EstadosController : Controller
    {
        ContextoGeral db;

        public EstadosController(ContextoGeral db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var model = db.Estados.ToList();
            return View(model);
        }

        public IActionResult Cadastro(string id)
        {
            var model = new Estado();
            if (!string.IsNullOrEmpty(id) && !id.Equals("_"))
            {
                model = db.Estados.FirstOrDefault(x => x.UF == id);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(Estado estado)
        {
            ViewBag.problemas = new List<string>();

            if (string.IsNullOrEmpty(estado.UF))
                ViewBag.problemas.Add("Informe a UF!");

            if (string.IsNullOrEmpty(estado.Nome))
                ViewBag.problemas.Add("Informe o nome!");

            if (ViewBag.problemas.Count <= 0)
            {
                var cadastro = db.Estados.FirstOrDefault(x => x.UF == estado.UF);

                if (cadastro == null)
                    db.Estados.Add(estado);
                else
                {
                    cadastro.Nome = estado.Nome;
                }

                if (db.SaveChanges() > 0)
                    return RedirectToAction("Index");
            }

            return View(estado);
        }

        public IActionResult Excluir(string id)
        {
            if (!string.IsNullOrEmpty(id) && !id.Equals("_"))
            {
                var cadastro = db.Estados.FirstOrDefault(x => x.UF == id);
                if (cadastro != null)
                {
                    db.Estados.Remove(cadastro);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}