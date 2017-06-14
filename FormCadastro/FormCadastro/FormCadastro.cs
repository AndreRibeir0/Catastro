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

        UsuarioBLL bll = new UsuarioBLL();

        private void HabilitarNovo()
        {
            LimparCampos();
            txtID.ForeColor = Color.Red;
            txtID.Text = "*ID GERADO AUTOMATICAMENTE*";
            btnRefresh.Enabled = false;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
            btnCadastrar.Enabled = true;

        }

        private void DesabilitarNovo()
        {
            txtID.ForeColor = SystemColors.WindowText;
            btnCadastrar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnRefresh.Enabled = true;
        }

        private void LimparCampos()
        {
            txtID.Clear();
            txtEmail.Clear();
            txtNome.Clear();
            txtCPF.Clear();
            dtpDataNascimento.Value = DateTime.Now;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
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
                dataGridView1.DataSource = bll.LerTodos();
                DesabilitarNovo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            UsuarioDTO cliente = new UsuarioDTO();
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.Email = txtEmail.Text;
            cliente.DataNascimento = dtpDataNascimento.Value;

            try
            {
                UsuarioBLL clienteBLL = new UsuarioBLL();            
                cliente = clienteBLL.ValidarPesquisaCliente(cliente);
                txtNome.Text = cliente.Nome;
                txtCPF.Text = cliente.CPF;
                txtEmail.Text = cliente.Email;
                dtpDataNascimento.Value = cliente.DataNascimento;               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //36866666775

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem ceteza que deseja excluir esse registro?", 
                "Confirmação de exclusão",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                bll.ExcluirCliente(Convert.ToInt32(txtID.Text));
                MessageBox.Show("Excluído com sucesso.");
                dataGridView1.DataSource = bll.LerTodos();
            }
            catch (Exception)
            {

                MessageBox.Show("Erro no banco de dados, contate o adm.");
            }
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.LerTodos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UsuarioDTO cliente = (UsuarioDTO)dataGridView1.SelectedRows[0].DataBoundItem;
            txtID.Text = cliente.ID.ToString();
            txtNome.Text = cliente.Nome;
            txtEmail.Text = cliente.Email;
            txtCPF.Text = cliente.CPF;
            DesabilitarNovo();

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarNovo();
        }

        
        

    }
}
