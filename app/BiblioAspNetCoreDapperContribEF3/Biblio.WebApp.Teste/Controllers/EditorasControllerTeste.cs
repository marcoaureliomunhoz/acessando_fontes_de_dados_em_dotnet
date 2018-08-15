using Biblio.DomainApp.Entidades;
using Biblio.DomainApp.Repositorios;
using Biblio.WebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio.WebApp.Teste.Controllers
{
    [TestClass]
    public class EditorasControllerTeste
    {
        Mock<IEditorasRep> editorasRep;

        public EditorasControllerTeste()
        {
            editorasRep = new Mock<IEditorasRep>();
        }

        [TestMethod]
        public void EditorasController__GetIndex__SE__RepositorioVazio__ENTAO__RetornoDeveSerNullOuVazio()
        {
            //1 - Preparação
            List<Editora> editoras = null;
            editorasRep.Setup(x => x.Listar()).Returns(editoras);

            //2 - Ação
            var editorasCtrl = new EditorasController(editorasRep.Object);
            var retorno = editorasCtrl.GetIndex();

            //3 - Verificação
            Assert.IsTrue(retorno == null || retorno.Count == 0);
        }

        [TestMethod]
        public void EditorasContoller__GetIndex__SE__RepositorioPosuiUmUnicoItem__ENTAO__RetornoDeveSerEsteUnicoItem()
        {
            //1 - Preparação
            var editoras = new List<Editora>()
            {
                new Editora("novatec")
            };
            editorasRep.Setup(x => x.Listar()).Returns(editoras);

            //2 - Ação
            var editorasCtrl = new EditorasController(editorasRep.Object);
            var retorno = editorasCtrl.GetIndex();

            //3 - Verificação
            Assert.IsTrue(retorno != null && retorno.Count == 1 && retorno[0].Nome == editoras[0].Nome);
        }
    }
}
