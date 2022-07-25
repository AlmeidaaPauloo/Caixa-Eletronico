using System;
using ATMachine.Entidades;
using ATMachine.Servicos;


namespace ATMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATM Caixa24hrs = new ATM();
            PrintService print = new PrintService();

            Console.WriteLine("Bem vindo ao Banco Digital!\n" +
                "Digite o valor para saque:");
            int valorDeSaque = int.Parse(Console.ReadLine());

            Caixa24hrs.Saque(valorDeSaque);
        }
    }
}
