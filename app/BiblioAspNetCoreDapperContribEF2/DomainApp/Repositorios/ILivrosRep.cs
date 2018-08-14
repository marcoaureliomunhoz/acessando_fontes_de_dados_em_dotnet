using DomainApp.Entidades;
using System.Collections.Generic;

namespace DomainApp.Repositorios
{
    public interface ILivrosRep
    {
        Livro Localizar(int id, bool incluirAutores);
        List<Livro> Listar();
        int Salvar(Livro livro);
        int Excluir(int id);
        List<Autor> ListarAutoresNaoVinculados(int livroId);
        int RemoverAutor(int livroId, int autorId);
        int AdicionarAutores(ICollection<int> novos, int livroId);
    }
}
