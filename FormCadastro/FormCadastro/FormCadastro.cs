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
            cliente.CPF = txtCPF.Text;
            cliente.Email = txtEmail.Text;
            cliente.DataNascimento = dtpDataNascimento.Value;
            try
            {
                new UsuarioBLL().ValidarCasatroCliente(cliente);
                MessageBox.Show("Cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            UsuarioDTO cliente = new UsuarioDTO();
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.Email = txtEmail.Text;
            cliente.DataNascimento = dtpDataNascimento.Value;
            try
            {
                new UsuarioBLL().ValidarCliente(cliente);
                MessageBox.Show("Editado com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            UsuarioDTO cliente = new UsuarioDTO();
            
            try
            {
                UsuarioBLL clienteBLL = new UsuarioBLL();            
                cliente = clienteBLL.ValidarPesquisaCliente(cliente);
                cliente.Nome = txtNome.Text;
                cliente.CPF = txtCPF.Text;
                cliente.Email = txtEmail.Text;
                //cliente.DataNascimento = dtpDataNascimento.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
