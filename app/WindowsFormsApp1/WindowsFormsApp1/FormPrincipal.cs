using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCadastrarAutor = new Forms.FormCadastrarAutor();
            formCadastrarAutor.ShowDialog();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCadastrarCategoria = new Forms.FormCadastrarCategoria();
            formCadastrarCategoria.ShowDialog();
        }

        private void livroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCadastrarLivro = new Forms.FormCadastrarLivro();
            formCadastrarLivro.ShowDialog();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Verificando conexão...");
                using (var db = new Contextos.ContextoGeral())
                {
                    Console.WriteLine($"Banco: {db.Database.Connection.Database}");
                    Console.WriteLine($"Status: {db.Database.Connection.State.ToString()}");
                    Console.WriteLine($"Autores cadastrados: {db.Autores.Count()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
