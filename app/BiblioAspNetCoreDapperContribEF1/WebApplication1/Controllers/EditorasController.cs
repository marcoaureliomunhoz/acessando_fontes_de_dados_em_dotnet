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
    public class EditorasController : Controller
    {
        IEditorasRep editorasRep;

        public EditorasController(IEditorasRep editorasRep)
        {
            this.editorasRep = editorasRep;
        }

        public IActionResult Index()
        {
            var editoras = editorasRep.Listar();
            var model = new List<EditoraVM>();
            editoras.ForEach(x => model.Add(new EditoraVM
            {
                EditoraId = x.EditoraId,
                Nome = x.Nome
            }));
            return View(model);
        }

        public IActionResult Cadastro(int id)
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
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(EditoraCadVM vm)
        {
            var editora = new Editora(vm.EditoraId, vm.Nome, null);
            vm.Problemas = editora.Problemas().ToList();
            if (vm.Problemas.Count == 0)
            {
                if (editorasRep.Salvar(editora) > 0)
                    return RedirectToAction("Index");
            }
            return View(vm);
        }

        public IActionResult Excluir(int id)
        {
            editorasRep.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}