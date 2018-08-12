using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblioAspNetCoreEF1.Data;
using BiblioAspNetCoreEF1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiblioAspNetCoreEF1.Controllers
{
    public class EditorasController : Controller
    {
        ContextoGeral db;

        public EditorasController(ContextoGeral db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Editoras.ToList());
        }

        public IActionResult Cadastro(int id)
        {
            var model = new Editora();
            if (id > 0)
            {
                model = db.Editoras.Include(x => x.Livros).FirstOrDefault(x => x.EditoraId == id);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(Editora editora)
        {
            var problemas = new List<string>();

            if (string.IsNullOrEmpty(editora.Nome))
                problemas.Add("Informe o nome!");

            if (problemas.Count == 0)
            {
                bool cadastrou = false;
                if (editora.EditoraId > 0)
                {
                    var cadastro = db.Editoras.Include(x => x.Livros).FirstOrDefault(x => x.EditoraId == editora.EditoraId);
                    if (cadastro != null)
                    {
                        editora.Livros = cadastro.Livros;

                        cadastro.Nome = editora.Nome;
                        cadastrou = db.SaveChanges() > 0;                        
                    }
                }
                else
                {
                    db.Editoras.Add(editora);
                    cadastrou = db.SaveChanges() > 0;
                }
                if (cadastrou)
                    return RedirectToAction("Index");
            }

            ViewBag.Problemas = problemas;
            return View(editora);
        }

        public IActionResult Excluir(int id)
        {
            if (id > 0)
            {
                var cadastro = db.Editoras.FirstOrDefault(x => x.EditoraId == id);
                if (cadastro != null)
                {
                    db.Editoras.Remove(cadastro);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}