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
    }
}
