﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Sistema_Busca_Vetorial.Core;
using System.Drawing;

// Integrantes: Paulo Vinicius Ruffini Azevedo e Caio Corrêa Castro
namespace Sistema_Busca_Vetorial.Core
{
    public class Loja
    {
        public List<Produto> Produtos { get; private set; }
        private Dictionary<string, double> IDF { get; set; }

        public Loja()
        {
            Produtos = new List<Produto>();
        }

        // metodo para carregar produtos a partir de um arquivo de texto
        public void CarregarProdutos(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
                throw new FileNotFoundException($"Arquivo de produtos não encontrado: {caminhoArquivo}");

            Produtos.Clear();
            string[] linhas = File.ReadAllLines(caminhoArquivo);
            Produto produtoAtual = null;

            // diretorio onde as imagens estao armazenadas dentro da pasta do executavel
            string pastaImagens = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagens");

            foreach (string linha in linhas)
            {
                if (linha.StartsWith("Nome:"))
                {
                    produtoAtual = new Produto { Nome = linha.Substring("Nome: ".Length).Trim() };
                }
                else if (linha.StartsWith("Descrição:"))
                {
                    produtoAtual.Descricao = linha.Substring("Descrição: ".Length).Trim();
                }
                else if (linha.StartsWith("Tamanhos disponíveis:"))
                {
                    produtoAtual.TamanhosDisponiveis = linha.Substring("Tamanhos disponíveis: ".Length).Trim();
                }
                else if (linha.StartsWith("Preço:"))
                {
                    string precoStr = linha.Substring("Preço: R$ ".Length).Trim();
                    produtoAtual.Preco = decimal.Parse(precoStr);

                    // nome do arquivo de imagem baseado no nome do produto
                    string nomeArquivoImagem = produtoAtual.Nome + ".png";
                    string caminhoImagem = Path.Combine(pastaImagens, nomeArquivoImagem);

                    // verifica se a imagem existe, se nao, deixa o caminho nulo
                    produtoAtual.CaminhoImagem = File.Exists(caminhoImagem) ? caminhoImagem : null;

                    Produtos.Add(produtoAtual);
                }
            }
            // calcula os vetores TF-IDF para cada produto carregado
            CalcularVetoresTFIDF();
        }

        // metodo para calcular os vetores TF-IDF de cada produto na loja
        private void CalcularVetoresTFIDF()
        {
            var todosDocumentos = Produtos
                .Select(p => TextoHelper.AplicarStemming(
                    TextoHelper.RemoverStopwords(
                        TextoHelper.Tokenizar(p.Nome + " " + p.Descricao)
                    )
                ))
                .ToList();

            // calcula o IDF para todas as palavras dos produtos
            IDF = TFIDF.CalcularIDF(todosDocumentos);

            foreach (var produto in Produtos)
            {
                var tokens = TextoHelper.AplicarStemming(
                    TextoHelper.RemoverStopwords(
                        TextoHelper.Tokenizar(produto.Nome + " " + produto.Descricao)
                    )
                );
                var tf = TFIDF.CalcularTF(tokens);
                produto.VetorTFIDF = TFIDF.CalcularTFIDF(tf, IDF);
            }
        }

        // metodo para buscar produtos utilizando similaridade vetorial
        public List<Produto> BuscarProdutosVetorial(string consulta)
        {
            var tokensConsulta = TextoHelper.AplicarStemming(
                TextoHelper.RemoverStopwords(
                    TextoHelper.Tokenizar(consulta))
                );
            var tfConsulta = TFIDF.CalcularTF(tokensConsulta);
            var vetorConsulta = TFIDF.CalcularTFIDF(tfConsulta, IDF);

            var resultados = new List<(Produto Produto, double Similaridade)>();

            // calcula a similaridade cosseno entre a consulta e os produtos
            foreach (var produto in Produtos)
            {
                double similaridade = CalcularSimilaridadeCosseno(vetorConsulta, produto.VetorTFIDF);
                resultados.Add((produto, similaridade));
            }

            // ordena os produtos pelo nivel de similaridade e retorna a lista ordenada
            return resultados
                .OrderByDescending(r => r.Similaridade)
                .Select(r => r.Produto)
                .ToList();
        }

        // metodo para calcular a similaridade cosseno entre dois vetores TF-IDF
        private double CalcularSimilaridadeCosseno(Dictionary<string, double> vetor1, Dictionary<string, double> vetor2)
        {
            var palavrasComuns = vetor1.Keys.Intersect(vetor2.Keys);
            double produtoEscalar = palavrasComuns.Sum(palavra => vetor1[palavra] * vetor2[palavra]);

            double norma1 = Math.Sqrt(vetor1.Values.Sum(v => v * v));
            double norma2 = Math.Sqrt(vetor2.Values.Sum(v => v * v));

            if (norma1 == 0 || norma2 == 0)
                return 0;

            return produtoEscalar / (norma1 * norma2);
        }

        // metodo para sugerir itens semelhantes a um produto de referencia
        public List<Produto> SugerirItensSemelhantes(Produto produtoReferencia, int quantidade = 3)
        {
            var resultados = new List<(Produto Produto, double Similaridade)>();

            foreach (var produto in Produtos)
            {
                if (produto == produtoReferencia) continue;

                double similaridade = CalcularSimilaridadeCosseno(produtoReferencia.VetorTFIDF, produto.VetorTFIDF);
                resultados.Add((produto, similaridade));
            }

            // ordena os produtos mais semelhantes e retorna os mais proximos
            return resultados
                .OrderByDescending(r => r.Similaridade)
                .Take(quantidade)
                .Select(r => r.Produto)
                .ToList();
        }
    }
}
