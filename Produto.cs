using System;

namespace SistemaLojaBusca
{
    public class Produto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TamanhosDisponiveis { get; set; }
        public decimal Preco { get; set; }
        public Dictionary<string, double> VetorTFIDF { get; set; } // Novo campo

        public override string ToString()
        {
            return $"Nome: {Nome}\nDescrição: {Descricao}\nTamanhos disponíveis: {TamanhosDisponiveis}\nPreço: R$ {Preco:N2}\n";
        }
    }
}