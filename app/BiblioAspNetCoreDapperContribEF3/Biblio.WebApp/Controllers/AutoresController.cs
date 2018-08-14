using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblio.DomainApp.Entidades;
using Biblio.DomainApp.Repositorios;
using Biblio.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblio.WebApp.Controllers
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
            return View(autoresRep.Listar());
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
        public IActionResult Cadastro(AutorCadVM model)
        {
            Autor altor = null;
            if (model.AutorId > 0)
            {
                altor = autoresRep.Localizar(model.AutorId);
                if (altor != null)
                    altor.Alterar(model.Nome);
            }
            else
            {
                altor = new Autor(model.Nome);
            }

            //aqui validação e retorno se não passar

            if (altor != null && autoresRep.Salvar(altor) > 0)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public IActionResult Excluir(int id)
        {
            autoresRep.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}