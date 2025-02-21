using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Integrantes: Paulo Vinicius Ruffini Azevedo e Caio Corrêa Castro
namespace Sistema_Busca_Vetorial.Core
{
    public class TFIDF
    {
        // calcula a frequência dos termos (tf) dentro de um documento
        public static Dictionary<string, double> CalcularTF(List<string> tokens)
        {
            var tf = new Dictionary<string, double>();
            // percorre cada token e conta sua ocorrência
            foreach (var token in tokens)
            {
                if (tf.ContainsKey(token))
                    tf[token]++;
                else
                    tf[token] = 1;
            }

            // normaliza os valores dividindo pela quantidade total de tokens no documento
            int totalTokens = tokens.Count;
            foreach (var key in tf.Keys.ToList())
            {
                tf[key] /= totalTokens;
            }

            return tf;
        }

        // calcula a frequência inversa do documento (idf), que mede a importância de cada termo
        public static Dictionary<string, double> CalcularIDF(List<List<string>> todosDocumentos)
        {
            var idf = new Dictionary<string, double>();
            int totalDocumentos = todosDocumentos.Count; // número total de documentos

            // percorre cada documento e conta em quantos deles um termo aparece
            foreach (var documento in todosDocumentos)
            {
                foreach (var token in documento.Distinct()) // distinct para contar apenas uma vez por documento
                {
                    if (idf.ContainsKey(token))
                        idf[token]++;
                    else
                        idf[token] = 1;
                }
            }
            // aplica a fórmula idf = log(total de documentos / quantidade de documentos que contêm o termo)
            foreach (var key in idf.Keys.ToList())
            {
                idf[key] = Math.Log((double)totalDocumentos / idf[key]);
            }

            return idf;
        }

        // calcula o tf-idf de cada termo multiplicando tf pelo idf correspondente
        public static Dictionary<string, double> CalcularTFIDF(Dictionary<string, double> tf, Dictionary<string, double> idf)
        {
            var tfidf = new Dictionary<string, double>();
            foreach (var key in tf.Keys)
            {
                if (idf.ContainsKey(key))
                    tfidf[key] = tf[key] * idf[key]; // tf-idf = tf * idf
                else
                    tfidf[key] = 0; // caso o termo não tenha idf, define como zero
            }
            return tfidf;
        }
    }
}

