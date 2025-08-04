using CapaDatos.Interfaces;
using CapaDatos.Repos;
using CapaNegocio;
using CapaNegocio.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        private IDbConnection conexion;
        private readonly RepoRoles repoRoles;
        private readonly RepoUsuarios repoUsuarios;
        private readonly UsuariosCN usuariosCN;

        public frmLogin(IDbConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;

            repoUsuarios = new RepoUsuarios(conexion);
            repoRoles = new RepoRoles(conexion);
            usuariosCN = new UsuariosCN(repoUsuarios, repoRoles);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#F5A623");
            panel3.BackColor = ColorTranslator.FromHtml("#4A1F47");
            btnLogin.BackColor = ColorTranslator.FromHtml("#F5A623");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            var verificarLogin = usuariosCN.ObtenerLogin(usuario, password);

            if (verificarLogin is not null)
            {
                frmPrincipal principal = new frmPrincipal();
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
