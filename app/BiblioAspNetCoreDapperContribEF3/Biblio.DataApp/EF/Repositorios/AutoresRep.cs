using Biblio.DomainApp.Entidades;
using Biblio.DomainApp.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblio.DataApp.EF.Repositorios
{
    public class AutoresRep : IAutoresRep
    {
        ContextoGeralEF db;

        public AutoresRep(ContextoGeralEF db)
        {
            this.db = db;
        }

        public Autor Localizar(int id)
        {
            return db.Autores.FirstOrDefault(x => x.AutorId == id);
        }

        public int Excluir(int id)
        {
            var cadastro = Localizar(id);
            if (cadastro != null)
            {
                db.Autores.Remove(cadastro);
                return db.SaveChanges();
            }
            return 0;
        }

        public List<Autor> Listar()
        {
            return db.Autores.ToList();
        }

        public int Salvar(Autor autor)
        {
            if (autor.AutorId == 0)
                db.Autores.Add(autor);
            return db.SaveChanges();
        }
    }
}
