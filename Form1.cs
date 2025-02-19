using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_Busca_Vetorial.Core;

namespace Sistema_Busca_Vetorial
{
    public partial class Form1 : Form
    {
        private TextBox txtBusca;
        private Button btnBuscar;
        private ListBox listBoxResultados;
        private Label lblDetalhes;
        private ListBox listBoxSugestoes;

        public Form1()
        {
            InitializeComponent();
            CriarControles();
        }

        private void CriarControles()
        {
            // Criando o campo de busca (TextBox)
            txtBusca = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 200,
                Name = "txtBusca"
            };

            // Criando o botão de busca
            btnBuscar = new Button
            {
                Location = new System.Drawing.Point(230, 18),
                Text = "Buscar",
                Name = "btnBuscar",
                Width = 80
            };
            btnBuscar.Click += BtnBuscar_Click;

            // Criando a lista de resultados (ListBox)
            listBoxResultados = new ListBox
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(290, 150),
                Name = "listBoxResultados"
            };
            listBoxResultados.SelectedIndexChanged += ListBoxResultados_SelectedIndexChanged;

            // Criando um label para exibir detalhes do produto
            lblDetalhes = new Label
            {
                Location = new System.Drawing.Point(20, 220),
                Size = new System.Drawing.Size(400, 50),
                Name = "lblDetalhes",
                BorderStyle = BorderStyle.FixedSingle
            };

            // Criando a lista de sugestões (ListBox)
            listBoxSugestoes = new ListBox
            {
                Location = new System.Drawing.Point(20, 280),
                Size = new System.Drawing.Size(290, 100),
                Name = "listBoxSugestoes"
            };

            // Adicionando os controles ao formulário
            this.Controls.Add(txtBusca);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(listBoxResultados);
            this.Controls.Add(lblDetalhes);
            this.Controls.Add(listBoxSugestoes);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBusca.Text.Trim();
            if (!string.IsNullOrEmpty(termoBusca))
            {
                Loja loja = new Loja();
                loja.CarregarProdutos("produtos.txt");
                var resultados = loja.BuscarProdutosVetorial(termoBusca);

                listBoxResultados.Items.Clear();
                foreach (var produto in resultados)
                {
                    listBoxResultados.Items.Add(produto.Nome);
                }
            }
        }

        private void ListBoxResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxResultados.SelectedIndex != -1)
            {
                string produtoSelecionado = listBoxResultados.SelectedItem.ToString();
                Loja loja = new Loja();
                loja.CarregarProdutos("produtos.txt");
                var produto = loja.Produtos.FirstOrDefault(p => p.Nome == produtoSelecionado);

                if (produto != null)
                {
                    lblDetalhes.Text = produto.ToString();

                    // Mostrar sugestões de produtos semelhantes
                    var sugestoes = loja.SugerirItensSemelhantes(produto);
                    listBoxSugestoes.Items.Clear();
                    foreach (var sugestao in sugestoes)
                    {
                        listBoxSugestoes.Items.Add(sugestao.Nome);
                    }
                }
            }
        }
    }
}
