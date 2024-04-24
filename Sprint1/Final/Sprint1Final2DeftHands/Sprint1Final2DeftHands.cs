/*
https://contest.yandex.ru/contest/22450/run-report/111066288/
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Sprint1Final2DeftHands
{
    private static TextReader reader;
    private static TextWriter writer;

    private const int NumberOfPlayers = 2; // число игроков
    private const int MaxRoundNumber = 9; // максимальный номер раунда
    private const int FieldRowCount = 4; // число строк нв поле

    /// <summary>
    /// 
    /// </summary>
    /// <param name="maxKey"> число клавиш которое может дажать игрок одновременно (k) </param>
    /// <param name="fieldList">игровое поле приведенное к списку</param>
    /// <returns></returns>    
    private static int GetMaxResult(int maxKey, List<int> fieldList)
    {
        int result = 0;

        int maxPlayersKey = maxKey * NumberOfPlayers;

        //подготовка данных
        List<int> numbersAtFieldList = new List<int>();
        
        for(int i =0; i < MaxRoundNumber; i++)
            numbersAtFieldList.Add(0);

        foreach (int cellValue in fieldList)
            numbersAtFieldList[cellValue-1]++;
        
        //цикл по раундам        
        for (int t = 1; t <= MaxRoundNumber; t++)
        {
            if (numbersAtFieldList[t - 1] == 0)
                continue;

            var lapNumberCount = numbersAtFieldList[t - 1];

            if (lapNumberCount <= maxPlayersKey)
                result++;
        }

        return result;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var maxKeyAtMoment = ReadInt();

        var fieldList = ReadFieldArr();
        
        var maxPoint = GetMaxResult(maxKeyAtMoment, fieldList);

        writer.WriteLine(maxPoint);

        reader.Close();
        writer.Close();
    }

    /// <summary>
    /// считываем строки, сразу отбрасываем точки и скрадываем в список. в данной задаче форма поля не имеет значения
    /// </summary>
    /// <returns></returns>
    private static List<int> ReadFieldArr()
    {
        var result = new List<int>();

        for (int i = 0; i < FieldRowCount; i++)
        {   
            var strRow = reader.ReadLine();

            foreach(var symb in strRow)
            {
                if(Char.IsDigit(symb))                    
                    result.Add(Convert.ToInt32(Char.GetNumericValue(symb)));
            }            
        }

        return result;
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}