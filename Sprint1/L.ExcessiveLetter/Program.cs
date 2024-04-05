using System;
using System.IO;
using System.Collections.Generic;

public class L
{
    private static TextReader reader;
    private static TextWriter writer;

    private static char GetExcessiveLetter(string shorter, string longer)
    {
        Dictionary<char, int> symbolLongerDictionary = new Dictionary<char, int>();
        Dictionary<char, int> symbolShorterDictionary = new Dictionary<char, int>();

        foreach (var symbol in shorter)
        {
            if (!symbolShorterDictionary.ContainsKey(symbol))
                symbolShorterDictionary[symbol] = 1;
            else
            {
                symbolShorterDictionary[symbol] += 1;
            }
        }

        foreach (var symbol in longer)
        {
            if(!symbolLongerDictionary.ContainsKey(symbol))
                symbolLongerDictionary[symbol] = 1;
            else
            {
                symbolLongerDictionary[symbol] += 1;
            }
        }

        foreach (var pair in symbolLongerDictionary)
        {
            if(symbolShorterDictionary.ContainsKey(pair.Key) &&
               symbolShorterDictionary[pair.Key] == pair.Value)
                continue;

            return pair.Key;
        }


        return ' ';
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var shorter = reader.ReadLine();
        var longer = reader.ReadLine();
        writer.WriteLine(GetExcessiveLetter(shorter, longer));

        reader.Close();
        writer.Close();
    }
}