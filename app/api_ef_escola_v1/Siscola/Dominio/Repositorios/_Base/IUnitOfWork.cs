using Microsoft.EntityFrameworkCore;
using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio.Repositorios._Base
{
    public interface IUnitOfWork
    {
        DbSet<TEntidade> Set<TEntidade>() where TEntidade : Entidade;

        void Commit();
        void Roolback();
    }
}
