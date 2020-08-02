using System;
using System.Collections.Generic;

namespace Locar.Domain.Entities
{
    public class Veiculo
    {
        public Guid Id { get; private set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public IList<Preco> Precos { get; set; }
    }
}