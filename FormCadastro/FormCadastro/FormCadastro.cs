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
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnRefresh.Enabled = false;
            btnCadastrar.Enabled = true;
        }

        private void DesabilitarNovo()
        {
            txtID.ForeColor = SystemColors.WindowText;
            btnCadastrar.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnRefresh.Enabled = true;
        }

        private void LimparCampos()
        {
            txtID.Clear();
            txtEmail.Clear();
            txtNome.Clear();
            txtCPFCNPJ.Clear();
            dtpDataNascimento.Value = DateTime.Now;
        }                        
                      

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            //CRUD
            UsuarioDTO cliente = new UsuarioDTO();
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPFCNPJ.Text;
            cliente.Email = txtEmail.Text;
            cliente.DataNascimento = dtpDataNascimento.Value;
            try
            {
                bll.CadastrarCliente(cliente);
                MessageBox.Show("Cadastrado com sucesso.");
                LimparCampos();
                dataGridView1.DataSource = bll.LerTodos();
                DesabilitarNovo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCadastro_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.LerTodos();
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            UsuarioDTO cliente = (UsuarioDTO)dataGridView1.SelectedRows[0].DataBoundItem;
            txtID.Text = cliente.ID.ToString();
            txtNome.Text = cliente.Nome;
            txtEmail.Text = cliente.Email;
            txtCPFCNPJ.Text = cliente.CPF;
            dtpDataNascimento.Value = cliente.DataNascimento;
            DesabilitarNovo();
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            HabilitarNovo();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.LerTodos();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
                                    
            DialogResult result =
                MessageBox.Show("Você tem certeza que deseja excluir este registro?",
                                "Confirmação de Exclusão",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
                       

            try
            {
                int aux = 0;
                int.TryParse(txtID.Text, out aux);
                bll.ExcluirCliente(Convert.ToInt32(aux));
                MessageBox.Show("Excluído com sucesso.");
                dataGridView1.DataSource = bll.LerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            UsuarioDTO cliente = new UsuarioDTO();

            try
            {
                
                cliente.ID = Convert.ToInt32(txtID.Text);
                cliente.Nome = txtNome.Text;
                cliente.CPF = txtCPFCNPJ.Text;
                cliente.Email = txtEmail.Text;
                cliente.DataNascimento = dtpDataNascimento.Value;
            }
            catch (FormatException)
            {
               
            }           
          
            try
            {

                bll.EditarCliente(cliente);
                MessageBox.Show("Editado com sucesso.");
                LimparCampos();
                dataGridView1.DataSource = bll.LerTodos();
                DesabilitarNovo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
