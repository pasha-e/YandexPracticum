
using System;
using System.Collections.Generic;

public class Solution
{
    public static int SiftUp(List<int> array, int idx)
    {
        if (idx == 1)
        {
            return idx;
        }

        int parentIndex = idx / 2;

        if (array[parentIndex] >= array[idx])
            return idx;


        (array[parentIndex], array[idx]) = (array[idx], array[parentIndex]);

        return SiftUp(array, parentIndex);
    }

#if !REMOTE_JUDGE
    private static void Main()
    {
        var sample = new List<int> { -1, 12, 6, 8, 3, 15, 7 };
        System.Console.WriteLine(SiftUp(sample, 5) == 1);
    }
#endif
}
