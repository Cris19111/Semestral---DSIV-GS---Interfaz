namespace Semestral___DSIV_GS
{
    partial class Ordenes
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
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.Volver = new System.Windows.Forms.Button();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(34, 136);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(1119, 517);
            this.dgvProductos.TabIndex = 6;
            // 
            // Volver
            // 
            this.Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.Volver.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.Volver.ForeColor = System.Drawing.Color.White;
            this.Volver.Location = new System.Drawing.Point(34, 680);
            this.Volver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(132, 56);
            this.Volver.TabIndex = 17;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = false;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // btnFiltro
            // 
            this.btnFiltro.BackColor = System.Drawing.Color.White;
            this.btnFiltro.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.btnFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.btnFiltro.Location = new System.Drawing.Point(612, 25);
            this.btnFiltro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(132, 56);
            this.btnFiltro.TabIndex = 20;
            this.btnFiltro.Text = "Buscar";
            this.btnFiltro.UseVisualStyleBackColor = false;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Sylfaen", 10.8F);
            this.txtFiltro.Location = new System.Drawing.Point(768, 37);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(401, 36);
            this.txtFiltro.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnFiltro);
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 100);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.label1.Font = new System.Drawing.Font("Elephant", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 51);
            this.label1.TabIndex = 22;
            this.label1.Text = "Ordenes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ordenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1181, 761);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Volver);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Ordenes";
            this.Text = "Ordenes";
            this.Load += new System.EventHandler(this.Ordenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}