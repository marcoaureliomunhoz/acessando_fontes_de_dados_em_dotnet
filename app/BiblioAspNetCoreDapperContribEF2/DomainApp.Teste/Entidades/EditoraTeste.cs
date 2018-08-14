using DomainApp.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainApp.Teste.Entidades
{
    [TestClass]
    public class EditoraTeste
    {
        [TestMethod]
        public void Entidade_Editora__SE__NomeVazio__ENTAO__ProblemaDeveSerSinalizado()
        {
            //1 - Preparação
            //...

            //2 - Ação
            var editora = new Editora(0, "", null);

            //3 - Verificação
            Assert.IsTrue(editora.Problemas.Count > 0);
        }

        [TestMethod]
        [DataRow("a")]
        [DataRow("ab")]
        public void Entidade_Editora__SE__NomeMenorQueMinimo__ENTAO__ProblemaDeveSerSinalizado(string value)
        {
            //1 - Preparação
            //...

            //2 - Ação
            var editora = new Editora(0, value, null);

            //3 - Verificação
            Assert.IsTrue(editora.Problemas.Count > 0);
        }

        [TestMethod]
        public void Entidade_Editora__SE__NomeMairQueMaximo__ENTAO__ProblemaDeveSerSinalizado()
        {
            //1 - Preparação
            var nome = "".PadRight(Editora.NomeMax+1, 'a');

            //2 - Ação
            var editora = new Editora(0, nome, null);

            //3 - Verificação
            Assert.IsTrue(editora.Problemas.Count > 0);
        }
    }
}