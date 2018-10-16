using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio.Dtos
{
    public class ItemListaDeProfessor
    {
        public int Id { get; set; }
        public int PessoaFisicaId { get; set; }
        public string NomeCivil { get; set; }
        public string NomeSocial { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
    }
}
