/*
https://contest.yandex.ru/contest/23815/run-report/112123270/
 */

/*
   -- ПРИНЦИП РАБОТЫ --

    По условию, входные данных состоят из двух отсосртированных подмассиво.
    Необходимо найти точку (индекс) на котором случился "перелом". 
    Эта точка и будет нашей опорной точкой, разделяющей массив на два отсортированных подмассива
    Так как подмассивы отсортированы мы можем определить в какой из них необходимо искать элемент
    Выполнить бинарный поиск по подмассиву, с искомым элементом
    
   -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --

    в работе алгоритма будем использовать прицнипы бинарного поиска
    Бинарный поиск заботает по принципу разделяй и властвуй. 
    Т.е разделяем задачу на подзадачи и решаем их отдельно. Посторяя этот механизм рекурсивно.
    Такой подход позволяет осуществлять эффективный поиск по упорядоченным наборам данных.
    
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --

   Поиск опорной точки в массиве из n имеет временную сложность О(lon n), так как поиск идёт методом деления пополам
   Бинарный поиск в подмассивах так же имеет пространственную сложность О(lon n)
   Соответственно общая временная сложность  О(lon n)

   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --

    Поиск опорной точки имеет пространственную сложность О(1)
    Бинарный поиск в подмассивах так же имеет пространственную сложность О(1)
    Соответственно общая сложность также О(1)

*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Solution
{
    public static int BrokenSearch(List<int> array, int el)
    {
        int pivot = FindPivot(array);

        if (array[pivot] == el)
            return pivot;

        //искомый элемент больше первого элемента массива - значит ищем в первой части
        if (array[0] <= el)
            return BinarySearch(array, el, 0, pivot);
        
        // иначе во второй
        return BinarySearch(array, el, pivot+1, array.Count);
    }

    private static int BinarySearch(List<int> array, int el, int left, int right)
    {
        if (right <= left) //границы сместились, промежуток пуст
        {
            return -1;
        }

        // промежуток не пуст
        int mid = (left + right) / 2;

        if (array[mid] == el) // центральный элемент — искомый
        {
            return mid;
        }
        else if (el < array[mid]) // искомый элемент меньше центрального значит следует искать в левой половине
        {
            return BinarySearch(array, el, left, mid);
        }
        else // иначе следует искать в правой половине
        {
            return BinarySearch(array, el, mid + 1, right);
        }
    }
    

    /// <summary>
    /// Поиск опорной точки.  У нас это будет точка "перелома"
    /// </summary>
    /// <param name="list"></param>
    /// <returns>индекс опорной точки</returns>
    private static int FindPivot(List<int> list)
    {
        var left = 0;
        var right = list.Count -1;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            if (list[mid] >= list[right])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        if (right > 0)
            return right;

        return list.Count - 1;
    }
   
#if !REMOTE_JUDGE
    private static void Main()
    {
        var arr = new List<int> { 19, 21, 100, 101, 1, 4, 5, 7, 12 };
        Console.WriteLine(BrokenSearch(arr, 5) == 6);

        var arr2 = new List<int> { 19, 21, 100, 101, 102, 103, 1, 4, 5, 7, 12, 13 };
        Console.WriteLine(BrokenSearch(arr2, 5) == 8);

        var arr3 = new List<int> { 19, 21, 100, 101, 102, 103, 1, 4, 5, 7, 12, 13 };
        Console.WriteLine(BrokenSearch(arr3, 13) == 11);

        var arr4 = new List<int> { 19, 21, 100, 101, 102, 103, 1, 4, 5, 7, 12, 13 };
        Console.WriteLine(BrokenSearch(arr4, 19) == 0);

        var arr5 = new List<int> { 19, 21, 100, 101, 102, 103, 1, 4, 5, 7, 12, 13 };
        Console.WriteLine(BrokenSearch(arr5, 105) == -1);

        var arr6 = new List<int> { 19, 21, 100, 101, 102, 103, 1, 4, 5, 7, 12, 13 };
        Console.WriteLine(BrokenSearch(arr6, 1) == 6);

        var arr7 = new List<int> { 1, 5 };
        Console.WriteLine(BrokenSearch(arr7, 1) == 0);

        var arr10 = new List<int> { 1, 5 };
        Console.WriteLine(BrokenSearch(arr10, 5) == 1);
        
        var arr8 = new List<int> { 5, 1 };
        Console.WriteLine(BrokenSearch(arr8, 1) == 1);

        var arr9 = new List<int> { 3, 5, 6, 7, 9, 1, 2 };
        Console.WriteLine(BrokenSearch(arr9, 4) == -1);

    }
#endif

}

/*
9
5
19 21 100 101 102 103 1 4 5 7 12 13
8

9
13
19 21 100 101 102 103 1 4 5 7 12 13
11

9
19
19 21 100 101 102 103 1 4 5 7 12 13
0

9
105
19 21 100 101 102 103 1 4 5 7 12 13
-1

9
1
19 21 100 101 102 103 1 4 5 7 12 13
6


2
1
1 5
0

2
1
5 1
1

7
4
3 5 6 7 9 1 2
-1
 */