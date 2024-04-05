using System;
using System.IO;
using System.Collections.Generic;
public class H
{
    private static TextReader reader;
    private static TextWriter writer;

    private static bool IsCorrectBracketSeq(string bracketsSeq)
    {
        Stack stack = new Stack();

        string openingBrackets = "[{(";
        string closingBrackets = "]})";


        foreach (char bracket in bracketsSeq)
        {
            if (openingBrackets.Contains(bracket))
            {
                stack.Push(bracket);
                continue;
            }

            if (closingBrackets.Contains(bracket))
            {
                if (stack.Size() == 0)
                    return false;
                    
                var symbol = stack.Pop();

                if ((bracket == ')' && symbol == '(') ||
                    (bracket == ']' && symbol == '[') ||
                    (bracket == '}' && symbol == '{'))
                    continue;

                return false;
            }
        }

        if(stack.Size() > 0)
            return false;

        return true;
    }



    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var text = reader.ReadLine();

        if (IsCorrectBracketSeq(text))
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

class Stack
{
    private List<char> items;

    public Stack()
    {
        items = new List<char>();
    }

    public void Push(char item)
    {
        items.Add(item);
    }

    public char Pop()
    {
        char lastItem = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return lastItem;
    }

    public char Peek()
    {
        return items[items.Count - 1];
    }

    public int Size()
    {
        return items.Count;
    }
}