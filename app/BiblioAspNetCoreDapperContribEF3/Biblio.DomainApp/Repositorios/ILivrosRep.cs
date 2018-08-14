using Biblio.DomainApp.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio.DomainApp.Repositorios
{
    public interface ILivrosRep
    {
        List<Livro> Listar();
        Livro Localizar(int id, bool incluirAutores);
        int Salvar(Livro livro);
        int Excluir(int id);
        int ExcluirAutor(int livroId, int autorId);
        List<Autor> ListarAutoresRelacionados(int livroId);
        List<Autor> ListarAutoresNaoRelacionados(int livroId);
        int RelacionarNovosAutores(List<int> autores, int livroId);
    }
}
