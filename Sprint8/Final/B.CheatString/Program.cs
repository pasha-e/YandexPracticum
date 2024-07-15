/*
https://contest.yandex.ru/contest/26133/run-report/116123287/
 */

/*
   -- ПРИНЦИП РАБОТЫ --

    https://habr.com/ru/companies/otus/articles/674378/
    https://habr.com/ru/companies/otus/articles/676692/
    https://ru.algorithmica.org/cs/string-structures/trie/

    1) Сперва построим Префиксное дерево по заданным паттернам. 
        В структуре узла будем хранить переходы ( список ребёр ) в виде хэш таблицы  

    2) Сопоставление анализируемой строки заданному дереву
        Будем посимвольно сопоставляь строку узлам дерева, сдвигаясь на каждой итерации на символ.
        Если из позиции по текущему индексу  можно сопоставить слово в дереве (последний узел - терминаьный) - запомним это как True.
        Если Дерево приложить не удалось - так же отметим это.
        Для этого будем хранить булевый массив длинной количество символов в строке.
        Первую позицию зададим как True, так как пустая строка всегда присуттсвует.
      
    3) Если последнее слово удалось сопоставить (то есть последний символ помечен как True)  значит анализ завершен успешно
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
   Построение префиксного дерева - O(L), где L — суммарная длина всех слов-паттернов.
   Анализ:
    Сложность поиска узла в этом случае будет равна O(n) в среднем, n - число символов в строке
    Количство операций по поиску будет рано длиине самого большого паттерна O(M)
    Итого сложность будет O(n*M) ~  O(n*n)
   
          
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
    На построение префиксного дерево надо O(L), где L — суммарная длина всех слов-паттернов.
    На хранение массива сопоставлений - O(n), где  n - число символов в строке.
   
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class CheatString
{
    private const string Positive = "YES";
    private const string Negative = "NO";

    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var longStr = reader.ReadLine();

        //review
        //будем считывать бор без промежуторчных структур данных
        //(хотя на тесте оказалось, что это не дало прироста ни по времени, ни по памяти)
        Node root = CreateTree();

        var res = CheckStringToAllWords(longStr, root);
            
        writer.WriteLine(res? Positive : Negative );

        reader.Close();
        writer.Close();
    }

    private static bool CheckStringToAllWords(string? longStr, Node root)
    {
        bool[] dp = new bool[longStr.Length +1];

        for(int i = 0; i < dp.Length; i++)
        {
            dp[i] = false;
        }
        dp[0] = true;

        for (int i = 0; i < longStr.Length; i++)
        {
            Node node = root;

            //последнее слово найдено
            if (dp[^1]) //dp.Length - 1
                return true;

            if (!dp[i]) continue;

            for (int j = i; j < longStr.Length + 1; j++)
            {
                if(node.IsTerminal)
                    dp[j] = true;
                if(j == longStr.Length ||
                   !node.Edges.ContainsKey(longStr[j]))
                {
                    break;
                }

                node = node.Edges[longStr[j]];
            }
        }

        return dp[^1];
    }


    /// <summary>
    /// создать префиксное деверо
    /// </summary>
    /// <returns></returns>
    private static Node CreateTree()
    {
        Node root = new Node();

        var n = ReadInt();

        //по всем словам словаря
        for(var i = 0; i < n; i++)
        {
            var pattern = reader.ReadLine();

            Node curNode = root;

            //посимвольно
            foreach (var symb in pattern)
            {
                Node nextNode = new Node();
 
                if (curNode.Edges.ContainsKey(symb))
                {
                    nextNode = curNode.Edges[symb];
                }

                //создать ребро symb из curNode в nextNode
                curNode.Edges[symb] = nextNode;

                //Сдвинуться на следующий символ (сдвиг по ребру symb)
                curNode = nextNode;
            }

            //поменить узел как терминальный
            curNode.IsTerminal = true;
        }

        return root;
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }

}

public class Node
{
    //список рёбер в вершины из текущего узла
    public Dictionary<char, Node> Edges = new ();

    //флаг терминальности узла
    public bool IsTerminal  = false;
}

/*
examiwillpasstheexam
5
will
pass
the
exam
i

YES


abacaba
2
abac
caba

NO


abacaba
3
abac
caba
aba

YES


sscevscescescscsscevscevscesscsc
4
sce
s
scev
sc

YES


axymaxymaxyaxymaxyaxymaxymaxax
4
axy
axym
ax
a

YES


bwvfbtrjqpbwvfbbwvbwbbwbbwvbwvf
4
bwvf
b
bw
bwv

NO


ijwxoxojijwijwnqqxojijwumanjqxoj
4
ijw
xoj
nqq
xo

NO
 */
