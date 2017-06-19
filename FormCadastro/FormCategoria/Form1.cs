using DTO;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCategoria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CategoriaBLL bll = new CategoriaBLL();

        private void HabilitarNovo()
        {
            LimparCampos();           
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnRefresh.Enabled = false;
            btnCadastrar.Enabled = true;
        }

        private void DesabilitarNovo()
        {            
            btnCadastrar.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnRefresh.Enabled = true;
        }

        private void LimparCampos()
        {
            txtCategoria.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //CRUD
            CategoriaDTO categoria = new CategoriaDTO();
            categoria.Categoria = txtCategoria.Text;
            
            try
            {
                bll.CadastrarCategoria(categoria);
                MessageBox.Show("Cadastrado com sucesso.");
                LimparCampos();
                dataGridView1.DataSource = bll.LerTodosCategorias();
                DesabilitarNovo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.LerTodosCategorias();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CategoriaDTO categoria = (CategoriaDTO)dataGridView1.SelectedRows[0].DataBoundItem;
            txtCategoria.Text = categoria.Categoria;
            txtID.Text = Convert.ToString(categoria.ID);
            DesabilitarNovo();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarNovo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.LerTodosCategorias();
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
                bll.ExcluirCategoria(Convert.ToInt32(aux));
                MessageBox.Show("Excluído com sucesso.");
                dataGridView1.DataSource = bll.LerTodosCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CategoriaDTO categoria = new CategoriaDTO();

            try
            {

                categoria.ID = Convert.ToInt32(txtID.Text);
                categoria.Categoria = txtCategoria.Text;
                
            }
            catch (FormatException)
            {

            }

            try
            {

                bll.EditarCategoria(categoria);
                MessageBox.Show("Editado com sucesso.");
                LimparCampos();
                dataGridView1.DataSource = bll.LerTodosCategorias();
                DesabilitarNovo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }
}
