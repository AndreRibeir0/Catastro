namespace FormCadastro
{
    partial class FormCadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCPFCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.lblCPFCNPJ = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dtpDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(12, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 56);
            this.button1.TabIndex = 39;
            this.button1.Text = "CADASTRAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = " Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Nome";
            // 
            // txtCPFCNPJ
            // 
            this.txtCPFCNPJ.Location = new System.Drawing.Point(12, 85);
            this.txtCPFCNPJ.Mask = "000,000,000-00";
            this.txtCPFCNPJ.Name = "txtCPFCNPJ";
            this.txtCPFCNPJ.Size = new System.Drawing.Size(208, 20);
            this.txtCPFCNPJ.TabIndex = 35;
            // 
            // lblCPFCNPJ
            // 
            this.lblCPFCNPJ.AutoSize = true;
            this.lblCPFCNPJ.Location = new System.Drawing.Point(12, 69);
            this.lblCPFCNPJ.Name = "lblCPFCNPJ";
            this.lblCPFCNPJ.Size = new System.Drawing.Size(27, 13);
            this.lblCPFCNPJ.TabIndex = 34;
            this.lblCPFCNPJ.Text = "CPF";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 124);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 20);
            this.txtEmail.TabIndex = 32;
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNascimento.Location = new System.Drawing.Point(12, 163);
            this.dtpDataNascimento.Name = "dtpDataNascimento";
            this.dtpDataNascimento.Size = new System.Drawing.Size(208, 20);
            this.dtpDataNascimento.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Data Nascimento";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 46);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(208, 20);
            this.txtNome.TabIndex = 31;
            // 
            // FormCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 336);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCPFCNPJ);
            this.Controls.Add(this.lblCPFCNPJ);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.dtpDataNascimento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNome);
            this.Name = "FormCadastro";
            this.Text = "FormCadastro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtCPFCNPJ;
        private System.Windows.Forms.Label lblCPFCNPJ;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dtpDataNascimento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
    }
}

