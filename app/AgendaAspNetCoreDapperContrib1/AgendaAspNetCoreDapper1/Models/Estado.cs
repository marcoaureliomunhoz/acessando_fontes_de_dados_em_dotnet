using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaAspNetCoreDapper1.Models
{
    [Table("dbo.Estado")]
    public class Estado
    {
        [ExplicitKey]
        public string UF { get; set; } = "";
        public string Nome { get; set; } = "";
    }
}
