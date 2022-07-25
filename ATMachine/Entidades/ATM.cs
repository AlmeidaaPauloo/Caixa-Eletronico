using ATMachine.Entidades.Cedulas;
using ATMachine.Servicos;
using System;
using System.Collections.Generic;
using System.Text;


namespace ATMachine.Entidades
{
    internal class ATM
    {
        public int valorDisponivel = 0;
        public int EntregarNotasDe10 = 0;
        public int EntregarNotasDe20 = 0;
        public int EntregarNotasDe50 = 0;
        public int EntregarNotasDe100 = 0;

        NotaDe10 nota10 = new NotaDe10();
        NotaDe20 nota20 = new NotaDe20();
        NotaDe50 nota50 = new NotaDe50();
        NotaDe100 nota100 = new NotaDe100();

        public void AtualizarValorDisponível()
        {
            valorDisponivel = nota10.Valor * nota10.quantidade + nota20.Valor * nota20.quantidade + nota50.Valor * nota50.quantidade + nota100.Valor * nota100.quantidade;

        }
        public void Saque(int valorDeSaque)
        {
            AtualizarValorDisponível();
            int restante = valorDeSaque;

            if (valorDeSaque <= valorDisponivel)
            {
                while (restante != 0)
                {
                    if (restante >= 100 && nota100.quantidade > 0)
                    {
                        nota100.quantidade -= 1;
                        restante -= 100;
                        EntregarNotasDe100++;
                    }
                    else if (restante >= 50 && nota50.quantidade > 0)
                    {
                        nota50.quantidade -= 1;
                        restante -= 50;
                        EntregarNotasDe50++;
                    }
                    else if (restante >= 20 && nota20.quantidade > 0)
                    {
                        nota20.quantidade -= 1;
                        restante -= 20;
                        EntregarNotasDe20++;
                    }
                    else if (restante >= 10 && nota10.quantidade > 0)
                    {
                        nota10.quantidade -= 1;
                        restante -= 10;
                        EntregarNotasDe10++;
                    }
                    else
                    {
                        Console.WriteLine("Valor Invalido");
                    }
                }

                PrintService print = new PrintService();
                print.PrintNotas(EntregarNotasDe100, EntregarNotasDe50, EntregarNotasDe20, EntregarNotasDe10);
            }

            else
            {
                Console.WriteLine("Valor indisponivel para saque no momento");
            }
            
        }
    }
}
