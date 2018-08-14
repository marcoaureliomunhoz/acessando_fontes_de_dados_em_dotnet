using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainApp.Entidades;
using DomainApp.Repositorios;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LivrosController : Controller
    {
        ILivrosRep livrosRep;

        public LivrosController(ILivrosRep livrosRep)
        {
            this.livrosRep = livrosRep;
        }

        public IActionResult Index()
        {
            var livros = livrosRep.Listar();
            var model = new List<LivroVM>();
            livros.ForEach(x => model.Add(new LivroVM
            {
                LivroId = x.LivroId,
                Titulo = x.Titulo
            }));
            return View(model);
        }

        public IActionResult Cadastro(int id)
        {
            var model = new LivroCadVM();
            var livro = livrosRep.Localizar(id, true);
            if (livro != null)
            {
                model.LivroId = livro.LivroId;
                model.Titulo = livro.Titulo;
                if (livro.Autores != null)
                    foreach (var x in livro.Autores)
                        model.Autores.Add(new AutorVM
                        {
                            AutorId = x.AutorId,
                            Nome = x.Nome
                        });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(LivroCadVM vm)
        {
            var livro = new Livro(vm.LivroId, vm.Titulo, null);
            vm.Problemas = livro.Problemas;
            if (vm.Problemas.Count == 0)
            {
                if (livrosRep.Salvar(livro) > 0)
                    return RedirectToAction("Index");
            }
            return View(vm);
        }

        public IActionResult Excluir(int id)
        {
            livrosRep.Excluir(id);
            return RedirectToAction("Index");
        }

        public IActionResult CadAutor(int livroId)
        {
            var model = new LivroAutorCadVM();
            var livro = livrosRep.Localizar(livroId, false);
            var autoresNaoVinculados = livrosRep.ListarAutoresNaoVinculados(livroId);
            if (autoresNaoVinculados != null)
                foreach (var x in autoresNaoVinculados)
                    model.Autores.Add(new AutorCheckBox
                    {
                        AutorId = x.AutorId,
                        Nome = x.Nome
                    });

            model.LivroId = livroId;
            ViewBag.Titulo = livro.Titulo;
            return View(model);
        }

        [HttpPost]
        public IActionResult CadAutor(LivroAutorCadVM livroAutorVM)
        {
            List<int> novos = new List<int>();
            foreach (var autor in livroAutorVM.Autores.Where(x => x.Selected))
                novos.Add(autor.AutorId);

            if (novos.Count > 0)
                if (livrosRep.AdicionarAutores(novos, livroAutorVM.LivroId) > 0)
                    return RedirectToAction("Cadastro", new { id = livroAutorVM.LivroId });

            var livro = livrosRep.Localizar(livroAutorVM.LivroId, false);
            ViewBag.Titulo = livro.Titulo;
            return View(livroAutorVM);
        }

        public IActionResult DelAutor(int livroId, int autorId)
        {
            if (livroId > 0 && autorId > 0)
            {
                livrosRep.RemoverAutor(livroId, autorId);
                return RedirectToAction("Cadastro", new { id = livroId });
            }
            return RedirectToAction("Index");
        }
    }
}