namespace Semestral___DSIV_GS
{
    partial class FormHistorial
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
            this.cmbBoxFiltro = new System.Windows.Forms.ComboBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvFracturas = new System.Windows.Forms.DataGridView();
            this.Volver = new System.Windows.Forms.Button();
            this.btnFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFracturas)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBoxFiltro
            // 
            this.cmbBoxFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbBoxFiltro.FormattingEnabled = true;
            this.cmbBoxFiltro.Items.AddRange(new object[] {
            "Categorias de Busqueda"});
            this.cmbBoxFiltro.Location = new System.Drawing.Point(522, 31);
            this.cmbBoxFiltro.Name = "cmbBoxFiltro";
            this.cmbBoxFiltro.Size = new System.Drawing.Size(125, 28);
            this.cmbBoxFiltro.TabIndex = 7;
            this.cmbBoxFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbBoxFiltro_SelectedIndexChanged);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFiltro.Location = new System.Drawing.Point(16, 31);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(500, 26);
            this.txtFiltro.TabIndex = 6;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(65, 23);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Ventas";
            // 
            // dgvFracturas
            // 
            this.dgvFracturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFracturas.Location = new System.Drawing.Point(12, 78);
            this.dgvFracturas.Name = "dgvFracturas";
            this.dgvFracturas.RowHeadersWidth = 51;
            this.dgvFracturas.RowTemplate.Height = 24;
            this.dgvFracturas.Size = new System.Drawing.Size(645, 340);
            this.dgvFracturas.TabIndex = 4;
            this.dgvFracturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFracturas_CellContentClick);
            // 
            // Volver
            // 
            this.Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Volver.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(16, 431);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(117, 45);
            this.Volver.TabIndex = 17;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = false;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // btnFiltro
            // 
            this.btnFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFiltro.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltro.Location = new System.Drawing.Point(507, 431);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(117, 45);
            this.btnFiltro.TabIndex = 18;
            this.btnFiltro.Text = "Buscar";
            this.btnFiltro.UseVisualStyleBackColor = false;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // FormHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 488);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.cmbBoxFiltro);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvFracturas);
            this.Name = "FormHistorial";
            this.Text = "FormHistorial";
            this.Load += new System.EventHandler(this.FormHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFracturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBoxFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvFracturas;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Button btnFiltro;
    }
}