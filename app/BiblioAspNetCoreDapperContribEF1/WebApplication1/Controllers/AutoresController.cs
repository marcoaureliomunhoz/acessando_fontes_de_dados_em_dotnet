using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dominio.Entidades;
using WebApplication1.Dominio.Repositorios;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AutoresController : Controller
    {
        IAutoresRep autoresRep;

        public AutoresController(IAutoresRep autoresRep)
        {
            this.autoresRep = autoresRep;
        }

        public IActionResult Index()
        {
            var autores = autoresRep.Listar();
            var model = new List<AutorVM>();
            autores.ForEach(x => model.Add(new AutorVM
            {
                AutorId = x.AutorId,
                Nome = x.Nome
            }));
            return View(model);
        }

        public IActionResult Cadastro(int id)
        {
            var model = new AutorCadVM();
            var autor = autoresRep.Localizar(id);
            if (autor != null)
            {
                model.AutorId = autor.AutorId;
                model.Nome = autor.Nome;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(AutorCadVM vm)
        {
            var autor = new Autor(vm.AutorId, vm.Nome);
            vm.Problemas = autor.Problemas().ToList();
            if (vm.Problemas.Count == 0)
            {
                if (autoresRep.Salvar(autor) > 0)
                    return RedirectToAction("Index");
            }
            return View(vm);
        }

        public IActionResult Excluir(int id)
        {
            autoresRep.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}