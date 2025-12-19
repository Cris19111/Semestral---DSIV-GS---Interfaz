namespace Semestral___DSIV_GS
{
    partial class Producto
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
            this.grpProductos = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriaProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFiltrarProducto = new System.Windows.Forms.Button();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.lblBuscarProducto = new System.Windows.Forms.Label();
            this.Volver = new System.Windows.Forms.Button();
            this.grpProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // grpProductos
            // 
            this.grpProductos.Controls.Add(this.dgvProductos);
            this.grpProductos.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProductos.Location = new System.Drawing.Point(63, 71);
            this.grpProductos.Name = "grpProductos";
            this.grpProductos.Size = new System.Drawing.Size(801, 423);
            this.grpProductos.TabIndex = 15;
            this.grpProductos.TabStop = false;
            this.grpProductos.Text = "Productos";
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProducto,
            this.colNombreProducto,
            this.colCategoriaProducto,
            this.colPrecioProducto,
            this.colStockProducto});
            this.dgvProductos.Location = new System.Drawing.Point(56, 33);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(688, 355);
            this.dgvProductos.TabIndex = 6;
            // 
            // colIdProducto
            // 
            this.colIdProducto.HeaderText = "ID";
            this.colIdProducto.MinimumWidth = 6;
            this.colIdProducto.Name = "colIdProducto";
            this.colIdProducto.Width = 125;
            // 
            // colNombreProducto
            // 
            this.colNombreProducto.HeaderText = "Nombre";
            this.colNombreProducto.MinimumWidth = 6;
            this.colNombreProducto.Name = "colNombreProducto";
            this.colNombreProducto.Width = 125;
            // 
            // colCategoriaProducto
            // 
            this.colCategoriaProducto.HeaderText = "Categoría";
            this.colCategoriaProducto.MinimumWidth = 6;
            this.colCategoriaProducto.Name = "colCategoriaProducto";
            this.colCategoriaProducto.Width = 125;
            // 
            // colPrecioProducto
            // 
            this.colPrecioProducto.HeaderText = "Precio";
            this.colPrecioProducto.MinimumWidth = 6;
            this.colPrecioProducto.Name = "colPrecioProducto";
            this.colPrecioProducto.Width = 125;
            // 
            // colStockProducto
            // 
            this.colStockProducto.HeaderText = "Stock";
            this.colStockProducto.MinimumWidth = 6;
            this.colStockProducto.Name = "colStockProducto";
            this.colStockProducto.Width = 125;
            // 
            // btnFiltrarProducto
            // 
            this.btnFiltrarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFiltrarProducto.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarProducto.Location = new System.Drawing.Point(786, 3);
            this.btnFiltrarProducto.Name = "btnFiltrarProducto";
            this.btnFiltrarProducto.Size = new System.Drawing.Size(117, 45);
            this.btnFiltrarProducto.TabIndex = 14;
            this.btnFiltrarProducto.Text = "Filtrar";
            this.btnFiltrarProducto.UseVisualStyleBackColor = false;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscarProducto.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProducto.Location = new System.Drawing.Point(635, 3);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(117, 45);
            this.btnBuscarProducto.TabIndex = 13;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Font = new System.Drawing.Font("Sylfaen", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(408, 11);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(183, 31);
            this.cmbCategoria.TabIndex = 12;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(291, 12);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(100, 26);
            this.lblCategoria.TabIndex = 11;
            this.lblCategoria.Text = "Categoría:";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Font = new System.Drawing.Font("Sylfaen", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProducto.Location = new System.Drawing.Point(102, 7);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(183, 31);
            this.txtBuscarProducto.TabIndex = 10;
            // 
            // lblBuscarProducto
            // 
            this.lblBuscarProducto.AutoSize = true;
            this.lblBuscarProducto.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarProducto.Location = new System.Drawing.Point(21, 12);
            this.lblBuscarProducto.Name = "lblBuscarProducto";
            this.lblBuscarProducto.Size = new System.Drawing.Size(75, 26);
            this.lblBuscarProducto.TabIndex = 9;
            this.lblBuscarProducto.Text = "Buscar:";
            // 
            // Volver
            // 
            this.Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Volver.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(12, 500);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(117, 45);
            this.Volver.TabIndex = 16;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = false;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 558);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.grpProductos);
            this.Controls.Add(this.btnFiltrarProducto);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.lblBuscarProducto);
            this.Name = "Producto";
            this.Text = "Producto";
            this.grpProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockProducto;
        private System.Windows.Forms.Button btnFiltrarProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label lblBuscarProducto;
        private System.Windows.Forms.Button Volver;
    }
}