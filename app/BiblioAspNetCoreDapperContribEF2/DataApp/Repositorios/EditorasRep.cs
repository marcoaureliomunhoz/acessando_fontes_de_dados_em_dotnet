using DataApp.EF;
using DataApp.Fontes;
using DomainApp.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataApp.Repositorios
{
    public class EditorasRep : DomainApp.Repositorios.IEditorasRep
    {
        ContextoGeralEF db;

        public EditorasRep(ContextoGeralEF db)
        {
            this.db = db;
        }

        private TabEditora GetCadastro(int id, bool incluirLivros)
        {
            if (id > 0)
                if (incluirLivros)
                    return db.Editoras.Include(x => x.Livros).FirstOrDefault(x => x.EditoraId == id);
                else
                    return db.Editoras.FirstOrDefault(x => x.EditoraId == id);
            return null;
        }

        public Editora Localizar(int id, bool incluirLivros)
        {
            var cadastro = this.GetCadastro(id, incluirLivros);
            if (cadastro != null)
            {
                var livros = new List<Livro>();
                cadastro.Livros.ForEach(x => livros.Add(new Livro(x.LivroId, x.Titulo, null)));
                return new Editora(cadastro.EditoraId, cadastro.Nome, livros);
            }
            return null;
        }

        public List<Editora> Listar()
        {
            var rlist = new List<Editora>();
            var tlist = db.Editoras.ToList();
            tlist.ForEach(x => rlist.Add(new Editora(x.EditoraId, x.Nome, null)));
            return rlist;
        }

        public int Salvar(Editora editora)
        {
            TabEditora cadastro = this.GetCadastro(editora.EditoraId, false);
            if (cadastro != null)
            {
                cadastro.Nome = editora.Nome;
                return db.SaveChanges();
            }
            cadastro = new TabEditora
            {
                Nome = editora.Nome
            };
            db.Editoras.Add(cadastro);
            return db.SaveChanges();
        }

        public int Excluir(int id)
        {
            var cadastro = this.GetCadastro(id, false);
            if (cadastro != null)
            {
                db.Editoras.Remove(cadastro);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}
