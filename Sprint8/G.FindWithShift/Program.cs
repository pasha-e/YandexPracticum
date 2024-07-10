using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class G
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        
        var n = ReadInt();

        var dataList = ReadList();

        var m = ReadInt();

        var templateList = ReadList();

        var res = CheckDataToTemplate(dataList, templateList);

        foreach( var item in res )
            writer.Write($"{item+1} ");

        reader.Close();
        writer.Close();
    }

    private static List<int> CheckDataToTemplate(List<int> dataList, List<int> templateList)
    {
        List<int> res = FindAll(dataList, templateList);        

        return res;
    }


    private static int Find(List<int>  data, List<int> pattern, int start = 0)
    {
        if (data.Count < pattern.Count)
        {
            return -1; // Длинный шаблон не может содержаться в короткой строке.
        }
        for (int pos = start; pos <= data.Count - pattern.Count; pos++)
        {
            // Проверяем, не совпадёт ли шаблон, сдвинутый на позицию pos,
            // с соответствующим участком строки.
            bool match = true;

            int delta = data[pos] - pattern[0];

            for (int offset = 0; offset < pattern.Count; offset++)
            {
                if (data[pos + offset] - delta != pattern[offset])
                {
                    // Одного несовпадения достаточно, чтобы не проверять
                    // дальше текущее расположение шаблона.
                    match = false;
                    break;
                }
            }
            // Как только нашлось совпадение шаблона, возвращаем его.
            // Это первое вхождение шаблона в строку.
            if (match == true)
            {
                return pos;
            }
            // Если совпадение не нашлось, цикл перейдёт к проверке следующей позиции.
        }
        // Числом -1 часто маркируют, что подстрока не была найдена,
        // поскольку в строке нет позиции -1.
        // В качестве альтернативы можно возвращать null.
        return -1;
    }

    private static List<int> FindAll(List<int> data, List<int> pattern)
    {
        List<int> occurrences = new List<int>();
        int start = 0; // Начнём поиск с начала строки.
        // Найдём первое вхождение, если оно есть.
        int pos;
        while ((pos = Find(data, pattern, start)) != -1)
        {
            occurrences.Add(pos); // Сохраним вхождение в список.
            start = pos + 1;      // И продолжим поиск, начиная с позиции, 
            // следующей за только что найденной.
        }
        return occurrences;
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }

    private static List<int> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }
}

/*

9
3 9 1 2 5 10 9 1 7
2
4 10

1 8



5
1 2 3 4 5
3
10 11 12

1 2 3
 */