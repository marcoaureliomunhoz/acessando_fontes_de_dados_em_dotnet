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
            if (incluirLivros)
                return db.Editoras.Include(x => x.Livros).FirstOrDefault(x => x.EditoraId == id);
            return db.Editoras.FirstOrDefault(x => x.EditoraId == id);
        }

        public int Excluir(int id)
        {
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
            return db.Editoras.ToList();
        }

        public int Salvar(Editora editora)
        {
            if (editora.EditoraId == 0)
                db.Editoras.Add(editora);
            return db.SaveChanges();
        }
    }
}
