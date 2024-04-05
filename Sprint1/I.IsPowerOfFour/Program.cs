using System;
using System.IO;

public class I
{
    private static TextReader reader;
    private static TextWriter writer;

    private const int ChekingDigit = 4;

    private static bool IsPowerOfFour(int n)
    {
        var currentDigit = n;

        while (currentDigit >= ChekingDigit)
        {
            if (currentDigit % ChekingDigit == 0)
            {
                currentDigit /= ChekingDigit;
            }
            else
            {
                return false;
            }
        }

        return currentDigit == 1 ;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();
        if (IsPowerOfFour(n))
        {
            writer.WriteLine("True");
        }
        else
        {
            writer.WriteLine("False");
        }

        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}