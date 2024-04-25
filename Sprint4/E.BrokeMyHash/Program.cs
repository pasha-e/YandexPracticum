using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

public class L
{
    private static TextReader reader;
    private static TextWriter writer;

    private static  int baseA = 1000;

    private static int M = 123987123;


    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        /*writer.WriteLine( GeneratedString(20) );
        writer.WriteLine(GeneratedString(20));
        writer.WriteLine(GeneratedString(20));
        writer.WriteLine(GeneratedString(20));
        writer.WriteLine(GeneratedString(20));*/

        writer.WriteLine( GetHash("ezhgeljkablzwnvuwqvp", baseA, M));

        writer.WriteLine(GetHash("gbpdcvkumyfxillgnqrv", baseA, M));

        writer.WriteLine(-13 % 5);
        writer.WriteLine(Math.IEEERemainder((double)-13, (double)5));

        writer.WriteLine(13 % 5);
        writer.WriteLine(Math.IEEERemainder((double)13, (double)5));

        writer.WriteLine(13 / 5);
        writer.WriteLine(-13 / 5);


        writer.WriteLine(Math.Floor( (double)-13/5));

        writer.WriteLine(Modulus(-13, 5));
        writer.WriteLine(Modulus(13, 5));
        writer.WriteLine(Modulus(118, 5));

        reader.Close();
        writer.Close();
    }

    private static int Modulus(int a, int b)
    {
        int c = (int)Math.Floor((double)a / b);

        return a -  c * b ;
    }

    private static string GeneratedString(int lenght)
    {
        string result = string.Empty;

        Random rnd = new Random();

        for (int i = 0; i < lenght; i++)
        {
            char a = (char)rnd.Next(0x0061, 0x007A);
            result += a;
        }

        return result; 
    }

    private static int GetHash(string sourceStr, int p, int m)
    {
        int hash = 0;

        int powerP = 1;
        /*
        foreach (var symb in sourceStr)
        {
            //hash =  ( hash +  (int)symb * powerP) % m;

            //hash = (int) Math.IEEERemainder((hash + (int)symb * powerP) ,  m);

            //hash = Modulus((hash + (int)symb * powerP), m);
            hash = (hash + (int)symb * powerP);


            powerP = (powerP * p);
            //powerP = (int) Math.IEEERemainder((powerP * p) , m);
            //powerP = Modulus((powerP * p), m);
        }
        */
        for (int i = sourceStr.Length - 1; i >= 0; i--)
        {
            char symb = sourceStr[i];

            hash = hash + symb  * powerP;

            powerP = p * powerP;
        }

        hash = Modulus(hash, m);

        return hash;
    }
}
