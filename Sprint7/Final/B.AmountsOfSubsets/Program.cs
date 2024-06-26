
/*
https://contest.yandex.ru/contest/25597/run-report/115512643/
 */
/*
     -- ПРИНЦИП РАБОТЫ --

        https://ru.wikipedia.org/wiki/%D0%97%D0%B0%D0%B4%D0%B0%D1%87%D0%B0_%D1%80%D0%B0%D0%B7%D0%B1%D0%B8%D0%B5%D0%BD%D0%B8%D1%8F_%D0%BC%D0%BD%D0%BE%D0%B6%D0%B5%D1%81%D1%82%D0%B2%D0%B0_%D1%87%D0%B8%D1%81%D0%B5%D0%BB

        Нужно определить сущетвует ли такое подмножество  S, сумма которого равна К/2   (где К - сумма всех элементов множества)

        dp[i,j] = True, если вседи всех элементов есть такое подмножетсво , котрое в сумме даст i

        Значит dp[K/2, n] = True только когда  есть подмножество сумма котораого равно K/2

        dp[i,j] = true, если dp[i, j-1] == True  || dp[i - x[j], j-1] == True , где x[j] -  элемент проверяемого множетсва с номером j
         
        как и в прошлой задаче, нам нужно узнать только сам факт возможности разбиения на подмножетсва, значит можно не хранить всю матрицу целиком

        Будем хранить список булевых хначений зазмера К/2 +1  (баз. случай)

        Поочерёдно просматривает по всем элементам входного массива и по элементам этого списка проверяем значения от target до элемента входного массива
        рекурентная формула dp[j] = dp[j - arr[i]] || dp[j];  где arr - входнйо список

        Если в последней ячейке получается True  - значит сумма есть

     
     -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
   
     O(K*N), где N — число элементов во входном множестве, а K — сумма элементов во входном множестве.
            
     -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
    
     O(K/2) = O(K) , где K — сумма элементов во входном множестве.
    
   */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Subsets
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        var arr = ReadList();

        bool res = CheckSubsets(arr);

        writer.WriteLine(res);

        reader.Close();
        writer.Close();
    }

    private static bool CheckSubsets(List<int> arr)
    {
        var K = arr.Sum(x => x); // сумма элементов множества
        
        if(K%2 != 0) 
            return false;

        var target = K / 2;

        bool[] dp = new bool[target + 1]; 

        for(int i=0; i< dp.Length; i++)
            dp[i] = false;

        //базовый случай
        dp[0] = true;
        
        //по всем элементам входного массива...
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] == target) //есть элемент который половина суммы  - сразу выход
                return true;  

            if (arr[i] > target) //есть элемент который больше половины суммы  - сразу выход
                return false;

            //PrintDebug(dp);

            //проверяем значения от target до элемента входного массива
            for (int j = target; j > arr[i]-1; j--)
            {
                //True - если элемент есть во входящих значениях

                //PrintDebug(dp);

                dp[j] = dp[j - arr[i]] || dp[j];

                if (j == target && dp[j]) // если в последней ячейке появляятся True - то дальше можно не сомтреть, как миним одно решение есть
                    return true;
            }
        }

        return dp[target];
    }

    private static void PrintDebug(bool[] dp)
    {
        foreach(bool b in dp)
            writer.Write($"{b} ");

        writer.WriteLine();
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



6
7 9 3 4 6 7

True

7
23 13 11 7 6 5 5

True

4
1 5 10 6

True

63
165 163 174 147 84 127 295 215 107 216 172 222 68 100 185 296 245 254 297 25 79 60 81 100 291 283 94 17 250 17 266 263 196 52 292 12 1 156 69 267 21 176 189 96 12 140 80 6 7 266 72 50 275 42 257 238 113 6 12 230 3 68 140

True
 */
