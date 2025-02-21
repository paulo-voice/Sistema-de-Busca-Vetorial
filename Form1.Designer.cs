namespace Sistema_Busca_Vetorial
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblDetalhamento = new System.Windows.Forms.Label();
            this.lstSugestoes = new System.Windows.Forms.ListBox();
            this.lblLista = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.pbImagemProduto = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagemProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(841, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtBuscar.Location = new System.Drawing.Point(51, 10);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.txtBuscar.MaximumSize = new System.Drawing.Size(800, 25);
            this.txtBuscar.MinimumSize = new System.Drawing.Size(500, 25);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(780, 21);
            this.txtBuscar.TabIndex = 2;
            // 
            // lblDetalhamento
            // 
            this.lblDetalhamento.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblDetalhamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetalhamento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDetalhamento.Location = new System.Drawing.Point(400, 442);
            this.lblDetalhamento.Name = "lblDetalhamento";
            this.lblDetalhamento.Size = new System.Drawing.Size(550, 120);
            this.lblDetalhamento.TabIndex = 3;
            // 
            // lstSugestoes
            // 
            this.lstSugestoes.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lstSugestoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSugestoes.FormattingEnabled = true;
            this.lstSugestoes.Location = new System.Drawing.Point(51, 443);
            this.lstSugestoes.Name = "lstSugestoes";
            this.lstSugestoes.Size = new System.Drawing.Size(300, 119);
            this.lstSugestoes.TabIndex = 4;
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLista.Location = new System.Drawing.Point(50, 64);
            this.lblLista.Margin = new System.Windows.Forms.Padding(3);
            this.lblLista.Name = "lblLista";
            this.lblLista.Padding = new System.Windows.Forms.Padding(3, 2, 3, 1);
            this.lblLista.Size = new System.Drawing.Size(119, 22);
            this.lblLista.TabIndex = 5;
            this.lblLista.Text = "Lista De Items";
            // 
            // lstItems
            // 
            this.lstItems.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lstItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(51, 93);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(353, 288);
            this.lstItems.TabIndex = 1;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // pbImagemProduto
            // 
            this.pbImagemProduto.BackColor = System.Drawing.Color.PaleTurquoise;
            this.pbImagemProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagemProduto.Location = new System.Drawing.Point(540, 92);
            this.pbImagemProduto.Name = "pbImagemProduto";
            this.pbImagemProduto.Size = new System.Drawing.Size(290, 290);
            this.pbImagemProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagemProduto.TabIndex = 7;
            this.pbImagemProduto.TabStop = false;
            this.pbImagemProduto.Click += new System.EventHandler(this.pbImagemProduto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 417);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 1);
            this.label1.Size = new System.Drawing.Size(157, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lista De Sugestões";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(400, 417);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 1);
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descrição";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(540, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 1);
            this.label3.Size = new System.Drawing.Size(71, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Imagem";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(1007, 577);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.pbImagemProduto);
            this.Controls.Add(this.lstSugestoes);
            this.Controls.Add(this.lblDetalhamento);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.MaximumSize = new System.Drawing.Size(1023, 616);
            this.MinimumSize = new System.Drawing.Size(1023, 616);
            this.Name = "Form1";
            this.Text = "Busca Vetorial";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagemProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblDetalhamento;
        private System.Windows.Forms.ListBox lstSugestoes;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.PictureBox pbImagemProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

