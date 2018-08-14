using Biblio.DomainApp.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio.DomainApp.Repositorios
{
    public interface IEditorasRep
    {
        List<Editora> Listar();
        Editora Localizar(int id, bool incluirLivros);
        int Salvar(Editora editora);
        int Excluir(int id);
    }
}
