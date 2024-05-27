/*
 
 */

/*
   -- ПРИНЦИП РАБОТЫ --
      
   -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
   
      
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
   
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Final2QuickSort
{
    private static TextReader reader;
    private static TextWriter writer;

    private static void HeapSort(List<UserInfo> userInfoList)
    {
        
        // Создадим пустую бинарную кучу.
        List<UserInfo> heap = new List<UserInfo>();

        // Вставим в неё по одному все элементы массива, сохраняя свойства кучи.
        foreach (var item in userInfoList)
        {
            HeapAdd(heap, item);  
        }

        // Будем извлекать из неё наиболее приоритетные элементы, удаляя их из кучи.
        List<UserInfo> sortedArray = new List<UserInfo>();
        while (heap.Count > 0)
        {
            var max = PopMax(heap);
            sortedArray.Add(max);
        }

        //sortedArray.Add(heap[0]);

        //вывод
        foreach (var userInfo in sortedArray)
        {
            writer.WriteLine(userInfo.ToString());
        }
    }

    static void HeapAdd(List<UserInfo> heap, UserInfo key)
    {
        heap.Add(key);
        int index = heap.Count - 1;
        SiftUp(heap, index);
    }

    static void SiftUp(List<UserInfo> heap, int index)
    {
        if (index == 1)
        {
            return;
        }

        int parentIndex = index / 2;

        //if (heap[parentIndex] < heap[index])
        if (heap[parentIndex].CompareTo(heap[index]) < 0 )
        {
            var temp = heap[parentIndex];
            heap[parentIndex] = heap[index];
            heap[index] = temp;

            //(heap[parentIndex], heap[index]) = (heap[index], heap[parentIndex]);

            SiftUp(heap, parentIndex);
        }
    }

    static void SiftDown(List<UserInfo> heap, int index)
    {
        int left = 2 * index;
        int right = 2 * index + 1;

        // Нет дочерних узлов
        if (left >= heap.Count)
        {
            return;
        }

        // right < heap.Count проверяет, что есть оба дочерних узла
        //int indexLargest = (right < heap.Count && heap[right] > heap[left]) ? right : left;
        int indexLargest = (right < heap.Count && heap[right].CompareTo(heap[left]) > 0) ? right : left;

        //if (heap[indexLargest] > heap[index])
        if (heap[indexLargest].CompareTo(heap[index]) > 0)
        {
            var temp = heap[index];
            heap[index] = heap[indexLargest];
            heap[indexLargest] = temp;

            //(heap[indexLargest], heap[index]) = (heap[index], heap[indexLargest]);


            SiftDown(heap, indexLargest);
        }
    }

    static UserInfo PopMax(List<UserInfo> heap)
    {
        var result = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        SiftDown(heap, 1);
        return result;
    }


    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        var userInfoList = new List<UserInfo>();

        for (int i = 0; i < n; i++)
        {
            userInfoList.Add(ReadUserInfo());
        }

        HeapSort(userInfoList);

        reader.Close();
        writer.Close();
    }

    private static UserInfo ReadUserInfo()
    {
        var userInfoArr = reader.ReadLine().Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries);

        return new UserInfo(userInfoArr[0], Convert.ToInt32(userInfoArr[1]), Convert.ToInt32(userInfoArr[2]));

    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}

public class UserInfo : IComparable<UserInfo>
{
    public readonly string _userName;
    public readonly int _solved;
    public readonly int _penalty;

    public string UserName => _userName;
    public int Solved => _solved;
    public int Penalty => _penalty;

    public UserInfo(string userName, int solved, int penalty)
    {
        _userName = userName;
        _solved = solved;
        _penalty = penalty;
    }

    public override string ToString()
    {
        return $"{UserName}";
    }

    public int CompareTo(UserInfo? other)
    {
        if (this.Solved == other.Solved)
        {
            if (this.Penalty == other.Penalty)
            {
                return String.Compare(this.UserName, other.UserName);
            }

            return this.Penalty < other.Penalty ? -1 : 1;
        }

        return this.Solved < other.Solved ? 1 : -1;
    }

}