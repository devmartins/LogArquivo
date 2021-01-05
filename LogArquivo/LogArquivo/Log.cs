using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace LogArquivo
{
    public static class Log
    {
        private static readonly object obj = new object();
        private static string gerarLog = ConfigurationManager.AppSettings["GerarLog"];

        private static void GravarArquivo(string conteudo)
        {
            lock (obj)
            {
                File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}Log.txt", $"{DateTime.Now} - {conteudo}\r\n", Encoding.UTF8);
            }
        }

        private static string ExtrairConteudo(Exception ex)
        {
            string conteudo = "";
            if (ex.InnerException != null) conteudo += ExtrairConteudo(ex.InnerException);

            return $"{conteudo}{ex.Message}\r\n{ex.StackTrace}\r\n";
        }

        public static void Excecao(Exception ex)
        {
            if (gerarLog?.ToLower() != "true") return;

            var conteudo = ExtrairConteudo(ex);
            GravarArquivo(conteudo);
        }

        public static void Mensagem(string conteudo)
        {
            if (gerarLog?.ToLower() != "true") return;
            GravarArquivo($"{conteudo}\r\n");
        }

        public static void Erro(string conteudo) => Mensagem($"ERRO - {conteudo}");
        public static void Info(string conteudo) => Mensagem($"INFORMACAO - {conteudo}");
    }
}
