using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Reflection.Metadata;

public class SearchSystem
{
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

        List<List<string>> requestsData = new List<List<string>>();

        for (int i = 0; i < m; i++)
        {
            requestsData.Add(ReadStrList());
        }
        
        var searchIndex = CreateSearchIndex(inputData);

        foreach (var requestStr in requestsData)
        {
            var resultOneDoc = FindRelevantDocuments(searchIndex, requestStr, limit: 5, numDocs: n+1);

            foreach (var res in resultOneDoc)
            {
                writer.Write($"{res} ");
            }
            writer.WriteLine();
        }

        reader.Close();
        writer.Close();
    }

    private static List<int> FindRelevantDocuments(Dictionary<string, Dictionary<int, int>> searchIndex, List<string> requestsData, int limit = 5, int numDocs = 10000)
    {
        var res = new List<List<int>>();
        for(int i=0; i < numDocs; i++)
            res.Add(new List<int>(){0, i});

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

    private static int CompareByWeight(List<int> x, List<int> y)
    {
        if (x == null && y == null) return 0;

        else if (x == null) return -1;
        else if (y == null) return 1;

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


    private static Dictionary<string, Dictionary<int, int>> CreateSearchIndex(List<List<string>> documents)
    {
        Dictionary<string, Dictionary<int, int>> searchIndexDictionary = new Dictionary<string, Dictionary<int, int>>();

        for (int i = 0; i < documents.Count; i++)
        {
            //переложим список в словарь
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
                //searchIndexDictionary[(pair.Key, i)] = pair.Value;

                if (!searchIndexDictionary.ContainsKey(pair.Key))
                {
                    searchIndexDictionary.Add(pair.Key, new Dictionary<int, int>());
                }

                searchIndexDictionary[pair.Key][i+1] = pair.Value ;

            }

        }

        return searchIndexDictionary;
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
   


3
i like dfs and bfs
i like dfs dfs
i like bfs with bfs and bfs
1
dfs dfs dfs dfs bfs

3 1 2
 */