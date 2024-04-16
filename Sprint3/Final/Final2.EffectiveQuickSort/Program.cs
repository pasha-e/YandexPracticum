/*
 https://contest.yandex.ru/contest/23815/run-report/112098543/
 */

/*
   -- ПРИНЦИП РАБОТЫ --
   (из описания задачи)

    Как и в случае обычной быстрой сортировки, которая использует дополнительную память, 
    необходимо выбрать опорный элемент (англ. pivot), а затем переупорядочить массив. 
    Сделаем так, чтобы сначала шли элементы, не превосходящие опорного, а затем —– большие опорного.
   
    Затем сортировка вызывается рекурсивно для двух полученных частей. 
    Именно на этапе разделения элементов на группы в обычном алгоритме используется дополнительная память. 

    Пусть мы как-то выбрали опорный элемент. 
    Заведём два указателя left и right, которые изначально будут указывать на левый и правый концы отрезка соответственно. 
    Затем будем двигать левый указатель вправо до тех пор, пока он указывает на элемент, меньший опорного. 
    Аналогично двигаем правый указатель влево, пока он стоит на элементе, превосходящем опорный. 
    В итоге окажется, что что левее от left все элементы точно принадлежат первой группе, а правее от right — второй. 
    Элементы, на которых стоят указатели, нарушают порядок. 
    Поменяем их местами и продвинем указатели на следующие элементы. 
    Будем повторять это действие до тех пор, пока left и right не столкнутся.

   
   -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --

    Быстрая сортировка основана на принципе разделяй и властвуй. 
    Делим входные данные на части относительно опорной точки
    Случайный выбор опорной точки  даёт нам шанс надётся что мы не попадём на худший случай временой сложности.
    Элементы меньшие опорной точки сдвигаем влево, большие вправо.
    Рекурсивно повторяем до достижении цели.

    Сравнение элементов осуществляется на выбраннах нами принциципах сравнения.
   
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
   
    Временная сложность алгоритма быстрйо сортировки зависит от глубины рекурсии.
    Которая в свою очередь зависит от колисечтва элементов n и успешности выбора опорной точки.
    Значит общая сложность определяется количеством разбиений на подмассивы (глубиной рекурсии)
     Худший случай О(n^2)  - когда один из подмассивов будет всегда пуст
     Лучший случай О(n*log n) - когда разделение будет такого что подмассивы будут одинаковы
     Поосколько  худший случай это особо "подогнанный" вариант входных данных и выбора опорной точки,
     можно сказать что в среднем сложность будет О(n*log n)

   
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
   
   Алгоритм не задействует внешней памяти зависимой от размера входных данных. Поэтому его сложность можно определить как О(1)
    
   

 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Final2QuickSort
{
    private static TextReader reader;
    private static TextWriter writer;

    private static void EffectiveQuickSort(List<UserInfo> userInfoList)
    {
        QuickSort(ref userInfoList, inLeft: 0, inRight: userInfoList.Count -1);

        foreach (var userInfo in userInfoList)
        {
            writer.WriteLine(userInfo.ToString());
        }
    }

    /// <summary>
    /// рекурсивная функция быстрой сортировки на месте.
    /// </summary>
    /// <param name="list">ссылка на список (передаём по ссылке чтобы изменять входные данные, бз создания копии)</param>
    /// <param name="inLeft">указатель (индекс) левой границы </param>
    /// <param name="inRight">указатель (индекс правой границы)</param>
    private static void QuickSort(ref List<UserInfo> list, int inLeft, int inRight)
    {
        if (inLeft >= inRight)
        {
            return ;
        }

        // опорная точка
        var pivot = list[FindPivot(inLeft, inRight)];

        var left = inLeft;
        var right = inRight;

        while (left <= right)
        {
            while (list[left].CompareTo( pivot) < 0 )
            {
                left++;
            }

            while (list[right].CompareTo(pivot) > 0)
            {
                right--;
            }

            if (left <= right)
            {
                //сортировка на месте - просто меняем элементы местами (swap)
                (list[left], list[right]) = (list[right], list[left]);

                left++;
                right--;
            }
        }
        //рекурсивный вызов для сформированных подмассивов
        QuickSort(ref list, inLeft, right);
        QuickSort(ref list, left, inRight);
    }

    /// <summary>
    /// выбор опорной точки случайным образом
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private static int FindPivot(int left, int right)
    {
        Random rnd = new Random();
        return  rnd.Next(left, right);
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

        EffectiveQuickSort(userInfoList);

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