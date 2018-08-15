using Biblio.DomainApp.Entidades;
using Biblio.DomainApp.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblio.DataApp.EF.Repositorios
{
    public class EditorasRep : IEditorasRep
    {
        ContextoGeralEF db;

        public EditorasRep(ContextoGeralEF db)
        {
            this.db = db;
        }

        public Editora Localizar(int id, bool incluirLivros)
        {
            if (db == null)
                return null;

            if (incluirLivros)
                return db.Editoras.Include(x => x.Livros).FirstOrDefault(x => x.EditoraId == id);
            return db.Editoras.FirstOrDefault(x => x.EditoraId == id);
        }

        public int Excluir(int id)
        {
            if (db == null)
                return 0;

            var cadastro = Localizar(id, false);
            if (cadastro != null)
            {
                db.Editoras.Remove(cadastro);
                return db.SaveChanges();
            }
            return 0;
        }

        public List<Editora> Listar()
        {
            if (db == null)
                return new List<Editora>();

            return db.Editoras.ToList();
        }

        public int Salvar(Editora editora)
        {
            if (db == null)
                return 0;

            if (editora.EditoraId == 0)
                db.Editoras.Add(editora);
            return db.SaveChanges();
        }
    }
}
