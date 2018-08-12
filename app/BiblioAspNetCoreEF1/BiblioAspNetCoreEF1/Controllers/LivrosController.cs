using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblioAspNetCoreEF1.Data;
using BiblioAspNetCoreEF1.Models;
using BiblioAspNetCoreEF1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiblioAspNetCoreEF1.Controllers
{
    public class LivrosController : Controller
    {
        ContextoGeral db;

        public LivrosController(ContextoGeral db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Livros.Include(x => x.Editora).ToList());
        }

        private List<Autor> GetAutores(int livroId)
        {
            return db.Autores.FromSql(
                        $"select " +
                        $"  a.AutorId, a.Nome " +
                        $"from " +
                        $"  Autor a, Livro_Autor la " +
                        $"where " +
                        $"  a.AutorId = la.AutorId and " +
                        $"  la.LivroId = {livroId}"
                    ).ToList();
        }

        public IActionResult Cadastro(int id)
        {
            Livro livro = null;
            List<Autor> autores = null;
            if (id > 0)
            {
                livro = db.Livros.Include(x => x.Editora).FirstOrDefault(x => x.LivroId == id);
                if (livro != null)
                    autores = this.GetAutores(id);
            }
            var model = new LivroVM(livro, autores);
            ViewBag.Editoras = db.Editoras.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(LivroVM livro)
        {
            if (livro.EditoraId > 0)
                livro.Editora = db.Editoras.FirstOrDefault(x => x.EditoraId == livro.EditoraId);

            if (livro.LivroId > 0)
                livro.Autores = this.GetAutores(livro.LivroId);

            var cadastrou = false;
            if (livro.LivroId > 0)
            {
                var cadastro = db.Livros.Include(x => x.Editora).FirstOrDefault(x => x.LivroId == livro.LivroId);
                if (cadastro != null)
                {
                    cadastro.Titulo = livro.Titulo;
                    cadastro.Editora = livro.Editora;
                    cadastrou = db.SaveChanges() > 0;
                }
            }
            else
            {
                var cadastro = new Livro(livro.LivroId, livro.Titulo, livro.Editora);
                db.Livros.Add(cadastro);
                cadastrou = db.SaveChanges() > 0;
            }
            if (cadastrou)
                return RedirectToAction("Index");

            ViewBag.Editoras = db.Editoras.ToList();
            return View(livro);
        }

        public IActionResult Excluir(int id)
        {
            if (id > 0)
            {
                var cadastro = db.Livros.FirstOrDefault(x => x.LivroId == id);
                if (cadastro != null)
                {
                    db.Livros.Remove(cadastro);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult CadAutor(int livroId)
        {
            var model = new LivroAutorVM();
            var autores = db.Autores.ToList();
            var autoresLivro = db.LivroAutor.Where(x => x.LivroId == livroId).ToList();
            foreach (var autor in autores)
            {
                //retorna somente os autores ainda não vinculados
                if (autoresLivro.Count == 0 || autoresLivro.Count(x => x.AutorId == autor.AutorId) == 0)
                {
                    model.Autores.Add(new AutorCheckBox
                    {
                        AutorId = autor.AutorId,
                        Nome = autor.Nome
                    });
                }
            }
            model.LivroId = livroId;
            ViewBag.Titulo = db.Livros.FirstOrDefault(x => x.LivroId == livroId).Titulo;
            return View(model);
        }

        [HttpPost]
        public IActionResult CadAutor(LivroAutorVM livroAutorVM)
        {
            int novos = 0;
            foreach (var autor in livroAutorVM.Autores.Where(x => x.Selected))
            {
                db.LivroAutor.Add(new LivroAutor
                {
                    AutorId = autor.AutorId,
                    LivroId = livroAutorVM.LivroId
                });
                novos++;
            }
            if (novos > 0 && db.SaveChanges() > 0)
                return RedirectToAction("Cadastro", new { id = livroAutorVM.LivroId });
            ViewBag.Titulo = db.Livros.FirstOrDefault(x => x.LivroId == livroAutorVM.LivroId).Titulo;
            return View(livroAutorVM);
        }

        public IActionResult DelAutor(int livroId, int autorId)
        {
            if (livroId > 0 && autorId > 0)
            {
                var cadastro = db.LivroAutor.FirstOrDefault(x => x.LivroId == livroId && x.AutorId == autorId);
                if (cadastro != null)
                {
                    db.LivroAutor.Remove(cadastro);
                    db.SaveChanges();
                }
                return RedirectToAction("Cadastro", new { id = livroId });
            }
            return RedirectToAction("Index");
        }
    }
}