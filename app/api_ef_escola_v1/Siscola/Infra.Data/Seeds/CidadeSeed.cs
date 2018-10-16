using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Infra.Data.Seeds
{
    public class CidadeSeed
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"insert into 
                    Cidade (UF, Nome) 
                  values 
                    ('SP', 'Regente Feijó'), 
                    ('SP', 'Presidente Prudente'), 
                    ('PR', 'Maringá'), 
                    ('PR', 'Londrina'), 
                    ('MS', 'Campo Grande')"
            );
        }
    }
}
