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
    public class LivrosController : Controller
    {
        ILivrosRep livrosRep;
        IEditorasRep editorasRep;

        public LivrosController(ILivrosRep livrosRep, IEditorasRep editorasRep)
        {
            this.livrosRep = livrosRep;
            this.editorasRep = editorasRep;
        }

        public IActionResult Index()
        {
            return View(livrosRep.Listar());
        }

        public IActionResult Cadastro(int id)
        {
            var model = new LivroCadVM();
            var livro = livrosRep.Localizar(id, true);
            if (livro != null)
            {
                model.LivroId = livro.LivroId;
                model.Titulo = livro.Titulo;
                model.EditoraId = livro.Editora?.EditoraId ?? 0;
                model.Autores = livro.Autores;
            }
            model.Editoras = editorasRep.Listar();
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(LivroCadVM model)
        {
            Livro livro = null;
            var editora = editorasRep.Localizar(model.EditoraId, false);
            if (model.LivroId > 0)
            {
                livro = livrosRep.Localizar(model.LivroId, false);
                if (livro != null)
                    livro.Alterar(model.Titulo, editora);
            }
            else
            {
                livro = new Livro(model.Titulo, editora);
            }

            //aqui validação e retorno se não passar

            if (livro != null && livrosRep.Salvar(livro) > 0)
                return RedirectToAction(nameof(Index));

            model.Editoras = editorasRep.Listar();
            if (model.LivroId > 0)
                model.Autores = livrosRep.ListarAutoresRelacionados(model.LivroId);
            return View(model);
        }

        public IActionResult Excluir(int id)
        {
            livrosRep.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DelAutor(int livroId, int autorId)
        {
            if (livroId <= 0 || autorId <= 0)
                return RedirectToAction(nameof(Index));

            livrosRep.ExcluirAutor(livroId, autorId);
            return RedirectToAction(nameof(Cadastro), new { id = livroId });
        }

        public IActionResult CadAutor(int livroId)
        {
            var model = new LivroAutorCadVM();
            var livro = livrosRep.Localizar(livroId, false);

            var autores = livrosRep.ListarAutoresNaoRelacionados(livroId);
            if (autores != null)
                autores.ForEach(x => model.Autores.Add(new AutorCheckBox
                {
                    AutorId = x.AutorId,
                    Nome = x.Nome
                }));

            model.LivroId = livro.LivroId;
            model.Titulo = livro.Titulo;
            return View(model);
        }

        [HttpPost]
        public IActionResult CadAutor(LivroAutorCadVM model)
        {
            List<int> novos = new List<int>();
            foreach (var autor in model.Autores.Where(x => x.Selected))
                novos.Add(autor.AutorId);

            if (novos.Count > 0)
                livrosRep.RelacionarNovosAutores(novos, model.LivroId);

            return RedirectToAction(nameof(Cadastro), new { id = model.LivroId });
        }
    }
}