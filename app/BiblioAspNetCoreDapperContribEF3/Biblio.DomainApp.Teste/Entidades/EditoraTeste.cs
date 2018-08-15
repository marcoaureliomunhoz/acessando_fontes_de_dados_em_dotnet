using Biblio.DomainApp.Entidades;
using Biblio.DomainApp.Entidades._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio.DomainApp.Teste.Entidades
{
    [TestClass]
    public class EditoraTeste
    {
        [TestMethod]
        public void Entidade_Editora_Create__SE__NomeVazio__ENTAO__SistemaDeveSinalizarProblemas()
        {
            //1 - Preparação
            //...

            //2 - Ação
            var editora = new Editora("");

            //3 - Verificação
            Assert.IsTrue(editora.Problemas.Count > 0);
        }

        [TestMethod]
        [DataRow("a")]
        [DataRow("ab")]
        public void Entidade_Editora_Create__SE__NomeMenorQueMinimo__ENTAO__ProblemaDeveSerSinalizado(string value)
        {
            //1 - Preparação
            //...

            //2 - Ação
            var editora = new Editora(value);

            //3 - Verificação
            Assert.IsTrue(editora.Problemas.Count > 0);
        }

        [TestMethod]
        public void Entidade_Editora_Create__SE__NomeMairQueMaximo__ENTAO__ProblemaDeveSerSinalizado()
        {
            //1 - Preparação
            var nome = "".PadRight(Editora.NOME_TAM_MAX + 1, 'a');

            //2 - Ação
            var editora = new Editora(nome);

            //3 - Verificação
            Assert.IsTrue(editora.Problemas.Count > 0);
        }
    }
}
