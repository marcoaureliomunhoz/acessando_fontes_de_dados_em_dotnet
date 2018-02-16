using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class FormCadastrarAutor : Form
    {
        const int GridAlturaNormal = 500;
        const int GridAlturaMenor = 275;

        Entidades.Autor cadastro = null;

        //métodos

        private void CancelarCadastro()
        {
            this.Enabled = true;
            gridPrincipal.Enabled = true;
            gridPrincipal.Height = GridAlturaNormal;
            panelCadastro.Visible = false;
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            txtNome.Text = "";
            cadastro = null;
            gridPrincipal.Focus();
        }

        private void RealizarCadastro()
        {
            this.Enabled = true;
            gridPrincipal.Height = GridAlturaMenor;
            panelCadastro.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = false;
            txtNome.Text = "";
            gridPrincipal.Enabled = false;

            if (cadastro != null)
            {
                txtNome.Text = cadastro.Nome;
            }

            txtNome.Focus();
        }

        private void CarregarTela()
        {
            gridPrincipal.DataSource = null;
            using (var db = new Contextos.ContextoGeral())
            {
                gridPrincipal.DataSource = db.Autores.ToList();
            }
        }

        //eventos

        public FormCadastrarAutor()
        {
            InitializeComponent();
            gridPrincipal.AutoGenerateColumns = false;

            CancelarCadastro();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            RealizarCadastro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarCadastro();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (var db = new Contextos.ContextoGeral())
            {
                if (cadastro == null)
                {
                    var autor = new Entidades.Autor();
                    autor.Nome = txtNome.Text;
                    db.Autores.Add(autor);
                    if (db.SaveChanges() > 0)
                    {
                        CarregarTela();
                        CancelarCadastro();
                    }
                }
                else
                {
                    var autor = db.Autores.FirstOrDefault(x => x.AutorId == cadastro.AutorId);
                    if (autor != null)
                    {
                        autor.Nome = txtNome.Text;
                        db.SaveChanges();
                        CarregarTela();
                        CancelarCadastro();
                    }
                }
            }
        }

        private void FormCadastrarAutor_Load(object sender, EventArgs e)
        {
            CarregarTela();
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            btnSalvar.Enabled = txtNome.Text.Length > 0;
        }

        private void gridPrincipal_DoubleClick(object sender, EventArgs e)
        {
            if (gridPrincipal.Rows.Count > 0 && gridPrincipal.CurrentRow != null)
            {
                cadastro = gridPrincipal.CurrentRow.DataBoundItem as Entidades.Autor;
                RealizarCadastro();
            }
        }
    }
}
