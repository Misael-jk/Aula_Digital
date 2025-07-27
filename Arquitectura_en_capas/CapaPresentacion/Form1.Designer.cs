namespace Sistema_de_notebooks
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtCodigoBarra = new TextBox();
            txtNumeroSerie = new TextBox();
            btnGuardar = new Button();
            cmbEstado = new ComboBox();
            cmbTipoElemento = new ComboBox();
            cmbCarrito = new ComboBox();
            btnBuscar = new Button();
            txtCodigoBarraBuscar = new TextBox();
            btnBuscarCarrito = new Button();
            cmbBuscarCarrito = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(276, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(608, 161);
            dataGridView1.TabIndex = 0;
            // 
            // txtCodigoBarra
            // 
            txtCodigoBarra.Location = new Point(12, 128);
            txtCodigoBarra.Name = "txtCodigoBarra";
            txtCodigoBarra.Size = new Size(100, 23);
            txtCodigoBarra.TabIndex = 2;
            // 
            // txtNumeroSerie
            // 
            txtNumeroSerie.Location = new Point(12, 49);
            txtNumeroSerie.Name = "txtNumeroSerie";
            txtNumeroSerie.Size = new Size(100, 23);
            txtNumeroSerie.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(243, 326);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "button1";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(12, 361);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 5;
            // 
            // cmbTipoElemento
            // 
            cmbTipoElemento.FormattingEnabled = true;
            cmbTipoElemento.Location = new Point(12, 295);
            cmbTipoElemento.Name = "cmbTipoElemento";
            cmbTipoElemento.Size = new Size(121, 23);
            cmbTipoElemento.TabIndex = 6;
            // 
            // cmbCarrito
            // 
            cmbCarrito.FormattingEnabled = true;
            cmbCarrito.Location = new Point(12, 210);
            cmbCarrito.Name = "cmbCarrito";
            cmbCarrito.Size = new Size(121, 23);
            cmbCarrito.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(358, 48);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "button1";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtCodigoBarraBuscar
            // 
            txtCodigoBarraBuscar.Location = new Point(358, 12);
            txtCodigoBarraBuscar.Name = "txtCodigoBarraBuscar";
            txtCodigoBarraBuscar.Size = new Size(100, 23);
            txtCodigoBarraBuscar.TabIndex = 9;
            // 
            // btnBuscarCarrito
            // 
            btnBuscarCarrito.Location = new Point(536, 49);
            btnBuscarCarrito.Name = "btnBuscarCarrito";
            btnBuscarCarrito.Size = new Size(75, 23);
            btnBuscarCarrito.TabIndex = 10;
            btnBuscarCarrito.Text = "button1";
            btnBuscarCarrito.UseVisualStyleBackColor = true;
            btnBuscarCarrito.Click += btnBuscarCarrito_Click;
            // 
            // cmbBuscarCarrito
            // 
            cmbBuscarCarrito.FormattingEnabled = true;
            cmbBuscarCarrito.Location = new Point(520, 12);
            cmbBuscarCarrito.Name = "cmbBuscarCarrito";
            cmbBuscarCarrito.Size = new Size(121, 23);
            cmbBuscarCarrito.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(896, 450);
            Controls.Add(cmbBuscarCarrito);
            Controls.Add(btnBuscarCarrito);
            Controls.Add(txtCodigoBarraBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(cmbCarrito);
            Controls.Add(cmbTipoElemento);
            Controls.Add(cmbEstado);
            Controls.Add(btnGuardar);
            Controls.Add(txtNumeroSerie);
            Controls.Add(txtCodigoBarra);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtCodigoBarra;
        private TextBox txtNumeroSerie;
        private Button btnGuardar;
        private ComboBox cmbEstado;
        private ComboBox cmbTipoElemento;
        private ComboBox cmbCarrito;
        private Button btnBuscar;
        private TextBox txtCodigoBarraBuscar;
        private Button btnBuscarCarrito;
        private ComboBox cmbBuscarCarrito;
    }
}
