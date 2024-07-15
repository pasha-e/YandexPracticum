/*
https://contest.yandex.ru/contest/26133/run-report/115998907/
 */

/*
   -- ПРИНЦИП РАБОТЫ --

    1) Сперва проведём распаковку строк
        Будем набирать символы с стек, пока не встретится закрывающаяся скобка.
        После этого - разбираем стек, пока не встретится открывающаяся скобка
        Дублируем символы нужное число раз
        Посторим операции до конца строки
        
    2) В полученный строках ищем наибольший общий перфикс.
        Поочередно посимвольно сравним все строки, приняв за эталон первую
        В итоге, отбрасывая несовпадающие символы получим общий префикс
    
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
        Распаковка строк - O(l),  где l длина  строки.
        Вычисление префикса - O(n*m), где n число строк, m - длина самой большой строки (распакованной)
        Итого O(n*m)
          
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
         O(m), где m длина самой большой строки (распакованной).
   
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class PacketFrefix
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        List<string> dataList = new();

        for (int i = 0; i < n; i++)
        {
            var str = reader.ReadLine();
            dataList.Add(str);
        }

        string res = FindMaxPrefix(dataList);

        writer.WriteLine(res);

        reader.Close();
        writer.Close();
    }

    private static string FindMaxPrefix(List<string> dataList)
    {
        if (dataList.Count == 0)
            return string.Empty;

        string prefix = UnpackString(dataList[0]);
        
        for (int i = 1; i < dataList.Count; i++)
        {
            var unpackStr = UnpackString(dataList[i]);

            var minLenght = Math.Min(prefix.Length, unpackStr.Length);
            int j;
            for (j = 0; j < minLenght; j++)
            {
                if (prefix[j] != unpackStr[j])
                    break;
            }

            prefix = unpackStr[Range.EndAt(j)];
        }

        return prefix;
    }

    
    private static string UnpackString(string packedStr)
    {
        var result = string.Empty;

        Stack<string> symbolStack = new ();
        
        foreach (var ch in packedStr)
        {
            switch (ch)
            {
                case ']':
                {
                    List<string> listStr = new();
                    //пришло завершение - надо разбирать стек
                    while (symbolStack.TryPop(out var symb))
                    {
                        if (symb == "[") 
                            break;
                        listStr.Add(symb);
                    }

                    listStr.Reverse();

                    var str = ListJoinToString(listStr);

                    var count = Convert.ToInt32(symbolStack.Pop());

                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < count; i++)
                        sb.Append(str);

                    symbolStack.Push(sb.ToString());

                    break;
                }
                default: // [ &  digit
                    symbolStack.Push($"{ch}");
                    break;
            }
        }


        //разберём стек, не забыв перевернуть
        return StackJoinToString(symbolStack);
    }

    private static string StackJoinToString(Stack<string> stack)
    {
        List<string> strList = new();
        while (stack.TryPop(out var symb))
        {
            strList.Add(symb);
        }

        strList.Reverse();

        return ListJoinToString(strList);
    }

    private static string ListJoinToString(List<string> list)
    {
        StringBuilder sb = new ();
        foreach (var item in list)
        {
            sb.Append(item);
        }

        return sb.ToString();
    }


    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }


}

/*
2[1[emgu]]
emguemgu
------------------

3
2[a]2[ab]
3[a]2[r2[t]]
a2[aa3[b]]

aaa

3
abacabaca
2[abac]a
3[aba]
aba


5
3[2[bkyb]2[eszi]1[k]1[ep]]2[w]3[3[a]]1[krr]2[lh]1[pj]
3[2[bkyb]2[eszi]1[k]1[ep]]2[w]3[3[a]]1[3[i]2[t]]
3[2[bkyb]2[eszi]1[k]1[ep]]2[w]3[3[a]]1[1[i]2[nbiv]1[i]]1[blrw]3[gh]2[g]3[gt]
3[2[bkyb]2[eszi]1[k]1[ep]]2[w]3[3[a]]3[1[f]1[uze]]3[3[f]1[zw]]
3[2[bkyb]2[eszi]1[k]1[ep]]2[w]3[3[a]]3[al]1[kywr]2[1[lhgo]]

bkybbkybeszieszikepbkybbkybeszieszikepbkybbkybeszieszikepwwaaaaaaaaa


5
2[jwcn]2[1[emgu]]1[bzgy]
jwcnjwcnemguemgu2[ctr]2[1[cnma]3[y]2[b]3[v]3[gas]]3[oc]
jwcnjwcnemguemgu2[2[mou]1[y]2[dd]]1[1[ynt]]1[nnq]2[qfw]2[e]1[1[k]1[utz]1[fal]2[g]]
jwcnjwcnemguemgu1[j]3[2[h]3[iqd]3[xen]1[ia]]2[3[i]]2[li]
2[jwcn]2[1[emgu]]2[whub]3[qdrz]3[3[potn]2[l]1[wc]1[snzs]]1[3[u]3[myi]2[fdk]2[ot]]2[qp]

jwcnjwcnemguemgu

5
vkskkkcuqaqaqauuisissxjesxjewqwqwqbbgz2[fm]1[3[tama]2[xyk]3[j]2[rp]1[af]]3[3[atp]]1[3[jzs]3[cah]2[o]3[sfmr]2[lp]3[v]]2[2[u]3[ah]]3[ydrr]
vkskkkcuqaqaqauuisissxjesxjewqwqwqbbgz2[rgr]1[x]3[1[ded]]1[1[qx]2[ang]]1[wx]
vkskkkcuqaqaqauuisissxjesxjewqwqwqbbgz1[3[qif]3[we]3[ljt]2[rlps]3[i]]
1[vks]3[k]1[cu]1[3[qa]2[u]2[is]2[sxje]3[wq]1[bbgz]]3[1[xfob]]2[s]3[h]2[2[fz]3[qs]]1[jxrf]2[ze]
1[vks]3[k]1[cu]1[3[qa]2[u]2[is]2[sxje]3[wq]1[bbgz]]3[fe]3[2[hbll]3[jvt]]2[eca]

vkskkkcuqaqaqauuisissxjesxjewqwqwqbbgz
 */
