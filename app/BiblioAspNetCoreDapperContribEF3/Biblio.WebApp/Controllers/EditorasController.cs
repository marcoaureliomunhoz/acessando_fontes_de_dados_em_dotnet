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
    public class EditorasController : Controller
    {
        IEditorasRep editorasRep;

        public EditorasController(IEditorasRep editorasRep)
        {
            this.editorasRep = editorasRep;
        }

        public List<Editora> GetIndex()
        {
            return editorasRep.Listar();
        }
        public IActionResult Index()
        {
            return View(GetIndex());
        }

        public EditoraCadVM GetCadastro(int id)
        {
            var model = new EditoraCadVM();
            var editora = editorasRep.Localizar(id, true);
            if (editora != null)
            {
                model.EditoraId = editora.EditoraId;
                model.Nome = editora.Nome;
                model.Livros = editora.Livros;
            }
            return model;
        }
        public IActionResult Cadastro(int id)
        {
            return View(GetCadastro(id));
        }

        public bool PostCadastro(EditoraCadVM model)
        {
            Editora editora = null;
            if (model.EditoraId > 0)
            {
                editora = editorasRep.Localizar(model.EditoraId, false);
                if (editora != null)
                    editora.Alterar(model.Nome);
            }
            else
            {
                editora = new Editora(model.Nome);
            }

            //aqui validação e retorno se não passar

            if (editora != null && editorasRep.Salvar(editora) > 0)
                return true;

            //aqui cabe uma melhoria, um método específico para listar os livros de uma editora, 
            //sem ter que localizar a editora para obter sua lista de livros
            if (model.EditoraId > 0)
                model.Livros = editorasRep.Localizar(model.EditoraId, true).Livros;
            return false;
        }
        [HttpPost]
        public IActionResult Cadastro(EditoraCadVM model)
        {
            if (PostCadastro(model))
                return RedirectToAction(nameof(Index));
            return View(model);
        }

        public int GetExcluir(int id)
        {
            return editorasRep.Excluir(id);
        }
        public IActionResult Excluir(int id)
        {
            GetExcluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}