using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class G
{
    private static TextReader reader;
    private static TextWriter writer;


    //этот вариант ен проходит по TL, что и логично
    private static SortedSet<Tuple<int, int, int, int>> FourSumm(int[] arr, int summ)
    {
        var history = new HashSet<int>();
        Array.Sort(arr);
        var fours = new SortedSet<Tuple<int, int, int, int>>();

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                for (int z = j + 1; z < arr.Length; z++)
                {
                    long target = (long)summ - arr[i] - arr[j] - arr[z];
                    if (history.Contains((int)target))
                    {
                        fours.Add(Tuple.Create((int)target, arr[i], arr[j], arr[z]));
                    }
                }
            }

            history.Add(arr[i]);
        }

        return fours;
    }

    private static SortedSet<Tuple<int, int, int, int>> FourSummVer2(int[] arr, int summ)
    {
        Array.Sort(arr);

        var twoSumms = new Dictionary<long, List<(int, int)>>();
        //закешируем все суммы двоек
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                //long для выстраданого примера из тестов
                long target = arr[i] + arr[j];

                if (!twoSumms.ContainsKey(target))
                    twoSumms[target] = new List<(int, int)>();

                twoSumms[target].Add((i, j));
            }
        }

        var fours = new SortedSet<Tuple<int, int, int, int>>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (i > 0 && arr[i] == arr[i - 1])
                continue;

            for (int j = i + 1; j < arr.Length; j++)
            {
                if (j > i + 1 && arr[j] == arr[j - 1])
                    continue;

                long target = (long)arr[i] + arr[j];

                if (!twoSumms.ContainsKey(summ - target))
                    continue;


                foreach (var indexesTuple in twoSumms[summ - target])
                {
                    if (indexesTuple.Item1 <= j)
                        continue;

                    var fourGroup = Tuple.Create(arr[i], arr[j], arr[indexesTuple.Item1], arr[indexesTuple.Item2]);

                    fours.Add(fourGroup);
                }
            }
        }
        return fours;
    }

    private static IList<IList<int>> ThreeSum(int[] nums)
    {
        var A = 0;

        var history = new HashSet<int>();
        Array.Sort(nums);

        var triples = new HashSet<Tuple<int, int, int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                int target = A - nums[i] - nums[j];
                if (history.Contains(target))
                {
                    triples.Add(Tuple.Create( target, nums[i], nums[j] ));
                }
            }
            history.Add(nums[i]);
        }

        var res = new List<IList<int>>();

        foreach (var item in triples)
        {
            res.Add(new List<int>(){item.Item1, item.Item2, item.Item3});
        }

        return res;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        ThreeSum(new int[] { 0, 0, 0, 0 });

        var n = ReadInt();

        var summ = ReadInt();

        var list = ReadList();

        var res = FourSummVer2(list.ToArray(), summ);

        writer.WriteLine(res.Count);

        foreach (var fours in res)
        {
            writer.WriteLine($"{fours.Item1} {fours.Item2} {fours.Item3} {fours.Item4}");
        }
        

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

8
10
2 3 2 4 1 10 3 0

3
0 3 3 4
1 2 3 4
2 2 3 3

-------

6
0
1 0 -1 0 2 -2

3
-2 -1 1 2
-2 0 0 2
-1 0 0 1

-------

5
4
1 1 1 1 1

1
1 1 1 1
 */