namespace CapaPresentacion
{
    partial class frmLogin
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
            panel1 = new Panel();
            label1 = new Label();
            lbExit = new Label();
            panel3 = new Panel();
            chkPassword = new CheckBox();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.BlueViolet;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lbExit);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(370, 35);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(48, 18);
            label1.TabIndex = 1;
            label1.Text = "Login";
            // 
            // lbExit
            // 
            lbExit.AutoSize = true;
            lbExit.Cursor = Cursors.Hand;
            lbExit.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbExit.ForeColor = SystemColors.ControlLightLight;
            lbExit.Location = new Point(301, 9);
            lbExit.Name = "lbExit";
            lbExit.Size = new Size(22, 23);
            lbExit.TabIndex = 0;
            lbExit.Text = "X";
            lbExit.Click += lbExit_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Indigo;
            panel3.Controls.Add(chkPassword);
            panel3.Controls.Add(btnLogin);
            panel3.Controls.Add(txtPassword);
            panel3.Controls.Add(txtUsuario);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(0, 35);
            panel3.Name = "panel3";
            panel3.Size = new Size(323, 315);
            panel3.TabIndex = 2;
            // 
            // chkPassword
            // 
            chkPassword.AutoSize = true;
            chkPassword.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkPassword.ForeColor = SystemColors.ControlLightLight;
            chkPassword.Location = new Point(182, 209);
            chkPassword.Name = "chkPassword";
            chkPassword.Size = new Size(122, 21);
            chkPassword.TabIndex = 6;
            chkPassword.Text = "Show Password";
            chkPassword.UseVisualStyleBackColor = true;
            chkPassword.CheckedChanged += chkPassword_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(124, 266);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(180, 36);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(124, 171);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(180, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(124, 115);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(180, 23);
            txtUsuario.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Info;
            label3.Location = new Point(12, 173);
            label3.Name = "label3";
            label3.Size = new Size(92, 21);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(39, 117);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 1;
            label2.Text = "Usuario";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Espacio_Digital_Logo_removebg_preview;
            pictureBox1.Location = new Point(49, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(221, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 349);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            Load += frmLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lbExit;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private TextBox txtPassword;
        private TextBox txtUsuario;
        private Label label3;
        private Label label2;
        private Button btnLogin;
        private Label label1;
        private CheckBox chkPassword;
    }
}