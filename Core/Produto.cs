using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Integrantes: Paulo Vinicius Ruffini Azevedo e Caio Corrêa Castro
namespace Sistema_Busca_Vetorial.Core
{
    public class Produto
    {
        // propriedades do produto, incluindo nome, descricao, tamanhos, preco e caminho da imagem
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TamanhosDisponiveis { get; set; }
        public decimal Preco { get; set; }
        public string CaminhoImagem { get; set; }

        // dicionario que armazena o vetor TF-IDF do produto, usado na busca vetorial
        public Dictionary<string, double> VetorTFIDF { get; set; }

        public Produto()
        {
            // inicializa o vetor TF-IDF como um dicionario vazio
            VetorTFIDF = new Dictionary<string, double>();
        }

        // metodo sobrescrito para exibir as informacoes do produto em formato de string
        public override string ToString()
        {
            return $"Nome: {Nome}\nDescrição: {Descricao}\nTamanhos disponíveis: {TamanhosDisponiveis}\nPreço: R$ {Preco:N2}\n";
        }
    }
}
