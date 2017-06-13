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

namespace FormCadastro
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioDTO cliente = new UsuarioDTO();
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPFCNPJ.Text;
            cliente.Email = txtEmail.Text;
            cliente.DataNascimento = dtpDataNascimento.Value;
            try
            {
                new UsuarioBLL().ValidarCliente(cliente);
                MessageBox.Show("Cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
