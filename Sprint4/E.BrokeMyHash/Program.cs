using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;

public class E
{
    private static  int baseA = 1000;

    private static int M = 123987123;


    public static void Main(string[] args)
    {
        //Console.WriteLine( GetHash("ezhgeljkablzwnvuwqvp", baseA, M)); //47021983

        //Console.WriteLine(GetHash("gbpdcvkumyfxillgnqrv", baseA, M)); //47021983

        FindPair();

        string sampleStr = GeneratedString(20);

        FindPairForSample(sampleStr);
    }

    private static void FindPair()
    {
        Dictionary<long, string> map = new Dictionary<long, string>();

        while (true)
        {
            var rndStr = GeneratedString(20);

            var hash = GetHash(rndStr, baseA, M);

            if (!map.ContainsKey(hash))
                map[hash] = rndStr;
            else
            {
                Console.WriteLine($"{rndStr} {hash}");

                Console.WriteLine($"{map[hash]} {hash}");

                break;
            }
        }
    }

    private static void FindPairForSample(string sampleStr)
    {
        var sampleHash = GetHash(sampleStr, baseA, M);

        Console.WriteLine($"{sampleStr} {sampleHash}");

        while (true)
        {
            var rndStr = GeneratedString(20);

            var hash = GetHash(rndStr, baseA, M);

            //код чтобы найти пару к заданнйо строке
            if (hash == sampleHash)
            {
                Console.WriteLine($"{rndStr} {hash}");

                break;
            }
        }
    }

    private static long Modulus(long a, long b)
    {
        long c = (long)Math.Floor((double)a / b);

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

    private static long GetHash(string sourceStr, int p, int m)
    {
        long hash = 0;

        long powerP = 1;
        
        foreach (var symb in sourceStr.Reverse())
        {
            hash = Modulus((hash + (int)symb * powerP), m);
         
            powerP = Modulus((powerP * p), m);
        }
        
        return hash;
    }
}

/*
otxncefvcinkqouoptjr 21478529
ycmytcuimktyonqpomcx 21478529
   
ywsslnqhptxfqelevytp 43855951
eocggxrpiovrevyacbpb 43855951

kxwtgmokbphljmbsngtt - 93034647
ujwnrnskmatwsuyozzcq - 93034647

wxureghmwmdcqhrdbaja 103172680
ojeffxulmnitxkmnnwwi 103172680

habuyqscebynidcyupdv 56129649
yapxhulmppuytyhngmvt 56129649
 */