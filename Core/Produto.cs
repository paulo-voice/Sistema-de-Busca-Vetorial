using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Busca_Vetorial.Core
{
    public class Produto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TamanhosDisponiveis { get; set; }
        public decimal Preco { get; set; }
        public Dictionary<string, double> VetorTFIDF { get; set; }

        public Produto()
        {
            VetorTFIDF = new Dictionary<string, double>();
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\nDescrição: {Descricao}\nTamanhos disponíveis: {TamanhosDisponiveis}\nPreço: R$ {Preco:N2}\n";
        }
    }
}
