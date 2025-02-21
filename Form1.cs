using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Sistema_Busca_Vetorial.Core;

namespace Sistema_Busca_Vetorial
{
    public partial class Form1 : Form
    {
        private Loja loja;

        public Form1()
        {
            InitializeComponent();
            loja = new Loja();
            loja.CarregarProdutos("produtos.txt");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(termoBusca))
            {
                var resultados = loja.BuscarProdutosVetorial(termoBusca);

                lstItems.Items.Clear();
                foreach (var produto in resultados)
                {
                    lstItems.Items.Add(produto.Nome);
                }
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex != -1)
            {
                string produtoSelecionado = lstItems.SelectedItem.ToString();
                var produto = loja.Produtos.FirstOrDefault(p => p.Nome == produtoSelecionado);

                if (produto != null)
                {
                    lblDetalhamento.Text = $"Nome: {produto.Nome}\nDescrição: {produto.Descricao}\nTamanhos: {produto.TamanhosDisponiveis}\nPreço: {produto.Preco:C}";

                    // Exibir imagem do produto no PictureBox
                    CarregarImagemProduto(produto.CaminhoImagem);

                    // Mostrar sugestões de produtos semelhantes
                    var sugestoes = loja.SugerirItensSemelhantes(produto);
                    lstSugestoes.Items.Clear();
                    foreach (var sugestao in sugestoes)
                    {
                        lstSugestoes.Items.Add(sugestao.Nome);
                    }
                }
            }
        }

        private void CarregarImagemProduto(string caminhoImagem)
        {
            // Verifica se o caminho da imagem é válido e se o arquivo realmente existe
            if (!string.IsNullOrEmpty(caminhoImagem) && File.Exists(caminhoImagem))
            {
                try
                {
                    // Libera a imagem anterior antes de carregar uma nova
                    if (pbImagemProduto.Image != null)
                    {
                        pbImagemProduto.Image.Dispose();
                        pbImagemProduto.Image = null;
                    }

                    // Carrega a imagem corretamente sem bloquear o arquivo
                    using (FileStream fs = new FileStream(caminhoImagem, FileMode.Open, FileAccess.Read))
                    {
                        pbImagemProduto.Image = Image.FromStream(fs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pbImagemProduto.Image = null; // Limpa a imagem em caso de erro
                }
            }
            else
            {
                pbImagemProduto.Image = null; // Se o arquivo não existe, limpa a imagem
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void pbImagemProduto_Click(object sender, EventArgs e)
        {

        }
    }
}
