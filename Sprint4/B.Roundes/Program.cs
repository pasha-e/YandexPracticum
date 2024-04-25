using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class B
{
    private static TextReader reader;
    private static TextWriter writer;

    private static int CalculateMaxRanges(List<int> roundsData)
    {
        Dictionary<int, int> balanseIndexes = new Dictionary<int, int>();

        balanseIndexes[0] = -1;

        var balanseCounter = 0;

        var max_length = 0;
        //var max_index = -1;


        for (int i = 0; i < roundsData.Count; i++) 
        {
            if (roundsData[i] == 1)
            {
                balanseCounter++;                
            }
            else 
            {
                balanseCounter--;
            }

            //если такого баланса ещё не было - запомним
            if (!balanseIndexes.ContainsKey(balanseCounter))
            {
                balanseIndexes[balanseCounter] = i;
                continue;
            }
            
            //а вот если был - то типа логично что между этими позициями баланс не изменился - значи тут у нас общаяя ниччья            
            var length = i - balanseIndexes[balanseCounter];

            if (length > max_length)
            {
                max_length = length;
                //max_index = balanseIndexes[balanseCounter] + 1;
            }
        }

        return max_length;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        var list = ReadList();

        writer.WriteLine( CalculateMaxRanges(list));

        reader.Close();
        writer.Close();
    }
    
    private static List<int> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}

/*
2
0 1
2


 10
0 0 1 0 0 0 1 0 0 1
4

16
0 0 1 0 0 1 1 1 1 1 0 0 0 0 0 1
14

71
0 0 1 0 0 1 0 0 1 0 1 0 0 0 0 0 0 1 0 0 1 0 0 1 1 0 0 0 1 1 1 0 0 1 0 0 0 1 1 1 1 1 1 0 1 0 0 0 1 1 0 0 0 1 1 0 0 0 0 0 0 1 0 0 1 1 0 0 0 0 1
38

31
0 1 1 1 1 1 0 1 1 0 1 0 1 0 1 0 1 1 0 1 1 1 0 1 0 0 1 0 0 1 0
22

9
0 0 1 1 1 0 0 1 1
8

85
1 1 1 1 1 0 0 1 1 0 1 1 0 0 0 0 1 0 1 0 1 0 0 0 1 0 0 1 1 0 0 0 0 1 0 1 0 1 0 0 1 0 1 0 0 1 0 1 1 0 0 0 1 1 0 1 0 0 0 0 0 0 0 0 0 1 1 0 1 0 0 0 0 0 1 1 0 0 1 1 1 1 1 0 1
30
 */