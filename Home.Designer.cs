namespace Semestral___DSIV_GS
{
    partial class Home
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
            this.btn_productos = new System.Windows.Forms.Button();
            this.btn_categorias = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.lbl_logout = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_productos
            // 
            this.btn_productos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_productos.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_productos.Location = new System.Drawing.Point(185, 346);
            this.btn_productos.Margin = new System.Windows.Forms.Padding(4);
            this.btn_productos.Name = "btn_productos";
            this.btn_productos.Size = new System.Drawing.Size(188, 55);
            this.btn_productos.TabIndex = 9;
            this.btn_productos.Text = "Productos";
            this.btn_productos.UseVisualStyleBackColor = true;
            this.btn_productos.Click += new System.EventHandler(this.btn_productos_Click);
            // 
            // btn_categorias
            // 
            this.btn_categorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_categorias.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_categorias.Location = new System.Drawing.Point(185, 260);
            this.btn_categorias.Margin = new System.Windows.Forms.Padding(4);
            this.btn_categorias.Name = "btn_categorias";
            this.btn_categorias.Size = new System.Drawing.Size(188, 55);
            this.btn_categorias.TabIndex = 8;
            this.btn_categorias.Text = "Categorias";
            this.btn_categorias.UseVisualStyleBackColor = true;
            this.btn_categorias.Click += new System.EventHandler(this.btn_categorias_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentas.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.Location = new System.Drawing.Point(185, 171);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(4);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(188, 55);
            this.btnVentas.TabIndex = 7;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // lbl_logout
            // 
            this.lbl_logout.AutoSize = true;
            this.lbl_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_logout.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_logout.Location = new System.Drawing.Point(401, 34);
            this.lbl_logout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_logout.Name = "lbl_logout";
            this.lbl_logout.Size = new System.Drawing.Size(121, 22);
            this.lbl_logout.TabIndex = 6;
            this.lbl_logout.Text = "Cerrar Sesión";
            this.lbl_logout.Click += new System.EventHandler(this.lbl_logout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Panel de Adminstración";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 479);
            this.Controls.Add(this.btn_productos);
            this.Controls.Add(this.btn_categorias);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.lbl_logout);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_productos;
        private System.Windows.Forms.Button btn_categorias;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Label lbl_logout;
        private System.Windows.Forms.Label label1;
    }
}