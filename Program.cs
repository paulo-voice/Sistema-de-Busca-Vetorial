using System;
using System.Collections.Generic;

namespace SistemaLojaBusca
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminhoArquivo = "produtos.txt";

            Loja loja = new Loja(caminhoArquivo);

            Console.WriteLine("=== Sistema de Busca de Loja ===");
            Console.WriteLine("Produtos carregados com sucesso!\n");

            Console.WriteLine("Listando todos os produtos:");
            loja.ListarProdutos();

            Console.WriteLine("\nDigite um termo para buscar:");
            string termoBusca = Console.ReadLine();

            var resultadosBusca = loja.BuscarProdutosVetorial(termoBusca);

            if (resultadosBusca.Any())
            {
                Console.WriteLine("\nResultados da busca:");
                foreach (var produto in resultadosBusca)
                {
                    Console.WriteLine(produto);
                }
            }
            else
            {
                Console.WriteLine("\nNenhum produto encontrado.");
            }

            if (resultadosBusca.Any())
            {
                Console.WriteLine("\nDeseja ver sugestões de itens semelhantes ao primeiro resultado? (S/N)");
                string resposta = Console.ReadLine();

                if (resposta.ToLower() == "s")
                {
                    var produtoReferencia = resultadosBusca.First();
                    var sugestoes = loja.SugerirItensSemelhantes(produtoReferencia);

                    if (sugestoes.Any())
                    {
                        Console.WriteLine("\nSugestões de itens semelhantes:");
                        foreach (var sugestao in sugestoes)
                        {
                            Console.WriteLine(sugestao);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNenhuma sugestão disponível.");
                    }
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}