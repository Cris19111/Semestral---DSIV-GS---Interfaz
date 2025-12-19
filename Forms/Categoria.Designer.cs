namespace Semestral___DSIV_GS
{
    partial class Categoria
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
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.btnEditarCategoria = new System.Windows.Forms.Button();
            this.btnCrearCategoria = new System.Windows.Forms.Button();
            this.grpCategorias = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriaProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cant_productos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFiltrarProducto = new System.Windows.Forms.Button();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.lblBuscarProducto = new System.Windows.Forms.Label();
            this.Volver = new System.Windows.Forms.Button();
            this.grpCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminarCategoria
            // 
            this.btnEliminarCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminarCategoria.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarCategoria.Location = new System.Drawing.Point(733, 519);
            this.btnEliminarCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(209, 46);
            this.btnEliminarCategoria.TabIndex = 24;
            this.btnEliminarCategoria.Text = "Eliminar Categoria";
            this.btnEliminarCategoria.UseVisualStyleBackColor = false;
            // 
            // btnEditarCategoria
            // 
            this.btnEditarCategoria.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEditarCategoria.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCategoria.Location = new System.Drawing.Point(538, 519);
            this.btnEditarCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditarCategoria.Name = "btnEditarCategoria";
            this.btnEditarCategoria.Size = new System.Drawing.Size(189, 46);
            this.btnEditarCategoria.TabIndex = 22;
            this.btnEditarCategoria.Text = "Editar Categoria";
            this.btnEditarCategoria.UseVisualStyleBackColor = false;
            // 
            // btnCrearCategoria
            // 
            this.btnCrearCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCrearCategoria.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearCategoria.Location = new System.Drawing.Point(339, 519);
            this.btnCrearCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrearCategoria.Name = "btnCrearCategoria";
            this.btnCrearCategoria.Size = new System.Drawing.Size(193, 46);
            this.btnCrearCategoria.TabIndex = 21;
            this.btnCrearCategoria.Text = "Crear Categoria";
            this.btnCrearCategoria.UseVisualStyleBackColor = false;
            // 
            // grpCategorias
            // 
            this.grpCategorias.Controls.Add(this.dgvProductos);
            this.grpCategorias.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCategorias.Location = new System.Drawing.Point(78, 90);
            this.grpCategorias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpCategorias.Name = "grpCategorias";
            this.grpCategorias.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpCategorias.Size = new System.Drawing.Size(801, 423);
            this.grpCategorias.TabIndex = 20;
            this.grpCategorias.TabStop = false;
            this.grpCategorias.Text = "Categorias";
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProducto,
            this.colCategoriaProducto,
            this.cant_productos});
            this.dgvProductos.Location = new System.Drawing.Point(157, 32);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(532, 354);
            this.dgvProductos.TabIndex = 6;
            // 
            // colIdProducto
            // 
            this.colIdProducto.HeaderText = "ID";
            this.colIdProducto.MinimumWidth = 6;
            this.colIdProducto.Name = "colIdProducto";
            this.colIdProducto.Width = 125;
            // 
            // colCategoriaProducto
            // 
            this.colCategoriaProducto.HeaderText = "Categoría";
            this.colCategoriaProducto.MinimumWidth = 6;
            this.colCategoriaProducto.Name = "colCategoriaProducto";
            this.colCategoriaProducto.Width = 125;
            // 
            // cant_productos
            // 
            this.cant_productos.HeaderText = "Cantidad productos";
            this.cant_productos.MinimumWidth = 6;
            this.cant_productos.Name = "cant_productos";
            this.cant_productos.Width = 125;
            // 
            // btnFiltrarProducto
            // 
            this.btnFiltrarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFiltrarProducto.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarProducto.Location = new System.Drawing.Point(801, 22);
            this.btnFiltrarProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFiltrarProducto.Name = "btnFiltrarProducto";
            this.btnFiltrarProducto.Size = new System.Drawing.Size(117, 46);
            this.btnFiltrarProducto.TabIndex = 19;
            this.btnFiltrarProducto.Text = "Filtrar";
            this.btnFiltrarProducto.UseVisualStyleBackColor = false;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscarProducto.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProducto.Location = new System.Drawing.Point(650, 22);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(117, 46);
            this.btnBuscarProducto.TabIndex = 18;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Font = new System.Drawing.Font("Sylfaen", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(423, 30);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(183, 31);
            this.cmbCategoria.TabIndex = 17;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(306, 31);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(100, 26);
            this.lblCategoria.TabIndex = 16;
            this.lblCategoria.Text = "Categoría:";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Font = new System.Drawing.Font("Sylfaen", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProducto.Location = new System.Drawing.Point(117, 26);
            this.txtBuscarProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(183, 31);
            this.txtBuscarProducto.TabIndex = 15;
            // 
            // lblBuscarProducto
            // 
            this.lblBuscarProducto.AutoSize = true;
            this.lblBuscarProducto.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarProducto.Location = new System.Drawing.Point(37, 31);
            this.lblBuscarProducto.Name = "lblBuscarProducto";
            this.lblBuscarProducto.Size = new System.Drawing.Size(75, 26);
            this.lblBuscarProducto.TabIndex = 14;
            this.lblBuscarProducto.Text = "Buscar:";
            // 
            // Volver
            // 
            this.Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Volver.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(12, 520);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(117, 45);
            this.Volver.TabIndex = 25;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = false;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // Categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 587);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.btnEliminarCategoria);
            this.Controls.Add(this.btnEditarCategoria);
            this.Controls.Add(this.btnCrearCategoria);
            this.Controls.Add(this.grpCategorias);
            this.Controls.Add(this.btnFiltrarProducto);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.lblBuscarProducto);
            this.Name = "Categoria";
            this.Text = "Categoria";
            this.grpCategorias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.Button btnEditarCategoria;
        private System.Windows.Forms.Button btnCrearCategoria;
        private System.Windows.Forms.GroupBox grpCategorias;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cant_productos;
        private System.Windows.Forms.Button btnFiltrarProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label lblBuscarProducto;
        private System.Windows.Forms.Button Volver;
    }
}