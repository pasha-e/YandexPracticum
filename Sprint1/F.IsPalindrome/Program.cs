using System;
using System.IO;
using System.Text.RegularExpressions;

public class F
{
    private static TextReader reader;
    private static TextWriter writer;

    private static bool IsPalindrome(string text)
    {
        if(String.IsNullOrWhiteSpace(text))
            return false;

        var processingText = text.ToLower();
        
        processingText = Regex.Replace(processingText, "[^A-Za-zА-Яа-я0-9]", "");

        var length = processingText.Length;

        for (int i = 0; i < length / 2; i++)
        {
            if (processingText[i] == processingText[length - 1 - i])
                continue;

            return false;
        }
        
        return true;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var text = reader.ReadLine();

        if (IsPalindrome(text))
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
}