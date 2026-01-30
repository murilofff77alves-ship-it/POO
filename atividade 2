using System;

namespace AtividadeAula2
{
    // A classe representa a estrutura do objeto 
    public class ContaBancaria
    {
        // PROPRIEDADES (Encapsulamento) 
        // 'private set' impede que classes externas alterem o valor diretamente.
        public string NumeroDaConta { get; private set; }
        public string Titular { get; private set; }
        public double Saldo { get; private set; }

        // CONSTRUTOR 
        //Obriga quem criar a conta a informar número e titular imediatamente.
        public ContaBancaria(string numero, string titular)
        {
            this.NumeroDaConta = numero;
            this.Titular = titular;
            this.Saldo = 0.0; // Conta começa zerada
        }

        //MÉTODOS (Comportamentos) 
        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine($"[SUCESSO] Depósito de R$ {valor:F2} realizado na conta de {Titular}.");
            }
            else
            {
                Console.WriteLine("[ERRO] O valor do depósito deve ser positivo.");
            }
        }

        public void Sacar(double valor)
        {
            //Validação de regra de negócio antes de alterar o atributo
            if (valor > 0 && Saldo >= valor)
            {
                Saldo -= valor;
                Console.WriteLine($"[SUCESSO] Saque de R$ {valor:F2} realizado.");
            }
            else
            {
                Console.WriteLine($"[ERRO] Saque de R$ {valor:F2} negado. Saldo insuficiente ou valor inválido.");
            }
        }

        public void ExibirExtrato()
        {
            Console.WriteLine($"--- Extrato: {Titular} (Conta: {NumeroDaConta}) ---");
            Console.WriteLine($"Saldo Atual: R$ {Saldo:F2}");
            Console.WriteLine("------------------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== INICIANDO SISTEMA BANCÁRIO (AULA 2) ===\n");

            // 1. Criando a conta (Construtor é chamado aqui)
            ContaBancaria minhaConta = new ContaBancaria("45612-3", "Cefras Mandu");

            // 2. Tentando acessar o saldo inicial
            minhaConta.ExibirExtrato();

            // 3. Realizando operações
            minhaConta.Depositar(500.00);
            minhaConta.Sacar(200.00);
            minhaConta.ExibirExtrato();

            // 4. Testando a proteção (Encapsulamento)
            Console.WriteLine("Tentando sacar valor maior que o saldo...");
            minhaConta.Sacar(1000.00); //Deve dar erro de saldo insuficiente

            // TENTATIVA DE VIOLAÇÃO (Se você descomentar a linha abaixo, o código NÃO compila)
            //minhaConta.Saldo = 1000000.00;
            minhaConta.ExibirExtrato();
            // Erro: O set accessor é inacessível (private)

            Console.WriteLine("\nPressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}
