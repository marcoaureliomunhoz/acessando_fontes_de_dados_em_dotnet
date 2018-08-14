using DomainApp.Entidades;
using DomainApp.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Controllers;

namespace WebApp.Teste.Controllers
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
        public void Controller_Editoras_Action_Index__SE__RepositorioNaoPossuiItens__ENTAO__RetornarNullOuListaEmBranco()
        {
            //1 - Preparação
            List<Editora> editoras = null;
            editorasRep.Setup(x => x.Listar()).Returns(editoras);

            //2 - Ação
            var editorasCtrl = new EditorasController(editorasRep.Object);
            var retorno = editorasCtrl.GetIndex();

            //3 - Ação
            Assert.IsTrue(retorno == null || retorno.Count == 0);
        }

        [TestMethod]
        public void Controller_Editoras_Action_Index__SE__RepositorioPossuiUmUnicoItem__ENTAO__RetornarEsteUnicoItemExistente()
        {
            //1 - Preparação
            List<Editora> editoras = new List<Editora>()
            {
                new Editora(1,"novatec",null)
            };
            editorasRep.Setup(x => x.Listar()).Returns(editoras);

            //2 - Ação
            var editorasCtrl = new EditorasController(editorasRep.Object);
            var retorno = editorasCtrl.GetIndex();

            //3 - Ação
            Assert.IsTrue(retorno != null && retorno.Count == 1 && retorno[0].Nome == "novatec");
        }
    }
}
