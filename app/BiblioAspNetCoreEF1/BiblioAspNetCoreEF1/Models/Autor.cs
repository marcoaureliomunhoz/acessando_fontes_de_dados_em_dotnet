using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.Models
{
    public class Autor
    {
        public int AutorId { get; set; } = 0;

        public const int NomeMinLength = 3;
        public const int NomeMaxLength = 100;
        public string Nome { get; set; } = "";
    }
}
