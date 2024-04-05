/*
https://contest.yandex.ru/contest/22781/run-report/111336521/
*/
/*

   -- ПРИНЦИП РАБОТЫ --
    Я реализовал деку на массиве с использованием кольцевого буфера.
    Кольцевой буфер реализован через два индекса указывающих на начало и конец очереди.
    При добавлении элемента в начало/хвост дека  проверяется переход указателя крайние положения массива
    
    При снятии элементов контейнер проверяется на пустоту.
   
   -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
    С использованием массива можно реализовать только деку ограниченной длины, которая вместит не более n элементов
    Но по условиям задачи нам этого достаточно
    Дека должна позволять добавлять и снимать элементы как с начала контейнера, так и с конца
    Реализация контейнера на массиве позволяет нам это делать через индекс за О(1)

    Реализация контейнера на массиве накладывкет ограничения на размер контейнера (он фиксированный),
    зато операции на массиве быстрые.
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
   Добавление в контейнер стоит O(1), потому что добавление в массив не требует сдвигов и стоит O(1).
   
   Извлечение из контейнера стоит  O(1), потому что обращение в массиве по индексу стоит О(1).
     
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
   Поскольку контейнер реализован на массиве фиксированной длинны, то память ограничена этим размером max_size

   Поэтому и моя дека будет потреблять O(max_size)= O(n) памяти.

*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Schema;

public class Final1
{
    private static TextReader reader;
    private static TextWriter writer;

    private static Deque _operationDeque;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var size = ReadInt();
        var maxSize = ReadInt();

        string[] commandsArr = new string[size];

        for (int i = 0; i < size; i++)
        {
            var commandLine = reader.ReadLine();

            commandsArr[i] = commandLine;
        }

        try
        {
            OperateDeque(maxSize, commandsArr);
        }
        catch (Exception ex)
        {
            writer.Write($"Exception : {ex.Message}");
        }
        
        reader.Close();
        writer.Close();
    }

    /// <summary>
    /// обработать набор команд на деке
    /// </summary>
    /// <param name="maxSize">макс размер деки</param>
    /// <param name="commandsArr">набор команд ля выплнения</param>
    private static void OperateDeque(int maxSize, string[] commandsArr)
    {
        _operationDeque = new Deque(maxSize);

        foreach (var commandStr in commandsArr)
        {
            var commandList = commandStr.Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries).ToList();

            ParseAndExecuteCommand(commandList);
        }
    }

    /// <summary>
    /// разобрать и выполнить строковую команду
    /// </summary>
    /// <param name="commandList"></param>
    /// <exception cref="Exception"></exception>
    private static void ParseAndExecuteCommand(List<string> commandList)
    {
        switch (commandList[0])
        {
            case "push_back":
            {
                if (Int32.TryParse(commandList[1], out var num))
                {
                    if(!_operationDeque.PushBack(num))  
                        writer.WriteLine("error");
                }
                else
                    throw new Exception("Incorrect format input data");
            }
                break;
            case "push_front":
            {
                if (Int32.TryParse(commandList[1], out var num))
                {
                    if(!_operationDeque.PushFront(num))
                        writer.WriteLine("error");
                }
                else
                    throw new Exception("Incorrect format input data");
            }
                break;
            case "pop_front":
            {
                var num = _operationDeque.PopFront();
                if (num.HasValue)
                    writer.WriteLine(num);
                else
                    writer.WriteLine("error");
            }
                break;
            case "pop_back":
            {
                var num = _operationDeque.PopBack();
                if (num.HasValue)
                    writer.WriteLine(num);
                else
                    writer.WriteLine("error");
            }
                break;
            default:
                throw new Exception("Unknown command");
        }

    }
    
    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}

/// <summary>
/// реализация деки на кольцевом буфере
/// </summary>
public class Deque
{
    private int[] _deque; // представление данных в очереди в виде массива для обеспечения доступа по индексу за O(1)
    private int _head; // индекс головы
    private int _tail;  // индекс хвоста
    private readonly int _maxSize; // допуститимая максимальная ёмкость
    private int _size; // текущая ёмкость

    public Deque(int maxSize)
    {
        _deque = new int[maxSize];
        _head = 0;
        _tail = 0;
        _maxSize = maxSize;
        _size = 0;
    }

    /// <summary>
    /// положить элемент на хвост
    /// <param name="num"></param>
    /// <returns>true - корректное выполнение, false - объем данных достиг максимального размер, добавление невозможно </returns>
    public bool PushBack(int num)
    {
        if (_size == _maxSize)
            return false;

        _deque[_tail] = num;
        _tail = (_tail + 1) % _maxSize;
        _size += 1;
    
        return true;
    }

    /// <summary>
    /// положить элемент в начало деки
    /// <param name="num"></param>
    /// <returns>true - корректное выполнение, false - объем данных достиг максимального размер, добавление невозможно </returns>
    public bool PushFront(int num)
    {
        if (_size == _maxSize)
            return false;


        //обработка перехода через 0
        if (_head != 0)
            _head = (_head - 1) % _maxSize;
        else
            _head = (_maxSize - 1) % _maxSize;

        _deque[_head] = num;
        
        _size += 1;

        return true;
    }

    /// <summary>
    /// снять элемент с хвоста
    /// </summary>
    /// <returns>null - дека пуста, снимать нечего, value - элемент</returns>
    public int? PopBack()
    {
        if (IsEmpty())
        {
            return null;
        }
        
        //обработка перехода через 0
        if(_tail != 0)
            _tail = (_tail - 1) % _maxSize;
        else
        {
            _tail = (_maxSize - 1) % _maxSize;
        }

        int x = _deque[_tail];
        _deque[_tail] = 0;

        //_tail = (_tail - 1) % _maxSize;
        _size -= 1;

        return x;
    }

    /// <summary>
    /// снять элемент с начала деки
    /// </summary>
    /// <returns>null - дека пуста, снимать нечего, value - элемент</returns>
    public int? PopFront()
    {
        if (IsEmpty())
        {
            return null;
        }

        int x = _deque[_head];
        _deque[_head] = 0;
        _head = (_head + 1) % _maxSize;
        _size -= 1;

        return x;
    }

    /// <summary>
    /// проверка деки на отсутсвие элементов
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return _size == 0;
    }
}