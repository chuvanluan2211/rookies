using System;

namespace PrimeNumber;

public class Program
{
    static async Task GetPrimeNum(int min, int max)
    {
        await Task.Run(() =>
        {
            for (int i = min; i <= max; i++)
            {
                if (CheckPrime(i) == true)
                {
                    System.Console.WriteLine(" " + i);
                }
            }
        }
        );

    }

    static bool CheckPrime(int num)
    {
        int count = 0;

        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
            {
                count++;
            }
        }

        if (count == 2)
        {
            return true;
        }
        
        else
        {
            return false;
        }

    }

    public static void Main(string[] args)
    {
        GetPrimeNum(0, 100);

        GetPrimeNum(100, 200);

        Console.ReadKey();
    }
}