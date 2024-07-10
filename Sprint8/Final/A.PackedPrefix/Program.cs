﻿/*
https://contest.yandex.ru/contest/26133/run-report/115998437/
 */

/*
   -- ПРИНЦИП РАБОТЫ --

      
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
   
   
          
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
    
   
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class PacketFrefix
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        List<string> dataList = new();

        for (int i = 0; i < n; i++)
        {
            var str = reader.ReadLine();
            dataList.Add(str);
        }

        string res = FindMaxPrefix(dataList);

        writer.WriteLine(res);

        reader.Close();
        writer.Close();
    }

    private static string FindMaxPrefix(List<string> dataList)
    {
        if (dataList.Count == 0)
            return string.Empty;

        string prefix = UnpackString(dataList[0]);
        
        for (int i = 1; i < dataList.Count; i++)
        {
            var unpackStr = UnpackString(dataList[i]);

            var minLenght = Math.Min(prefix.Length, unpackStr.Length);
            int j;
            for (j = 0; j < minLenght; j++)
            {
                if (prefix[j] != unpackStr[j])
                    break;
            }

            prefix = unpackStr[Range.EndAt(j)];
        }

        return prefix;
    }

    
    private static string UnpackString(string packedStr)
    {
        var result = string.Empty;

        Stack<string> symbolStack = new ();
        
        foreach (var ch in packedStr)
        {
            switch (ch)
            {
                case ']':
                {
                    List<string> listStr = new();
                    //пришло завершение - надо разбирать стек
                    while (symbolStack.TryPop(out var symb))
                    {
                        if (symb == "[") 
                            break;
                        listStr.Add(symb);
                    }

                    listStr.Reverse();

                    var str = ListToString(listStr);

                    var count = Convert.ToInt32(symbolStack.Pop());

                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < count; i++)
                        sb.Append(str);

                    symbolStack.Push(sb.ToString());

                    break;
                }
                default: // [ &  digit
                    symbolStack.Push($"{ch}");
                    break;
            }
        }


        //разберём стек, не забыв перевернуть
        List<string> strList = new();
        while (symbolStack.TryPop(out var symb))
        {
            strList.Add(symb);
        }

        strList.Reverse();
        
        return ListToString(strList); ;
    }

    private static string ListToString(List<string> list)
    {
        StringBuilder sb = new ();
        foreach (var item in list)
        {
            sb.Append(item);
        }

        return sb.ToString();
    }


    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }


}

/*
2[1[emgu]]
emguemgu


 */