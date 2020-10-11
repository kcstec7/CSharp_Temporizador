/*
    Karla Santos
    Exercício baseado no cronômetro do curso "Fundamentos do C#" (balta.io),
    com melhorias aplicadas para melhor apresentação do código e funcionamento
    10/10/2020
*/

using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundos => 10s = 10 segundos");
            Console.WriteLine("M = Minutos  =>  1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");

            string valorInformado = Console.ReadLine().ToLower();

            if (valorInformado.Length == 1)
            {
                if (valorInformado.Equals("0"))
                    System.Environment.Exit(0);
                else
                {
                    OpcaoInvalida();
                }
            }
            else
            {
                // Importante: Está sendo subtraída uma unidade, porque as posições
                // começam com 0 e a quantidade de caracteres começa com 1
                char tipo = char.Parse(valorInformado.Substring(valorInformado.Length - 1, 1));

                if (tipo != 's' && tipo != 'm')
                {
                    OpcaoInvalida();
                }

                int tempo = 0;

                try
                {
                    tempo = int.Parse(valorInformado.Substring(0, valorInformado.Length - 1));
                }
                catch (SystemException erro)
                {
                    Console.WriteLine("Caiu no catch");
                    OpcaoInvalida($"Falha ao converter o tempo informado: '{erro.Message}'");
                }

                int multiplicador = 1;

                if (tipo == 'm')
                    multiplicador = 60;

                PreStart(tempo * multiplicador);
            }
        }

        static void OpcaoInvalida(string mensagem = "Opção inválida!")
        {
            Console.WriteLine(mensagem);
            Thread.Sleep(2000);
            Menu();
        }

        static void PreStart(int tempo)
        {
            Console.Clear();
            Console.WriteLine("Preparar...");
            Thread.Sleep(1000);
            Console.WriteLine("Apontar...");
            Thread.Sleep(1000);
            Console.WriteLine("Começar!");
            Thread.Sleep(1500);

            Start(tempo);
        }
        static void Start(int totalSegundos)
        {
            int segundoAtual = totalSegundos;

            while (segundoAtual > 0)
            {
                Console.Clear();
                Console.WriteLine(segundoAtual);
                segundoAtual--;

                Thread.Sleep(1000); // Dormir por um segundo
            }

            Console.Clear();
            Console.WriteLine("Cronômetro finalizado");
            Thread.Sleep(1500);

            Menu();
        }
    }
}
