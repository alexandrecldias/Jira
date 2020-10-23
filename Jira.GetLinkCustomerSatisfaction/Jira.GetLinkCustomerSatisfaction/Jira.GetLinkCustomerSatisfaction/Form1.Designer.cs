namespace Jira.GetLinkCustomerSatisfaction
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnResgateLink = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtChamado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.RichTextBox();
            this.chkLembrar = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnProcessarPlanilha = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProcessando = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnResgateLink
            // 
            this.btnResgateLink.Location = new System.Drawing.Point(199, 209);
            this.btnResgateLink.Name = "btnResgateLink";
            this.btnResgateLink.Size = new System.Drawing.Size(142, 71);
            this.btnResgateLink.TabIndex = 0;
            this.btnResgateLink.Text = "Resgatar Link";
            this.btnResgateLink.UseVisualStyleBackColor = true;
            this.btnResgateLink.Click += new System.EventHandler(this.btnResgateLink_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senha";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(93, 16);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(174, 26);
            this.txtUsuario.TabIndex = 3;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(93, 49);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(174, 26);
            this.txtSenha.TabIndex = 4;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // txtChamado
            // 
            this.txtChamado.Location = new System.Drawing.Point(7, 17);
            this.txtChamado.Name = "txtChamado";
            this.txtChamado.Size = new System.Drawing.Size(175, 26);
            this.txtChamado.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 40);
            this.label3.TabIndex = 6;
            this.label3.Text = "Digite o número do chamado na caixa Acima\r\nPara gerar o Link de Pesquisa";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(51, 308);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(721, 74);
            this.txtLink.TabIndex = 7;
            this.txtLink.Text = "";
            // 
            // chkLembrar
            // 
            this.chkLembrar.AutoSize = true;
            this.chkLembrar.Location = new System.Drawing.Point(20, 91);
            this.chkLembrar.Name = "chkLembrar";
            this.chkLembrar.Size = new System.Drawing.Size(204, 24);
            this.chkLembrar.TabIndex = 8;
            this.chkLembrar.Text = "Lembrar Usuário/Senha";
            this.chkLembrar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Link";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkLembrar);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Location = new System.Drawing.Point(51, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 152);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtChamado);
            this.panel2.Location = new System.Drawing.Point(356, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 152);
            this.panel2.TabIndex = 11;
            // 
            // btnProcessarPlanilha
            // 
            this.btnProcessarPlanilha.Location = new System.Drawing.Point(364, 210);
            this.btnProcessarPlanilha.Name = "btnProcessarPlanilha";
            this.btnProcessarPlanilha.Size = new System.Drawing.Size(151, 70);
            this.btnProcessarPlanilha.TabIndex = 12;
            this.btnProcessarPlanilha.Text = "Processar Planilha";
            this.btnProcessarPlanilha.UseVisualStyleBackColor = true;
            this.btnProcessarPlanilha.Click += new System.EventHandler(this.btnProcessarPlanilha_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(51, 209);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(721, 25);
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Visible = false;
            // 
            // lblProcessando
            // 
            this.lblProcessando.AutoSize = true;
            this.lblProcessando.Location = new System.Drawing.Point(51, 241);
            this.lblProcessando.Name = "lblProcessando";
            this.lblProcessando.Size = new System.Drawing.Size(118, 20);
            this.lblProcessando.TabIndex = 14;
            this.lblProcessando.Text = "Processando ...";
            this.lblProcessando.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 404);
            this.Controls.Add(this.lblProcessando);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnProcessarPlanilha);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.btnResgateLink);
            this.Name = "Form1";
            this.Text = "JIRA GetLink Customer Satisfaction";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResgateLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtChamado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtLink;
        private System.Windows.Forms.CheckBox chkLembrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnProcessarPlanilha;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProcessando;
    }
}

