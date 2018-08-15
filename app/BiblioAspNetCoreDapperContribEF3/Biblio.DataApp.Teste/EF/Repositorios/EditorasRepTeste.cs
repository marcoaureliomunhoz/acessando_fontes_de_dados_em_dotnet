using Biblio.DataApp.EF.Repositorios;
using Biblio.DomainApp.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using Biblio.DataApp.EF;
using System.Linq;

namespace Biblio.DataApp.Teste.EF.Repositorios
{
    [TestClass]
    public class EditorasRepTeste
    {
        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        [TestMethod]
        public void Repositorio_Editoras__SE__DbContextPassadoForNull__ENTAO__ListarNaoPodeRetornarNullDeveRetornarListaVazia()
        {
            //1 - Preparação
            //...

            //2 - Ação
            var editorasRep = new EditorasRep(null);
            var retorno = editorasRep.Listar();

            //3 - Verificação
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Count == 0);
        }

        [TestMethod]
        public void Repositorio_Editoras__APOS__SalvarNovaEditoraValida__RetornoDeveSerUm_e_IdDaNovaEditoraDeveSerMaiorQueZero_e_ListarDeveRetornarUmaEditoraMaisQueAntes_e_NovaEditoraDeveConstarNaLista()
        {
            //1 - Preparação
            MD5 md5Hash = MD5.Create();
            var nome = "editora_" + GetMd5Hash(md5Hash, DateTime.Now.ToString());
            var editora = new Editora(nome);
            md5Hash.Dispose();

            var contextoGeralEF = new ContextoGeralEF();
            var editorasRep = new EditorasRep(contextoGeralEF);

            //2 - Ação
            var listaAntes = editorasRep.Listar();
            var retorno = editorasRep.Salvar(editora);
            var listaApos = editorasRep.Listar();
            var editoraCad = listaApos.FirstOrDefault(x => x.Nome == nome);

            //3 - Verificação
            Assert.IsTrue(retorno == 1);
            Assert.IsTrue(editora.EditoraId > 0);
            Assert.IsTrue(listaApos.Count == listaAntes.Count + 1);
            Assert.IsNotNull(editoraCad);
        }
    }
}
