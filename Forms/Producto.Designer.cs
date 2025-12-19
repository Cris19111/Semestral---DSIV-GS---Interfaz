namespace Semestral___DSIV_GS
{
    partial class Producto
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpProductos = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnFiltrarProducto = new System.Windows.Forms.Button();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
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
            this.grpProductos.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.grpProductos.Location = new System.Drawing.Point(71, 89);
            this.grpProductos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpProductos.Name = "grpProductos";
            this.grpProductos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpProductos.Size = new System.Drawing.Size(901, 529);
            this.grpProductos.TabIndex = 15;
            this.grpProductos.TabStop = false;
            this.grpProductos.Text = "Productos";
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(63, 41);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(774, 444);
            this.dgvProductos.TabIndex = 6;
            // 
            // btnFiltrarProducto
            // 
            this.btnFiltrarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.btnFiltrarProducto.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.btnFiltrarProducto.ForeColor = System.Drawing.Color.White;
            this.btnFiltrarProducto.Location = new System.Drawing.Point(884, 4);
            this.btnFiltrarProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFiltrarProducto.Name = "btnFiltrarProducto";
            this.btnFiltrarProducto.Size = new System.Drawing.Size(132, 56);
            this.btnFiltrarProducto.TabIndex = 14;
            this.btnFiltrarProducto.Text = "Filtrar";
            this.btnFiltrarProducto.UseVisualStyleBackColor = false;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.btnBuscarProducto.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProducto.Location = new System.Drawing.Point(713, 4);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(132, 56);
            this.btnBuscarProducto.TabIndex = 13;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Font = new System.Drawing.Font("Sylfaen", 10.8F);
            this.txtBuscarProducto.Location = new System.Drawing.Point(115, 9);
            this.txtBuscarProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(205, 36);
            this.txtBuscarProducto.TabIndex = 10;
            this.txtBuscarProducto.Click += new System.EventHandler(this.txtBuscar);
            // 
            // lblBuscarProducto
            // 
            this.lblBuscarProducto.AutoSize = true;
            this.lblBuscarProducto.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.lblBuscarProducto.Location = new System.Drawing.Point(24, 15);
            this.lblBuscarProducto.Name = "lblBuscarProducto";
            this.lblBuscarProducto.Size = new System.Drawing.Size(87, 31);
            this.lblBuscarProducto.TabIndex = 9;
            this.lblBuscarProducto.Text = "Buscar:";
            // 
            // Volver
            // 
            this.Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.Volver.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.Volver.ForeColor = System.Drawing.Color.White;
            this.Volver.Location = new System.Drawing.Point(14, 625);
            this.Volver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(132, 56);
            this.Volver.TabIndex = 16;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = false;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1040, 698);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.grpProductos);
            this.Controls.Add(this.btnFiltrarProducto);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.lblBuscarProducto);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Producto";
            this.Text = "Producto";
            this.Load += new System.EventHandler(this.Producto_Load);
            this.grpProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnFiltrarProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label lblBuscarProducto;
        private System.Windows.Forms.Button Volver;
    }
}
