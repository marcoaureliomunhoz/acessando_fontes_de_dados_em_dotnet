using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Infra.Data.Seeds
{
    public class DisciplinaSeed
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"insert into 
                    Disciplina (Nome, Detalhes) 
                  values 
                    ('Matemática', ''), 
                    ('Português', ''), 
                    ('Geografia', ''), 
                    ('História', ''), 
                    ('Biologia', '')"
            );
        }
    }
}
