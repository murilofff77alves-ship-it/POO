using System;
using System.IO; // Necessário para manipulação de arquivos 

namespace Aula6_Arquivos
{
    public static class Logger
    {
        private static string arquivoLog = "sistema_log.txt";

        public static void RegistrarAcao(string acao)
        {
            // 'using' garante que o arquivo seja fechado após o uso
            // AppendText cria o arquivo se não existir, ou adiciona ao final 
            using (StreamWriter sw = File.AppendText(arquivoLog))
            {
                sw.WriteLine($"{DateTime.Now} - {acao}");
            }
            Console.WriteLine("Log salvo no disco.");
        }

        public static void LerLogs()
        {
            Console.WriteLine("\n--- LENDO HISTÓRICO DE LOGS ---");
            if (File.Exists(arquivoLog)) // 
            {
                // OpenText abre para leitura 
                using (StreamReader sr = File.OpenText(arquivoLog))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(linha);
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhum log encontrado.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. O programa executa e salva dados
            Logger.RegistrarAcao("Sistema inicializado.");
            Logger.RegistrarAcao("Usuário 'admin' logou.");
            Logger.RegistrarAcao("Erro de conexão simulado.");

            // 2. O programa lê o que está salvo no arquivo .txt
            Logger.LerLogs();

            Console.WriteLine("\nVerifique a pasta do executável para encontrar 'sistema_log.txt'");
            Console.ReadKey();
        }
    }
}
