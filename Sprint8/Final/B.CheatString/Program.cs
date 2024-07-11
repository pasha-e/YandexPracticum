/*
https://contest.yandex.ru/contest/26133/run-report/116020620/
 */

/*
   -- ПРИНЦИП РАБОТЫ --

      
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
   
   
          
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
    
   
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

        var n = ReadInt();

        List<string> wordsList = new();

        for (int i = 0; i < n; i++)
        {
            wordsList.Add(reader.ReadLine());
        }

        var res = CheckStringToAllWords(longStr, wordsList);
            
        writer.WriteLine(res? Positive : Negative );

        reader.Close();
        writer.Close();
    }

    private static bool CheckStringToAllWords(string? longStr, List<string> wordsList)
    {
        Node root = CreateTree(wordsList);

        bool[] dp = new bool[longStr.Length +1];

        for(int i = 0; i < dp.Length; i++)
        {
            dp[i] = false;
        }
        dp[0] = true;

        for (int i = 0; i < longStr.Length; i++)
        {
            Node node = root;

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
    /// <param name="patternList"></param>
    /// <returns></returns>
    private static Node CreateTree(List<string> patternList)
    {
        Node root = new Node();

        //по всем словам словаря
        foreach (var pattern in patternList)
        {
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
