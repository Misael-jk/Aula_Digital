namespace CapaPresentacion
{
    partial class frmPrincipal
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
            lbExit = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            btnUsuarios = new Button();
            btnDevoluciones = new Button();
            btnPrestamos = new Button();
            btnDocentes = new Button();
            btnCarritos = new Button();
            lbWelcome = new Label();
            btnElementos = new Button();
            pictureBox1 = new PictureBox();
            btnCategorias = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbExit
            // 
            lbExit.AutoSize = true;
            lbExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbExit.ForeColor = SystemColors.ControlLightLight;
            lbExit.Location = new Point(1071, 9);
            lbExit.Name = "lbExit";
            lbExit.Size = new Size(20, 21);
            lbExit.TabIndex = 0;
            lbExit.Text = "X";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lbExit);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1101, 42);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Location = new Point(248, 42);
            panel3.Name = "panel3";
            panel3.Size = new Size(853, 611);
            panel3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(204, 25);
            label1.TabIndex = 1;
            label1.Text = "Sistema de Prestamos";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCategorias);
            panel2.Controls.Add(btnUsuarios);
            panel2.Controls.Add(btnDevoluciones);
            panel2.Controls.Add(btnPrestamos);
            panel2.Controls.Add(btnDocentes);
            panel2.Controls.Add(btnCarritos);
            panel2.Controls.Add(lbWelcome);
            panel2.Controls.Add(btnElementos);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(0, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(251, 617);
            panel2.TabIndex = 2;
            // 
            // btnUsuarios
            // 
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuarios.Location = new Point(21, 443);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(204, 39);
            btnUsuarios.TabIndex = 9;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnDevoluciones
            // 
            btnDevoluciones.FlatStyle = FlatStyle.Flat;
            btnDevoluciones.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDevoluciones.Location = new Point(21, 386);
            btnDevoluciones.Name = "btnDevoluciones";
            btnDevoluciones.Size = new Size(204, 39);
            btnDevoluciones.TabIndex = 8;
            btnDevoluciones.Text = "Devoluciones";
            btnDevoluciones.UseVisualStyleBackColor = true;
            // 
            // btnPrestamos
            // 
            btnPrestamos.FlatStyle = FlatStyle.Flat;
            btnPrestamos.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrestamos.Location = new Point(21, 328);
            btnPrestamos.Name = "btnPrestamos";
            btnPrestamos.Size = new Size(204, 39);
            btnPrestamos.TabIndex = 7;
            btnPrestamos.Text = "Prestamos";
            btnPrestamos.UseVisualStyleBackColor = true;
            // 
            // btnDocentes
            // 
            btnDocentes.FlatStyle = FlatStyle.Flat;
            btnDocentes.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDocentes.Location = new Point(21, 274);
            btnDocentes.Name = "btnDocentes";
            btnDocentes.Size = new Size(204, 39);
            btnDocentes.TabIndex = 6;
            btnDocentes.Text = "Docentes";
            btnDocentes.UseVisualStyleBackColor = true;
            // 
            // btnCarritos
            // 
            btnCarritos.FlatStyle = FlatStyle.Flat;
            btnCarritos.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCarritos.Location = new Point(21, 217);
            btnCarritos.Name = "btnCarritos";
            btnCarritos.Size = new Size(204, 39);
            btnCarritos.TabIndex = 5;
            btnCarritos.Text = "Carritos";
            btnCarritos.UseVisualStyleBackColor = true;
            // 
            // lbWelcome
            // 
            lbWelcome.AutoSize = true;
            lbWelcome.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbWelcome.ForeColor = SystemColors.ControlLightLight;
            lbWelcome.Location = new Point(21, 107);
            lbWelcome.Name = "lbWelcome";
            lbWelcome.Size = new Size(70, 30);
            lbWelcome.TabIndex = 4;
            lbWelcome.Text = "label2";
            // 
            // btnElementos
            // 
            btnElementos.FlatStyle = FlatStyle.Flat;
            btnElementos.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnElementos.Location = new Point(21, 161);
            btnElementos.Name = "btnElementos";
            btnElementos.Size = new Size(204, 39);
            btnElementos.TabIndex = 3;
            btnElementos.Text = "Elementos";
            btnElementos.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Espacio_Digital_Logo_removebg_preview;
            pictureBox1.Location = new Point(21, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnCategorias
            // 
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCategorias.Location = new Point(21, 502);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(204, 39);
            btnCategorias.TabIndex = 10;
            btnCategorias.Text = "Categorias";
            btnCategorias.UseVisualStyleBackColor = true;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPrincipal";
            Load += frmPrincipal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbExit;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel3;
        private Button btnElementos;
        private Label lbWelcome;
        private Button btnUsuarios;
        private Button btnDevoluciones;
        private Button btnPrestamos;
        private Button btnDocentes;
        private Button btnCarritos;
        private Button btnCategorias;
    }
}