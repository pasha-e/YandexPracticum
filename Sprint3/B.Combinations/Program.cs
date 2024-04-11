using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class B
{
    private static TextReader reader;
    private static TextWriter writer;

    private static Dictionary<char, string> _phoneKeysMap = new Dictionary<char, string>()
    {
        {'2',"abc"},
        {'3',"def"},
        {'4',"ghi"},
        {'5',"jkl"},
        {'6',"mno"},
        {'7',"pqrs"},
        {'8',"tuv"},
        {'9',"wxyz"}
    };

    private static void GenerateCombinations(string inputKeys)
    {
        //var res = Combine(inputKeys, String.Empty);

        //writer.WriteLine(res);

        Combine2(inputKeys, String.Empty);
    }

    private static void Combine2(string input, string prefix)
    {
        if (String.IsNullOrEmpty(input))
        {
            writer.Write(prefix+" ");
        }
        else
        {
            foreach (var symbol in _phoneKeysMap[input[0]])
            {
                prefix += symbol;

                Combine2(input.Substring(1), prefix);

                prefix = prefix[..^1];
            }
        }

    }


    private static string Combine(string input, string path)
    {
        string result = String.Empty;

        if (String.IsNullOrEmpty(input))
        {
            //writer.WriteLine(path);
            path += " ";

            return path;
        }

        foreach (var key in _phoneKeysMap[input[0]])
        {
            path += key;

            result += Combine(input.Substring(1), path);
            
            path = path.Substring(0, path.Length - 1);
        }
        

        return result;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var list = reader.ReadLine();

        GenerateCombinations(list);

        reader.Close();
        writer.Close();
    }

}
