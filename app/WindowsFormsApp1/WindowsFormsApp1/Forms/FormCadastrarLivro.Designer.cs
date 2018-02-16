namespace WindowsFormsApp1.Forms
{
    partial class FormCadastrarLivro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridPrincipal = new System.Windows.Forms.DataGridView();
            this.panelCadastro = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listboxAutores = new System.Windows.Forms.ListBox();
            this.cmbAutoresDisponiveis = new System.Windows.Forms.ComboBox();
            this.btnIncluirAutor = new System.Windows.Forms.Button();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listarAutoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboxLazyLoadingAutores = new System.Windows.Forms.CheckBox();
            this.cboxEagerLoadingAutores = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrincipal)).BeginInit();
            this.panelCadastro.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPrincipal
            // 
            this.gridPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPrincipal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nome,
            this.Categoria});
            this.gridPrincipal.ContextMenuStrip = this.contextMenuStrip1;
            this.gridPrincipal.Location = new System.Drawing.Point(12, 51);
            this.gridPrincipal.MultiSelect = false;
            this.gridPrincipal.Name = "gridPrincipal";
            this.gridPrincipal.ReadOnly = true;
            this.gridPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPrincipal.Size = new System.Drawing.Size(760, 275);
            this.gridPrincipal.TabIndex = 3;
            this.gridPrincipal.DoubleClick += new System.EventHandler(this.gridPrincipal_DoubleClick);
            // 
            // panelCadastro
            // 
            this.panelCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelCadastro.Controls.Add(this.btnIncluirAutor);
            this.panelCadastro.Controls.Add(this.cmbAutoresDisponiveis);
            this.panelCadastro.Controls.Add(this.listboxAutores);
            this.panelCadastro.Controls.Add(this.label3);
            this.panelCadastro.Controls.Add(this.cmbCategoria);
            this.panelCadastro.Controls.Add(this.label2);
            this.panelCadastro.Controls.Add(this.btnCancelar);
            this.panelCadastro.Controls.Add(this.btnSalvar);
            this.panelCadastro.Controls.Add(this.txtNome);
            this.panelCadastro.Controls.Add(this.label1);
            this.panelCadastro.Location = new System.Drawing.Point(12, 347);
            this.panelCadastro.Name = "panelCadastro";
            this.panelCadastro.Size = new System.Drawing.Size(760, 202);
            this.panelCadastro.TabIndex = 4;
            this.panelCadastro.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(119, 155);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(23, 155);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(23, 41);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(391, 24);
            this.txtNome.TabIndex = 1;
            this.txtNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(12, 12);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(90, 30);
            this.btnNovo.TabIndex = 5;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(25, 98);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(389, 26);
            this.cmbCategoria.TabIndex = 7;
            this.cmbCategoria.SelectedValueChanged += new System.EventHandler(this.cmbCategoria_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Autores";
            // 
            // listboxAutores
            // 
            this.listboxAutores.FormattingEnabled = true;
            this.listboxAutores.ItemHeight = 18;
            this.listboxAutores.Location = new System.Drawing.Point(432, 41);
            this.listboxAutores.Name = "listboxAutores";
            this.listboxAutores.Size = new System.Drawing.Size(305, 112);
            this.listboxAutores.TabIndex = 9;
            // 
            // cmbAutoresDisponiveis
            // 
            this.cmbAutoresDisponiveis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutoresDisponiveis.FormattingEnabled = true;
            this.cmbAutoresDisponiveis.Location = new System.Drawing.Point(432, 155);
            this.cmbAutoresDisponiveis.Name = "cmbAutoresDisponiveis";
            this.cmbAutoresDisponiveis.Size = new System.Drawing.Size(252, 26);
            this.cmbAutoresDisponiveis.TabIndex = 11;
            // 
            // btnIncluirAutor
            // 
            this.btnIncluirAutor.Location = new System.Drawing.Point(687, 154);
            this.btnIncluirAutor.Name = "btnIncluirAutor";
            this.btnIncluirAutor.Size = new System.Drawing.Size(51, 28);
            this.btnIncluirAutor.TabIndex = 12;
            this.btnIncluirAutor.Text = "+";
            this.btnIncluirAutor.UseVisualStyleBackColor = true;
            this.btnIncluirAutor.Click += new System.EventHandler(this.btnIncluirAutor_Click);
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 380;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 300;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarAutoresToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // listarAutoresToolStripMenuItem
            // 
            this.listarAutoresToolStripMenuItem.Name = "listarAutoresToolStripMenuItem";
            this.listarAutoresToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listarAutoresToolStripMenuItem.Text = "Listar Autores";
            this.listarAutoresToolStripMenuItem.Click += new System.EventHandler(this.listarAutoresToolStripMenuItem_Click);
            // 
            // cboxLazyLoadingAutores
            // 
            this.cboxLazyLoadingAutores.AutoSize = true;
            this.cboxLazyLoadingAutores.Checked = true;
            this.cboxLazyLoadingAutores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxLazyLoadingAutores.Location = new System.Drawing.Point(595, 2);
            this.cboxLazyLoadingAutores.Name = "cboxLazyLoadingAutores";
            this.cboxLazyLoadingAutores.Size = new System.Drawing.Size(169, 22);
            this.cboxLazyLoadingAutores.TabIndex = 7;
            this.cboxLazyLoadingAutores.Text = "Lazy Loading Autores";
            this.cboxLazyLoadingAutores.UseVisualStyleBackColor = true;
            // 
            // cboxEagerLoadingAutores
            // 
            this.cboxEagerLoadingAutores.AutoSize = true;
            this.cboxEagerLoadingAutores.Location = new System.Drawing.Point(595, 26);
            this.cboxEagerLoadingAutores.Name = "cboxEagerLoadingAutores";
            this.cboxEagerLoadingAutores.Size = new System.Drawing.Size(177, 22);
            this.cboxEagerLoadingAutores.TabIndex = 8;
            this.cboxEagerLoadingAutores.Text = "Eager Loading Autores";
            this.cboxEagerLoadingAutores.UseVisualStyleBackColor = true;
            // 
            // FormCadastrarLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cboxEagerLoadingAutores);
            this.Controls.Add(this.cboxLazyLoadingAutores);
            this.Controls.Add(this.gridPrincipal);
            this.Controls.Add(this.panelCadastro);
            this.Controls.Add(this.btnNovo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormCadastrarLivro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Livro";
            this.Load += new System.EventHandler(this.FormCadastrarLivro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPrincipal)).EndInit();
            this.panelCadastro.ResumeLayout(false);
            this.panelCadastro.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPrincipal;
        private System.Windows.Forms.Panel panelCadastro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ListBox listboxAutores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIncluirAutor;
        private System.Windows.Forms.ComboBox cmbAutoresDisponiveis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listarAutoresToolStripMenuItem;
        private System.Windows.Forms.CheckBox cboxLazyLoadingAutores;
        private System.Windows.Forms.CheckBox cboxEagerLoadingAutores;
    }
}