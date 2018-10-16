using Microsoft.EntityFrameworkCore;
using Siscola.Dominio._Base;
using Siscola.Dominio.Repositorios._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Infra.Data.Repositorios
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        protected readonly SiscolaDbContext _db;
        private bool _rollback = false;

        public UnitOfWork(SiscolaDbContext db)
        {
            _db = db;
        }

        public DbSet<TEntidade> Set<TEntidade>() where TEntidade : Entidade
        {
            return _db.Set<TEntidade>();
        }

        public DbContext Ctx()
        {
            return _db;
        }

        public void Dispose()
        {
            if (!_rollback)
            {
                if (_db.ChangeTracker.HasChanges())
                {
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("**** UnitOfWork Error Dispose db.SaveChanges ****");
                        Console.WriteLine(ex.InnerException.Message);
                        Console.WriteLine("**** --------------------------------------- ****");
                    }
                }
            }
        }

        public void Commit()
        {
            _rollback = false;
            _db.SaveChanges();
        }

        public void Roolback()
        {
            _rollback = true;
        }
    }
}
