/*
 https://contest.yandex.ru/contest/24810/run-report/114695244/
 */

/*
   -- ПРИНЦИП РАБОТЫ --
      
   Общий алгоритм такой:

   1) Формирование кучи

   Создадим пустую бинарную кучу.
   Вставим в неё по одному все элементы данных, сохраняя свойства кучи.  
   
   2) Извлечение элементов
   Так как нам нужна сортировка от большего к меньшему, на вершине пирамиды должен оказаться самый маленький элемент. 
   Будем извлекать из неё наиболее приоритетные элементы (с самым большим значением), удаляя их из кучи. (Самый приоритетный элемент пирамиды находится на её вершине. Поэтому извлечём элемент из вершины и удалим его из кучи)
   
       
   -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --

    входные данные корректно обрабатываются данных алгоритмом
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --

    Будем рассматривать только сложности касамые непосредственно бинарной кучи.  Считывание/перекладыване данных для ввода вывода не будем рассматривать, оно О(1)

    Первый шаг — создание бинарной кучи (выделение памяти) (к тому же в даннйо реализации память выделяется динамически при добавлении элементов). Сложность этой операции — O(1).
    
    Следующий шаг - добавление n элементов подряд в бинарную кучу. Сложность - O(log1) + O(log2) + .. + O(log n).  Можно привести это к O(n log n)

    Далее - извлечение. Тут так же O(log n) + .. + O(log2) + O(log1)  =>  O(n log n)

    Итого общая сложность пирамидальной сортировки в худшем случае не дольше чем O(n log n)
      
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --

    Под данную реализацию необходимо O(n) доп. памяти. - под  струкруту данных для формиования кучи и вычитки с нее

    Так же есть и алгоритм реализации пирамидальной сортировки на месте, без использования доп. памяти.  
    https://ru.wikipedia.org/wiki/%D0%9F%D0%B8%D1%80%D0%B0%D0%BC%D0%B8%D0%B4%D0%B0%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F_%D1%81%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0
    https://habr.com/ru/companies/otus/articles/460087/
    Но это я попробую чуть позже ))

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
        Heap<UserInfo> heap = new Heap<UserInfo>();

        //переложим элементы в кучу , по правилам кучи
        foreach (var item in userInfoList)
        {
            heap.HeapAdd(item);
        }

        //можно было сразу выводить элементы, без перекладывания их в список, но опять же в целях контроля решил так
        List<UserInfo> sortedArray = new List<UserInfo>();

        // Будем извлекать из неё наиболее приоритетные элементы, удаляя их из кучи.
        while (heap.Count > 0)
        {
            var max = heap.PopMax();
            sortedArray.Add(max);
        }

        //вывод 
        foreach (var userInfo in sortedArray)
        {
            writer.WriteLine(userInfo.ToString());
        }
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();


        //можно ц целом сразу зачитывать в кучу,  но сделал так намеренно, в целях обучения и сравнения
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

public class Heap<T> where T : IComparable<T>
{
    private List<T> _heap;

    public Heap()
    {
        _heap = new List<T>();
    }

    //добавление элемента на кучу в соответсвии с правлами (с просииванием вверх)
    public void HeapAdd(T key)
    {
        _heap.Add(key);
        int index = _heap.Count - 1;
        SiftUp(index);
    }

    //снять с кучи приоритетный элемент
    public T PopMax()
    {
        var result = _heap[0];
        _heap[0] = _heap[_heap.Count - 1];
        _heap.RemoveAt(_heap.Count - 1);
        SiftDown(0);
        return result;
    }

    public int Count => _heap.Count;

    //просеивание вверх
    private void SiftUp(int index)
    {
        if (index == 0)
        {
            return;
        }

        int parentIndex = index / 2;

        //if (heap[parentIndex] < heap[index])
        if (_heap[parentIndex].CompareTo(_heap[index]) > 0)
        {
            (_heap[parentIndex], _heap[index]) = (_heap[index], _heap[parentIndex]);

            SiftUp(parentIndex);
        }
    }

    //просеивание вниз
    private void SiftDown(int index)
    {
        int left = 2 * index;
        int right = 2 * index + 1;

        // Нет дочерних узлов
        if (left >= _heap.Count)
        {
            return;
        }

        // right < heap.Count проверяет, что есть оба дочерних узла
        //int indexLargest = (right < heap.Count && heap[right] > heap[left]) ? right : left;
        int indexLargest = (right < _heap.Count && _heap[right].CompareTo(_heap[left]) < 0) ? right : left;

        //if (heap[indexLargest] > heap[index])
        if (_heap[indexLargest].CompareTo(_heap[index]) < 0)
        {
            (_heap[index], _heap[indexLargest]) = (_heap[indexLargest], _heap[index]);

            SiftDown(indexLargest);
        }
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


/*
 5
alla 6 100
gena 10 1000
gosha 2 90
rita 8 90
timofey 4 80

gena
rita
alla
timofey
gosha


5
alla 4 100
gena 6 1000
gosha 2 90
rita 2 90
timofey 4 80

gena
timofey
alla
gosha
rita


5
alla 0 0
gena 0 0
gosha 0 0
rita 0 0
timofey 0 0

alla
gena
gosha
rita
timofey

 */