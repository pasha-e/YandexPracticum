using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class B
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        List<List<double>> dataList = new();

        for (int i = 0; i < n; i++)
        {
            var data = ReadList();

            dataList.Add(data);
        }        

        AnalyseSchedule(dataList);
        

        reader.Close();
        writer.Close();
    }



    private static void AnalyseSchedule(List<List<double>> dataList)
    {
        (double, double) record = (-1, -1);

        List<string> resultSched = new List<string>();
        
        //сортировка по возрастанию времени окончания
        dataList.Sort(CompareByStart);

        /*
        writer.WriteLine("------------");
        foreach (var data in dataList)
            writer.WriteLine($"{data[0]} {data[1]}");

        writer.WriteLine("------------");
        */

        var nextRec = dataList[0];  

        resultSched.Add($"{nextRec[0]} {nextRec[1]}");

        for (int i = 1; i < dataList.Count; i++)
        {
            if (dataList[i][0] >= nextRec[1])
            {
                nextRec = dataList[i];

                resultSched.Add($"{nextRec[0]} {nextRec[1]}");
            }
        }
        
        writer.WriteLine(resultSched.Count);

        foreach (var data in resultSched)
            writer.WriteLine(data);
    }

    private static int CompareByStart(List<double> x, List<double> y)
    {
        if (x == null)
        {
            if (y == null)
            {
                return 0;
            }
            else
                return -1;
        }
        else
        {
            if (y == null)
                return 1;
            else
            {
                if (x[1] == y[1])
                    return (x[0].CompareTo(y[0]));
                else
                    return x[1].CompareTo(y[1]);

            }
        }
    }

   

    private static List<double> ReadList()
    {
        return reader.ReadLine()
            .Replace('.',',')
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToList();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}

/*
5
9 10
9.3 10.3
10 11
10.3 11.3
11 12

3
9 10
10 11
11 12

---------------

7
19 19
7 14
12 14
8 22
22 23
5 21
9 23

3
7 14
19 19
22 23

---------------

3
9 10
11 12.25
12.15 13.3

2
9 10
11 12.25

---------------
6
9 21
3 6
0 17
1 1
9 20
18 19

3
1 1
3 6
18 19

---------------

5
10 23
14 16
4 9
13 19
12 21


4 9
14 16

---------------
59
15 22
17 20
12 13
21 23
15 15
3 23
20 23
7 18
11 13
2 16
7 19
1 10
16 23
15 17
15 19
12 14
8 9
8 17
19 23
12 15
3 10
3 8
17 20
20 21
0 0
17 21
13 17
2 23
20 20
18 19
9 10
7 10
23 23
22 22
8 10
4 9
21 21
18 22
14 19
19 20
22 23
12 22
3 9
15 23
2 21
8 8
10 15
13 13
0 7
11 19
0 22
2 6
15 16
5 8
20 23
18 23
11 22
17 20
12 14

17
0 0
2 6
8 8
8 9
9 10
11 13
13 13
15 15
15 16
18 19
19 20
20 20
20 21
21 21
22 22
22 23
23 23

--------------------------------

69
5 16
2 14
17 18
5 5
8 19
22 23
21 21
16 20
23 23
2 20
18 23
21 21
20 22
13 14
12 20
2 20
13 22
10 11
10 11
5 13
2 19
4 10
8 9
16 19
15 21
6 16
6 23
17 19
13 13
7 10
12 15
18 20
8 15
20 20
23 23
0 18
17 19
17 18
16 20
13 16
14 17
7 20
18 23
5 6
4 19
5 7
0 10
9 13
15 15
21 23
15 23
10 16
4 15
0 21
18 21
17 23
17 18
0 12
7 19
11 11
6 14
20 20
12 13
1 15
18 20
7 19
18 18
16 21
6 23

19
5 5
5 6
8 9
10 11
11 11
12 13
13 13
13 14
15 15
17 18
18 18
18 20
20 20
20 20
21 21
21 21
21 23
23 23
23 23
 */