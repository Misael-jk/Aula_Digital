using CapaDatos.Interfaces;
using CapaDatos.Repos;
using CapaNegocio;
//using CapaNegocio.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class LoginState : Form
    {
        private IDbConnection conexion;
        private readonly RepoRoles repoRoles;
        private readonly RepoUsuarios repoUsuarios;
        private readonly UsuariosCN usuariosCN;
        public LoginState(IDbConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;

            repoUsuarios = new RepoUsuarios(conexion);
            repoRoles = new RepoRoles(conexion);
            //usuariosCN = new UsuariosCN(repoUsuarios, repoRoles);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChckPass.Checked)
            {
                TxtPass.UseSystemPasswordChar = false;
            }
            else
            {
                TxtPass.UseSystemPasswordChar = true;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //string usuario = TxtUser.Text.Trim();
            //string password = TxtPass.Text.Trim();

            //var verificarLogin = usuariosCN.ObtenerLogin(usuario, password);

            FormPrincipal principal = new FormPrincipal(conexion);
            principal.Show();
            this.Hide();

            //if (verificarLogin is not null)
            //{
            //    F
            //}
            //else
            //{
            //    TxtError.Visible = true;
            //}
        }

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TxtPass.Focus();
            }

        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnLogin.PerformClick();
            }
        }
    }
}
