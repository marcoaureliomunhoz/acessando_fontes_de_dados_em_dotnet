using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblioAspNetCoreEF1.Data;
using BiblioAspNetCoreEF1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiblioAspNetCoreEF1.Controllers
{
    public class AutoresController : Controller
    {
        ContextoGeral db;

        public AutoresController(ContextoGeral db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Autores.ToList());
        }

        public IActionResult Cadastro(int id)
        {
            var model = new Autor();
            if (id > 0)
            {
                model = db.Autores.FirstOrDefault(x => x.AutorId == id);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(Autor autor)
        {
            var problemas = new List<string>();

            if (string.IsNullOrEmpty(autor.Nome) || autor.Nome.Length < Autor.NomeMinLength || autor.Nome.Length > Autor.NomeMaxLength)
                problemas.Add($"O nome deve ter pelo menos {Autor.NomeMinLength} caracteres e no máximo {Autor.NomeMaxLength}.");

            if (problemas.Count == 0)
            {
                var cadastrou = false;
                if (autor.AutorId > 0)
                {
                    var cadastro = db.Autores.FirstOrDefault(x => x.AutorId == autor.AutorId);
                    if (cadastro != null)
                    {
                        cadastro.Nome = autor.Nome;
                        cadastrou = db.SaveChanges() > 0;
                    }
                }
                else
                {
                    db.Autores.Add(autor);
                    cadastrou = db.SaveChanges() > 0;
                }
                if (cadastrou)
                    return RedirectToAction("Index");
            }

            ViewBag.Problemas = problemas;
            return View(autor);
        }

        public IActionResult Excluir(int id)
        {
            if (id > 0)
            {
                var cadastro = db.Autores.FirstOrDefault(x => x.AutorId == id);
                if (cadastro != null)
                {
                    db.Remove(cadastro);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}