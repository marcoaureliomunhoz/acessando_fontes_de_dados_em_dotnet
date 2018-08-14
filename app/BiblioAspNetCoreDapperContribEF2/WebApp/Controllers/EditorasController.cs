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
    public class EditorasController : Controller
    {
        IEditorasRep editorasRep;

        public EditorasController(IEditorasRep editorasRep)
        {
            this.editorasRep = editorasRep;
        }

        public List<EditoraVM> GetIndex()
        {
            var editoras = editorasRep.Listar();
            var model = new List<EditoraVM>();
            if (editoras != null)
                editoras.ForEach(x => model.Add(new EditoraVM
                {
                    EditoraId = x.EditoraId,
                    Nome = x.Nome
                }));
            return model;
        }
        public IActionResult Index()
        {
            var model = GetIndex();
            return View(model);
        }

        public EditoraCadVM GetCadastro(int id)
        {
            var model = new EditoraCadVM();
            var editora = editorasRep.Localizar(id, true);
            if (editora != null)
            {
                model.EditoraId = editora.EditoraId;
                model.Nome = editora.Nome;
                if (editora.Livros != null)
                    foreach (var x in editora.Livros)
                        model.Livros.Add(new LivroVM
                        {
                            LivroId = x.LivroId,
                            Titulo = x.Titulo
                        });
            }
            return model;
        }
        public IActionResult Cadastro(int id)
        {
            //Console.WriteLine(HttpContext.Request.Path);
            var model = GetCadastro(id);
            return View(model);
        }

        public bool PostCadastro(EditoraCadVM vm)
        {
            var editora = new Editora(vm.EditoraId, vm.Nome, null);
            vm.Problemas = editora.Problemas;
            if (vm.Problemas.Count == 0)
            {
                if (editorasRep.Salvar(editora) > 0)
                    return true;
            }
            return false;
        }
        [HttpPost]
        public IActionResult Cadastro(EditoraCadVM vm)
        {
            if (PostCadastro(vm))
                return RedirectToAction("Index");
            return View(vm);
        }

        public int GetExcluir(int id)
        {
            return editorasRep.Excluir(id);
        }
        public IActionResult Excluir(int id)
        {
            GetExcluir(id);
            return RedirectToAction("Index");
        }
    }
}