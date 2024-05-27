using System;
using System.Collections.Generic;
using System.Reflection;

public class Solution
{
    public static int SiftDown(List<int> array, int idx)
    {
        int left = 2 * idx;
        int right = 2 * idx + 1;

        // Нет дочерних узлов
        if (left >= array.Count)
        {
            return idx;
        }

        // right < heap.Count проверяет, что есть оба дочерних узла
        int indexLargest = (right < array.Count && array[right] > array[left]) ? right : left;

        if (array[idx] >= array[indexLargest])
            return idx;

        (array[idx], array[indexLargest]) = (array[indexLargest], array[idx]);

        return SiftDown(array, indexLargest);

        /*
        if (array[indexLargest] > array[idx])
        {
            int temp = array[idx];
            array[idx] = array[indexLargest];
            array[indexLargest] = temp;
            SiftDown(array, indexLargest);
        }

        return indexLargest;*/
    }

#if !REMOTE_JUDGE
    private static void Main()
    {
        var sample = new List<int> { -1, 12, 1, 8, 3, 4, 7 };
        //System.Console.WriteLine(SiftDown(sample, 2));
        System.Console.WriteLine(SiftDown(sample, 2) == 5);
    }
#endif
}