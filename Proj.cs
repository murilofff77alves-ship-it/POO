using System;
using System.Collections.Generic;

namespace BibliotecaPOO
{
    // =========================
    // MODELOS
    // =========================

    class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public string Editora { get; set; }
        public int Ano { get; set; }
        public bool Disponivel { get; set; } = true;
    }

    class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }

    class Emprestimo
    {
        public Livro Livro { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }

    // =========================
    // SERVIÇO
    // =========================

    class BibliotecaService
    {
        public List<Livro> Livros = new List<Livro>();
        public List<Cliente> Clientes = new List<Cliente>();
        public List<Emprestimo> Emprestimos = new List<Emprestimo>();

        public void CadastrarLivro()
        {
            Console.WriteLine("\n=== Cadastro de Livro ===");

            Livro livro = new Livro();

            Console.Write("eu nao sei: ");
            livro.Titulo = Console.ReadLine();

            Console.Write("eu: ");
            livro.Autor = Console.ReadLine();

            Console.Write("1212: ");
            livro.ISBN = Console.ReadLine();

            Console.Write("nois: ");
            livro.Editora = Console.ReadLine();

            Console.Write("203: ");
            int.TryParse(Console.ReadLine(), out int ano);
            livro.Ano = ano;

            Livros.Add(livro);
            Console.WriteLine($"Livro \"{livro.Titulo}\" cadastrado com sucesso!");
        }

        public void CadastrarCliente()
        {
            Console.WriteLine("\n=== Cadastro de Cliente ===");

            Cliente cliente = new Cliente();

            Console.Write("Nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("CPF: ");
            cliente.CPF = Console.ReadLine();

            Console.Write("Endereço: ");
            cliente.Endereco = Console.ReadLine();

            Console.Write("Telefone: ");
            cliente.Telefone = Console.ReadLine();

            Console.Write("Email: ");
            cliente.Email = Console.ReadLine();

            Clientes.Add(cliente);
            Console.WriteLine($"Cliente {cliente.Nome} cadastrado com sucesso!");
        }

        public void EmprestarLivro()
        {
            if (Livros.Count == 0 || Clientes.Count == 0)
            {
                Console.WriteLine("Cadastre livros e clientes primeiro.");
                return;
            }

            Console.WriteLine("\n=== Livros ===");
            for (int i = 0; i < Livros.Count; i++)
            {
                Console.WriteLine($"{i} - {Livros[i].Titulo} ({(Livros[i].Disponivel ? "Disponível" : "Emprestado")})");
            }

            Console.Write("Escolha o livro: ");
            if (!int.TryParse(Console.ReadLine(), out int livroIndex) || livroIndex < 0 || livroIndex >= Livros.Count)
            {
                Console.WriteLine("Livro inválido.");
                return;
            }

            Livro livro = Livros[livroIndex];

            if (!livro.Disponivel)
            {
                Console.WriteLine("Livro já emprestado.");
                return;
            }

            Console.WriteLine("\n=== Clientes ===");
            for (int i = 0; i < Clientes.Count; i++)
            {
                Console.WriteLine($"{i} - {Clientes[i].Nome}");
            }

            Console.Write("Escolha o cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int clienteIndex) || clienteIndex < 0 || clienteIndex >= Clientes.Count)
            {
                Console.WriteLine("Cliente inválido.");
                return;
            }

            Cliente cliente = Clientes[clienteIndex];

            livro.Disponivel = false;

            Emprestimos.Add(new Emprestimo
            {
                Livro = livro,
                Cliente = cliente,
                DataEmprestimo = DateTime.Now,
                DataPrevistaDevolucao = DateTime.Now.AddDays(7)
            });

            Console.WriteLine($"Livro \"{livro.Titulo}\" emprestado para {cliente.Nome}.");
        }

        public void DevolverLivro()
        {
            if (Emprestimos.Count == 0)
            {
                Console.WriteLine("Não há empréstimos.");
                return;
            }

            Console.WriteLine("\n=== Empréstimos ===");
            for (int i = 0; i < Emprestimos.Count; i++)
            {
                Console.WriteLine($"{i} - {Emprestimos[i].Livro.Titulo} / {Emprestimos[i].Cliente.Nome}");
            }

            Console.Write("Escolha o empréstimo: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= Emprestimos.Count)
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            Emprestimo e = Emprestimos[index];
            e.DataDevolucao = DateTime.Now;
            e.Livro.Disponivel = true;

            double multa = CalcularMulta(e);

            Console.WriteLine($"Livro devolvido. Multa: R$ {multa:F2}");
            Emprestimos.Remove(e);
        }

        public double CalcularMulta(Emprestimo e)
        {
            if (e.DataDevolucao > e.DataPrevistaDevolucao)
            {
                int dias = (e.DataDevolucao.Value - e.DataPrevistaDevolucao).Days;
                return dias * 2.0;
            }
            return 0;
        }
    }

    // =========================
    // PROGRAMA PRINCIPAL
    // =========================

    class Program
    {
        static void Main()
        {
            BibliotecaService biblioteca = new BibliotecaService();
            int opcao = -1;

            do
            {
                Console.WriteLine("\n=== SISTEMA DE BIBLIOTECA ===");
                Console.WriteLine("1 - Cadastrar Livro");
                Console.WriteLine("2 - Cadastrar Cliente");
                Console.WriteLine("3 - Emprestar Livro");
                Console.WriteLine("4 - Devolver Livro");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Digite um número válido.");
                    continue;
                }

                switch (opcao)
                {
                    case 1: biblioteca.CadastrarLivro(); break;
                    case 2: biblioteca.CadastrarCliente(); break;
                    case 3: biblioteca.EmprestarLivro(); break;
                    case 4: biblioteca.DevolverLivro(); break;
                    case 0: Console.WriteLine("Sistema finalizado."); break;
                    default: Console.WriteLine("Opção inválida."); break;
                }

            } while (opcao != 0);
        }
    }
}
