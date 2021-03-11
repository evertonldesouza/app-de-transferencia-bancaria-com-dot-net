using DIO.AppBank.Model;
using DIO.AppBank.Model.Enum;
using System;
using System.Collections.Generic;

namespace DIO.AppBank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar os nossos serviços");
            Console.ReadLine();

        }

        private static void ListarContas()
        {
            Console.WriteLine("--- Listar contas ---");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta foi cadrastada.");
                return; //para sair sem retornar nada
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.WriteLine($"#{i + 1} - {conta}");
            }
        }

        private static void InserirContas()
        {
            Console.WriteLine("--- Inserir nova conta ---");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            //cria um novo objeto da classe conta
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            //adiciona a lista de contas
            listaContas.Add(novaConta);
        }

        private static void Transferir()
        {
            Console.WriteLine("--- Transferir ---");

            Console.Write("Digite o Numero da conta: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o Numero da conta destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valor = double.Parse(Console.ReadLine());



            listaContas[indiceContaOrigem - 1].Transferir(valor, listaContas[indiceContaDestino - 1]);
        }

        private static void Sacar()
        {
            Console.WriteLine("--- Sacar ---");

            Console.Write("Digite o Numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valor = double.Parse(Console.ReadLine());

            listaContas[indiceConta - 1].Sacar(valor);
        }

        private static void Depositar()
        {
            Console.WriteLine("--- Depositar ---");

            Console.Write("Digite o Nome do cliente: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());

            listaContas[indiceConta - 1].Depositar(valor);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
