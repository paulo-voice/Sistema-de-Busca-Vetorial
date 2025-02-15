using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SistemaLojaBusca
{
    public class Loja
    {
        public List<Produto> Produtos { get; private set; }
        private Dictionary<string, double> IDF { get; set; }

        public Loja(string caminhoArquivo)
        {
            Produtos = new List<Produto>();
            CarregarProdutos(caminhoArquivo);
            CalcularVetoresTFIDF();
        }

        private void CarregarProdutos(string caminhoArquivo)
        {
            string[] linhas = File.ReadAllLines(caminhoArquivo);
            Produto produtoAtual = null;

            foreach (string linha in linhas)
            {
                if (linha.StartsWith("Nome:"))
                {
                    produtoAtual = new Produto();
                    produtoAtual.Nome = linha.Substring("Nome: ".Length);
                }
                else if (linha.StartsWith("Descrição:"))
                {
                    produtoAtual.Descricao = linha.Substring("Descrição: ".Length);
                }
                else if (linha.StartsWith("Tamanhos disponíveis:"))
                {
                    produtoAtual.TamanhosDisponiveis = linha.Substring("Tamanhos disponíveis: ".Length);
                }
                else if (linha.StartsWith("Preço:"))
                {
                    string precoStr = linha.Substring("Preço: R$ ".Length);
                    produtoAtual.Preco = decimal.Parse(precoStr);
                    Produtos.Add(produtoAtual);
                }
            }
        }

        private void CalcularVetoresTFIDF()
        {
            var todosDocumentos = Produtos
                .Select(p => TextoHelper.AplicarStemming(
                    TextoHelper.RemoverStopwords(
                        TextoHelper.Tokenizar(p.Nome + " " + p.Descricao)
                    )
                ))
                .ToList();

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

        public List<Produto> BuscarProdutosVetorial(string consulta)
        {
            var tokensConsulta = TextoHelper.AplicarStemming(
                TextoHelper.RemoverStopwords(
                    TextoHelper.Tokenizar(consulta))
                );
            var tfConsulta = TFIDF.CalcularTF(tokensConsulta);
            var vetorConsulta = TFIDF.CalcularTFIDF(tfConsulta, IDF);

            var resultados = new List<(Produto Produto, double Similaridade)>();

            foreach (var produto in Produtos)
            {
                double similaridade = CalcularSimilaridadeCosseno(vetorConsulta, produto.VetorTFIDF);
                resultados.Add((produto, similaridade));
            }

            return resultados
                .OrderByDescending(r => r.Similaridade)
                .Select(r => r.Produto)
                .ToList();
        }

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

        public List<Produto> SugerirItensSemelhantes(Produto produtoReferencia, int quantidade = 3)
        {
            var resultados = new List<(Produto Produto, double Similaridade)>();

            foreach (var produto in Produtos)
            {
                if (produto == produtoReferencia) continue;

                double similaridade = CalcularSimilaridadeCosseno(produtoReferencia.VetorTFIDF, produto.VetorTFIDF);
                resultados.Add((produto, similaridade));
            }

            return resultados
                .OrderByDescending(r => r.Similaridade)
                .Take(quantidade)
                .Select(r => r.Produto)
                .ToList();
        }

        public void ListarProdutos()
        {
            foreach (var produto in Produtos)
            {
                Console.WriteLine(produto);
            }
        }
    }
}