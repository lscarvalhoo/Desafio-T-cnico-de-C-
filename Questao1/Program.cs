using System;
using System.Globalization;

namespace Questao1
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaBancaria conta;

            Console.Write("Entre o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Entre o titular da conta: ");
            string titular = Console.ReadLine();

            Console.Write("Haverá depósito inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine().ToUpper());

            if (resp == 'S')
            {
                Console.Write("Entre o valor de depósito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new ContaBancaria(numero, titular, depositoInicial);
            }
            else
            {
                conta = new ContaBancaria(numero, titular);
            }
            ExibirDadosConta(conta);

            int opcao;
            do
            {
                Console.WriteLine();
                Console.WriteLine("  ---------- MENU ----------- "); 
                Console.WriteLine(" |      1 - Deposito         |");
                Console.WriteLine(" |        2 - Saque          |");
                Console.WriteLine(" |  3 - Alterar Nome Titular |");
                Console.WriteLine(" | 4 - Exibir Dados da Conta |");
                Console.WriteLine(" |        0 - Sair           |");
                Console.WriteLine("  --------------------------- ");
                Console.Write("Escolha uma opção: ");
                Console.WriteLine(); 
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Deposito(conta);
                        break;
                    case 2:
                        Saque(conta);
                        break;
                    case 3:
                        AlterarNomeTitular(conta);
                        break;
                    case 4:
                        ExibirDadosConta(conta);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 0);
        }

        private static void AlterarNomeTitular(ContaBancaria conta)
        {
            Console.WriteLine();
            Console.Write("Digite o novo nome do titular: ");
            string novoNome = Console.ReadLine();
            conta.AlterarNome(novoNome);
            ExibirDadosConta(conta);
        }

        private static void Saque(ContaBancaria conta)
        {
            Console.WriteLine();
            Console.Write("Entre um valor para saque: ");
            double quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Saque(quantia);
            ExibirDadosConta(conta);
        }

        private static void Deposito(ContaBancaria conta)
        {
            Console.WriteLine();
            Console.Write("Entre um valor para depósito: ");
            double quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Deposito(quantia);
            Console.WriteLine();
            ExibirDadosConta(conta);
        }

        private static void ExibirDadosConta(ContaBancaria conta)
        {  
            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine($"Conta {conta.Numero}, Titular: {conta.Titular}, Saldo: $ {conta.Saldo}"); 
            Console.WriteLine();
        }
    }
}
