using System;
using System.Collections.Generic;
using System.IO;

public class L
{
    private static TextReader reader;
    private static TextWriter writer;

    
    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        string str1 = reader.ReadLine();

        string str2 = reader.ReadLine();

        writer.WriteLine( CompareString(str1, str2) ? "YES":"NO");

        reader.Close();
        writer.Close();
    }

    private static bool CompareString(string str1, string str2)
    {
        if(str1.Length != str2.Length)
            return false;

        //уфф..  будем хранить на символ  пару первое вхождение / число появлений
        Dictionary<char, (int,int)> mapStr1 = new Dictionary<char, (int, int)>();
        Dictionary<char, (int, int)> mapStr2 = new Dictionary<char, (int, int)>();

        for (int i = 0; i < str1.Length; i++)
        {
            var symb1 = str1[i];
            var symb2 = str2[i];

            if (mapStr1.ContainsKey(symb1) && mapStr2.ContainsKey(symb2))
            {
                if (mapStr1[symb1] != mapStr2[symb2])
                    return false;

                mapStr1[symb1] = (mapStr1[symb1].Item1, mapStr1[symb1].Item2+1);
                mapStr2[symb2] = (mapStr2[symb2].Item1, mapStr2[symb2].Item2 + 1);

                continue;
            }

            if (!mapStr1.ContainsKey(symb1) && !mapStr2.ContainsKey(symb2))
            {
                mapStr1[symb1] = (i, 1);
                mapStr2[symb2] = (i, 1); 
            }
            else
                return false;
            
        }

        return true;
    }


}

/*

agg
xdd
YES

mxyskaoghi
qodfrgmslc
YES

agg
xda
NO

agg
pap
NO

 */