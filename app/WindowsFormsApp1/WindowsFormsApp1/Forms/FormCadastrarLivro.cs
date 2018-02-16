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
    public partial class FormCadastrarLivro : Form
    {
        const int GridAlturaNormal = 500;
        const int GridAlturaMenor = 275;

        Entidades.Livro cadastro = null;
        List<Entidades.Autor> autores = null;
        List<Entidades.Autor> autoresDisponiveis = null;

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
            listboxAutores.DataSource = null;
            cmbCategoria.DataSource = null;
            cmbAutoresDisponiveis.DataSource = null;
            cadastro = null;
            autores = null;
            autoresDisponiveis = null;
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
            listboxAutores.DataSource = null;
            cmbCategoria.DataSource = null;
            cmbAutoresDisponiveis.DataSource = null;
            autores = null;
            autoresDisponiveis = null;

            int[] idautores = { };
            if (cadastro != null)
                idautores = cadastro.Autores.Select(a => a.AutorId).ToArray();

            using (var db = new Contextos.ContextoGeral())
            {
                cmbCategoria.DataSource = db.Categorias.ToList();
                if (cadastro != null)
                {
                    autoresDisponiveis = db.Autores.Where(x => !idautores.Contains(x.AutorId)).ToList();
                }
                else
                {
                    autoresDisponiveis = db.Autores.ToList();
                }
            }

            cmbAutoresDisponiveis.DataSource = autoresDisponiveis;

            gridPrincipal.Enabled = false;

            if (cadastro != null)
            {
                txtNome.Text = cadastro.Nome;
                cmbCategoria.SelectedItem = (cmbCategoria.DataSource as List<Entidades.Categoria>).FirstOrDefault(x => x.CategoriaId == cadastro.Categoria.CategoriaId);
                autores = cadastro.Autores.ToList();
            }
            else
            {
                autores = new List<Entidades.Autor>();
            }

            listboxAutores.DataSource = autores;

            txtNome.Focus();
        }

        private void CarregarTela()
        {
            gridPrincipal.DataSource = null;
            using (var db = new Contextos.ContextoGeral())
            {
                gridPrincipal.DataSource = db.Livros.Include("Categoria").Include("Autores").ToList();
            }
        }

        private void PodeSalvar()
        {
            btnSalvar.Enabled = txtNome.Text.Length > 0 && cmbCategoria.SelectedItem != null && listboxAutores.Items.Count > 0;
        }

        //eventos

        public FormCadastrarLivro()
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
                    var livro = new Entidades.Livro();
                    livro.Nome = txtNome.Text;
                    var categoria = cmbCategoria.SelectedItem as Entidades.Categoria;
                    livro.Categoria = db.Categorias.FirstOrDefault(x => x.CategoriaId == categoria.CategoriaId);
                    foreach (var autor in autores)
                    {
                        livro.Autores.Add(db.Autores.FirstOrDefault(x => x.AutorId == autor.AutorId));
                    }
                    db.Livros.Add(livro);
                    if (db.SaveChanges() > 0)
                    {
                        CarregarTela();
                        CancelarCadastro();
                    }
                }
                else
                {
                    var livro = db.Livros.Include("Categoria").Include("Autores").FirstOrDefault(x => x.LivroId == cadastro.LivroId);
                    if (livro != null)
                    {
                        livro.Nome = txtNome.Text;
                        var categoria = cmbCategoria.SelectedItem as Entidades.Categoria;
                        livro.Categoria = db.Categorias.FirstOrDefault(x => x.CategoriaId == categoria.CategoriaId);
                        foreach (var autor in autores)
                        {
                            if (livro.Autores.Count(x => x.AutorId == autor.AutorId) <= 0)
                            {
                                livro.Autores.Add(db.Autores.FirstOrDefault(x => x.AutorId == autor.AutorId));
                            }
                        }
                        db.SaveChanges();
                        CarregarTela();
                        CancelarCadastro();
                    }
                }
            }
        }

        private void FormCadastrarLivro_Load(object sender, EventArgs e)
        {
            CarregarTela();
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            PodeSalvar();
        }

        private void gridPrincipal_DoubleClick(object sender, EventArgs e)
        {
            if (gridPrincipal.Rows.Count > 0 && gridPrincipal.CurrentRow != null)
            {
                cadastro = gridPrincipal.CurrentRow.DataBoundItem as Entidades.Livro;
                RealizarCadastro();
            }
        }

        private void cmbCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            PodeSalvar();
        }

        private void btnIncluirAutor_Click(object sender, EventArgs e)
        {

            if (cmbAutoresDisponiveis.SelectedItem != null)
            {
                var autor = cmbAutoresDisponiveis.SelectedItem as Entidades.Autor;
                autores.Add(autor);
                autoresDisponiveis.Remove(autor);
                cmbAutoresDisponiveis.DataSource = null;
                cmbAutoresDisponiveis.DataSource = autoresDisponiveis;
                listboxAutores.DataSource = null;
                listboxAutores.DataSource = autores;
            }
            PodeSalvar();
        }

        private void listarAutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridPrincipal.Rows.Count > 0 && gridPrincipal.CurrentRow != null)
            {
                var livro = gridPrincipal.CurrentRow.DataBoundItem as Entidades.Livro;
                if (cboxEagerLoadingAutores.Checked)
                {
                    using (var db = new Contextos.ContextoGeral())
                    {
                        var livrodb = db.Livros
                                        .Include("Categoria")
                                        .Include("Autores")
                                        .FirstOrDefault(x => x.LivroId == livro.LivroId);
                        var texto = "";
                        foreach (var autor in livrodb.Autores)
                        {
                            texto += (texto.Length>0?"\n":"") + autor.Nome;
                        }
                        MessageBox.Show(texto);
                    }
                }
                else
                {
                    using (var db = new Contextos.ContextoGeral())
                    {
                        var livrodb = db.Livros
                                        .FirstOrDefault(x => x.LivroId == livro.LivroId);
                        var texto = "";
                        foreach (var autor in livrodb.Autores)
                        {
                            texto += (texto.Length > 0 ? "\n" : "") + autor.Nome;
                        }
                        MessageBox.Show(texto);
                    }
                }
            }
        }
    }
}
