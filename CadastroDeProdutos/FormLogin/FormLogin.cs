using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuario = new UsuarioDTO();
            usuario.SetNome(Convert.ToString(txtUsuario.Text));
            usuario.SetSenha(Convert.ToString(txtSenha.Text));
            if (new UsuarioBLL().ValidarLogin(usuario))
            {
                MessageBox.Show("Login realizado");
            }
            else
            {
                MessageBox.Show("Usuario ou Senha incorretos.");
            }
        }
    }
}
