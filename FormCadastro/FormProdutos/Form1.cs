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

namespace FormProdutos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProdutoBLL bll = new ProdutoBLL();

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
            txtDescricao.Clear();
            txtID.Clear();
            txtPreco.Clear();
            txtQtdEstoque.Clear();
            txtQtdEstoqueMinimo.Clear();
            cmbUnidadeMedida.Select(0,0);
            cmbCategoria.Select(0,0);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarNovo();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            //CRUD
            ProdutoDTO produto = new ProdutoDTO();
            produto.Descricao = txtDescricao.Text;
            produto.Preco = Convert.ToDouble(txtPreco.Text);
            produto.UnidadeMedida = (EnumProdutoDTO)cmbUnidadeMedida.SelectedIndex;
            produto.QtdEstoque = Convert.ToDouble(txtQtdEstoque.Text);
            produto.QtdEstoqueMinimo = Convert.ToDouble(txtQtdEstoqueMinimo.Text);            
            produto.Categoria = (++(cmbCategoria.SelectedIndex));
            produto.Ativo = chkAtivo.Checked;         
           

            try
            {
                bll.CadastrarProduto(produto);
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

        private void Form1_Load(object sender, EventArgs e)
        {

            HabilitarNovo();
            cmbCategoria.DisplayMember = "CATEGORIA";            
            cmbCategoria.DataSource = bll.LerTodasCategorias();
            dataGridView1.DataSource = bll.LerTodos();
            cmbUnidadeMedida.DataSource = Enum.GetValues(typeof(EnumProdutoDTO));
            
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdutoDTO produto = (ProdutoDTO)dataGridView1.SelectedRows[0].DataBoundItem;
            txtID.Text = produto.ID.ToString();
            txtDescricao.Text = produto.Descricao.ToString();
            txtPreco.Text = produto.Preco.ToString();
            txtQtdEstoque.Text = produto.QtdEstoque.ToString();
            txtQtdEstoqueMinimo.Text = produto.QtdEstoqueMinimo.ToString();
            int aux = (int)produto.Categoria;
            cmbCategoria.SelectedIndex = (--(aux));
            cmbUnidadeMedida.SelectedItem = (EnumProdutoDTO)produto.UnidadeMedida;
            chkAtivo.Checked = produto.Ativo;
         
            DesabilitarNovo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.LerTodos();
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                bll.ExcluirProduto(Convert.ToInt32(aux));
                MessageBox.Show("Excluído com sucesso.");
                dataGridView1.DataSource = bll.LerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProdutoDTO produto = new ProdutoDTO();

            try
            {
                produto.ID = Convert.ToInt32(txtID.Text);
                produto.Descricao = txtDescricao.Text;
                produto.Preco = Convert.ToDouble(txtPreco.Text);
                produto.UnidadeMedida = (EnumProdutoDTO)cmbUnidadeMedida.SelectedIndex;
                produto.QtdEstoque = Convert.ToDouble(txtQtdEstoque.Text);
                produto.QtdEstoqueMinimo = Convert.ToDouble(txtQtdEstoqueMinimo.Text);
                produto.Categoria = (++(cmbCategoria.SelectedIndex));
                produto.Ativo = chkAtivo.Checked;

            }
            catch (FormatException)
            {

            }

            try
            {

                bll.EditarProduto(produto);
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
