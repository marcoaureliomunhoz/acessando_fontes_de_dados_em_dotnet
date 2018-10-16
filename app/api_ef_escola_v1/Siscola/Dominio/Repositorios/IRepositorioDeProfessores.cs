using Siscola.Dominio.Dtos;
using Siscola.Dominio.Repositorios._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio.Repositorios
{
    public interface IRepositorioDeProfessores : IRepositorio<Professor>
    {
        List<ItemListaDeProfessor> ListarItens();
    }
}
