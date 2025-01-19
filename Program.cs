using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Escolha uma questão (1 a 5):");
        int escolha = int.Parse(Console.ReadLine());

        switch (escolha)
        {
            case 1:
                Questao1();
                break;
            case 2:
                Questao2();
                break;
            case 3:
                Questao3();
                break;
            case 4:
                Questao4();
                break;
            case 5:
                Questao5();
                break;
            default:
                Console.WriteLine("Escolha inválida.");
                break;
        }
    }

    static void Questao1()
    {
        int INDICE = 13, SOMA = 0, K = 0;
        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
        }
        Console.WriteLine(SOMA);
    }

    static void Questao2()
    {
        Console.WriteLine("Informe um número:");
        int numero = int.Parse(Console.ReadLine());
        if (PertenceFibonacci(numero))
        {
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"O número {numero} não pertence à sequência de Fibonacci.");
        }
    }

    static bool PertenceFibonacci(int numero)
    {
        int a = 0;
        int b = 1;
        while (a < numero)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        return a == numero;
    }

    static void Questao3()
    {
        string path = "faturamento.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var faturamentoDiario = JsonSerializer.Deserialize<Dictionary<string, double>>(json);

            var valores = faturamentoDiario.Values.Where(v => v > 0).ToList();
            double menorValor = valores.Min();
            double maiorValor = valores.Max();
            double mediaMensal = valores.Average();
            int diasAcimaDaMedia = valores.Count(v => v > mediaMensal);

            Console.WriteLine($"Menor valor: {menorValor}");
            Console.WriteLine($"Maior valor: {maiorValor}");
            Console.WriteLine($"Dias acima da média: {diasAcimaDaMedia}");
        }
        else
        {
            Console.WriteLine("Arquivo faturamento.json não encontrado.");
        }
    }

    static void Questao4()
    {
        string path = "faturamento.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var faturamentoMensal = JsonSerializer.Deserialize<Dictionary<string, double>>(json);

            double total = faturamentoMensal.Values.Sum();

            foreach (var estado in faturamentoMensal)
            {
                Console.WriteLine($"{estado.Key}: {estado.Value / total * 100:F2}%");
            }
        }
        else
        {
            Console.WriteLine("Arquivo faturamento.json não encontrado.");
        }
    }

    static void Questao5()
    {
        Console.WriteLine("Informe uma string:");
        string str = Console.ReadLine();
        char[] charArray = str.ToCharArray();
        string invertedStr = "";
        for (int i = charArray.Length - 1; i >= 0; i--)
        {
            invertedStr += charArray[i];
        }
        Console.WriteLine(invertedStr);
    }
}
