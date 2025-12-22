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
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.cmbFiltrarProducto = new System.Windows.Forms.ComboBox();
            this.Volver = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.grpProductos = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.grpProductos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.White;
            this.btnBuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarProducto.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.btnBuscarProducto.Location = new System.Drawing.Point(1015, 29);
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
            this.txtBuscarProducto.Location = new System.Drawing.Point(1153, 41);
            this.txtBuscarProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(205, 36);
            this.txtBuscarProducto.TabIndex = 10;
            // 
            // cmbFiltrarProducto
            // 
            this.cmbFiltrarProducto.FormattingEnabled = true;
            this.cmbFiltrarProducto.Location = new System.Drawing.Point(1091, 40);
            this.cmbFiltrarProducto.Name = "cmbFiltrarProducto";
            this.cmbFiltrarProducto.Size = new System.Drawing.Size(205, 39);
            this.cmbFiltrarProducto.TabIndex = 7;
            // 
            // Volver
            // 
            this.Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.Volver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Volver.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.Volver.ForeColor = System.Drawing.Color.White;
            this.Volver.Location = new System.Drawing.Point(6, 632);
            this.Volver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(132, 56);
            this.Volver.TabIndex = 16;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = false;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(1091, 114);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(132, 56);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(68, 40);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(988, 532);
            this.dgvProductos.TabIndex = 6;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnEditar.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(1091, 196);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(132, 56);
            this.btnEditar.TabIndex = 18;
            this.btnEditar.Text = "Modificar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.UseWaitCursor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(1091, 278);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(132, 56);
            this.btnNuevo.TabIndex = 19;
            this.btnNuevo.Text = "Agregar";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // grpProductos
            // 
            this.grpProductos.Controls.Add(this.cmbFiltrarProducto);
            this.grpProductos.Controls.Add(this.btnNuevo);
            this.grpProductos.Controls.Add(this.btnEditar);
            this.grpProductos.Controls.Add(this.dgvProductos);
            this.grpProductos.Controls.Add(this.btnEliminar);
            this.grpProductos.Controls.Add(this.Volver);
            this.grpProductos.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.grpProductos.Location = new System.Drawing.Point(63, 157);
            this.grpProductos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpProductos.Name = "grpProductos";
            this.grpProductos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpProductos.Size = new System.Drawing.Size(1567, 709);
            this.grpProductos.TabIndex = 15;
            this.grpProductos.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBuscarProducto);
            this.panel1.Controls.Add(this.txtBuscarProducto);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1399, 141);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.label1.Font = new System.Drawing.Font("Elephant", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 51);
            this.label1.TabIndex = 23;
            this.label1.Text = "Productos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1394, 906);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpProductos);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Producto";
            this.Text = "Producto";
            this.Load += new System.EventHandler(this.Producto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.grpProductos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.ComboBox cmbFiltrarProducto;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox grpProductos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
