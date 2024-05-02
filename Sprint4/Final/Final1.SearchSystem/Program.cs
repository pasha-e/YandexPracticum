/*
 https://contest.yandex.ru/contest/24414/run-report/113401454/
 */
/*
 -- ПРИНЦИП РАБОТЫ --
   

   
   -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
   
       
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
   
       
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
   
   n - число документов  по макс. 1000 символов
    макс. n - 10^4

    на построение индекса нужно O(n) доп. памяти
    
      
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;

public class Final1SearchSystem
{
    private const int OutLimit = 5;
    private const int MacDocsCount = 10*10*10*10;

    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        
        var n = ReadInt();

        List<List<string>> inputData = new List<List<string>>();

        for (int i = 0; i < n; i++)
        {
            inputData.Add(ReadStrList() );
        }
        
        var m = ReadInt();

        List<HashSet<string>> requestsData = new List<HashSet<string>>();
        //List<List<string>> requestsData = new List<List<string>>();

        for (int i = 0; i < m; i++)
        {
            /*
             var strList = ReadStrList();
            strList = strList.Distinct().ToList();

            requestsData.Add(strList);
            */
            requestsData.Add(ReadHashSet());
        }
        
        var searchIndex = CreateSearchIndex(inputData);

        //по каждой строчке Запроса
        foreach (var requestStr in requestsData)
        {
            //считаем релевантность
            var resultOneDoc = FindRelevantDocuments(searchIndex, requestStr, limit: 5, numDocs: n+1);

            PrintLine(resultOneDoc);
        }

        reader.Close();
        writer.Close();
    }

    
    private static Dictionary<string, Dictionary<int, int>> CreateSearchIndex(List<List<string>> documents)
    {
        //word : (document : weight)
        Dictionary<string, Dictionary<int, int>> searchIndexDictionary = new Dictionary<string, Dictionary<int, int>>();

        //по всем документам
        for (int i = 0; i < documents.Count; i++)
        {
            //переложим список в словарь word : weight
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var word in documents[i])
            {
                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, 1);
                    continue;
                }

                dict[word]++;
            }

            foreach (var pair in dict)
            {
                if (!searchIndexDictionary.ContainsKey(pair.Key))
                {
                    searchIndexDictionary.Add(pair.Key, new Dictionary<int, int>());
                }

                searchIndexDictionary[pair.Key][i+1] = pair.Value;
            }
        }

        return searchIndexDictionary;
    }

    private static List<int> FindRelevantDocuments(Dictionary<string, Dictionary<int, int>> searchIndex, HashSet<string> requestsData, int limit = OutLimit, int numDocs = MacDocsCount)
    {
        var res = new List<int[]>();

        for(int i=0; i < numDocs; i++)
            res.Add(new int[] { 0, i });

        foreach (var word in requestsData)
        {
            if (searchIndex.ContainsKey(word))
            {
                //pair : document - weight
                foreach (var pair in searchIndex[word])
                {
                    res[pair.Key][0] -= pair.Value;
                }
            }
        }

        //отсортируем по весу
        res.Sort(CompareByWeight);

        //подготовка вывода (проверрка на лимит и !0)
        List<int> resultIndexes = new List<int>();

        for (int i = 0; i < res.Count; i++)
        {
            if (i >= limit)
                break;

            if (res[i][0] < 0)
                resultIndexes.Add(res[i][1]);
        }

        return resultIndexes;
    }

    private static int CompareByWeight(int[] x, int[] y)
    {
        if (x == null && y == null) return 0;

        else if (x == null) return -1;
        else if (y == null) return 1;

        else if (x[0] == y[0])
            return x[1].CompareTo(y[1]);

        else return x[0].CompareTo(y[0]);
    }


    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }

    private static List<string> ReadStrList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private static HashSet<string> ReadHashSet()
    {
        var hashSet = new HashSet<string>();

        var strList = ReadStrList();
        foreach (var str in strList)
        {
            hashSet.Add(str);
        }

        return hashSet;
    }

    private static void PrintLine(List<int> list)
    {
        foreach (var val in list)
        {
            writer.Write($"{val} ");
        }
        writer.WriteLine();
    }
}


/*

6
buy flat in moscow
rent flat in moscow
sell flat in moscow
want flat in moscow like crazy
clean flat in moscow on weekends
renovate flat in moscow
1
flat in moscow for crazy weekends
   
4 5 1 2 3

--------------------------------------------

3
i like dfs and bfs
i like dfs dfs
i like bfs with bfs and bfs
1
dfs dfs dfs dfs bfs

3 1 2

--------------------------------------------

3
i love coffee
coffee with milk and sugar
free tea for everyone
3
i like black coffee without milk
everyone loves new year
mary likes black coffee without milk

1 2
3
2 1


 */