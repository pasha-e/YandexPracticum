/*
 https://contest.yandex.ru/contest/24414/run-report/113443342/
 */
/*
 -- ПРИНЦИП РАБОТЫ --
    Хэш-таблица - это коллекция элементов, которые сохраняются таким образом, чтобы позже их было легко найти. 
    Её струкрута это произвольная коллекция ассоциаций (хэш функций)  между уникальными ключами и соответсвующими значениями
    Реализуем свой вариант хэш таблицы, используя 2 массива. 
    Один массив будет содержать ключи, другой - значения. И реализуем функциональность их взаимосвязи.

    Данные у нас числовые, поэтому хэщ функция будет самая простая - модульная (остаток отделения)
    Данный вариант быстрый, но может порождать коллизии.  Решать их будем с помощью линейного пробирование и повторного хеширования
    (спасибо http://aliev.me/runestone/SortSearch/Hashing.html  тут написано гораздо понятнее чем в курсе)

    Линейное пробирование методом посторного хеширования - при возникновении коллизии будем пересчитывать хэщ функцию линейно увеличивая её,
    пока ен будет найдет слот для записи. 
    
       
   -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
    Возникновение коллизий обычное дело в хэш-таблицах. В данной реализации при возникновении повторного хэша, мы будем линейно увелчивать и 
    перевычислять хэш, до тех пор пока не будет найдёт свободный слот. Этот метод называется метод резрешений коллизий открытой адрессацией.
    
       
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
   
    В идеальном случае поиск происходит за константное время O(1) - вычисление хэша -> переход
    В максимально плохом случае с постоянными колизиями, когда все данные находятся в одном диапазоне и хэши будут совпадать,
    поиск может свестись к линейному O(n)

    В среднем O(n),  в вырожденном плохом O(n)
       
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
   
    Зависит от максимально выбранного размера таблицы, _size,  т.е. O(_size)
      
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;


public class HashTable
{
    private static int _size = 1009;

    private static int?[] _data; // массив данных

    private static int?[] _slots; // массив ключей

    public  HashTable(int n)
    {
        _size = GetSize(n);

        _data = new int?[_size];

        _slots = new int?[_size];
    }

    /// <summary>
    /// подбор "на коленке" размера хеш-таблицы.
    /// будем брать первое простое число после очень приблизительно заданного размера входных посылок
    /// ооочень грубо можно прикинуть, что в наших тестах добавление и считывание будет примерно пополам- то нам этого должно хватить.
    /// но это не точно..
    /// но поскольку масштабирование таблицы нам не требуется ,  предположим что если возьмём с запасом то хватит )))
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    private int GetSize(int n)
    {
        if(n>0 && n<=10)
            return 11;
        if(n > 10 && n <=100) 
            return 101;
        if (n > 100 && n <= 1000)
            return 1009;
        if (n > 1000 && n <= 10000)
            return 10007;
        if (n > 10000 && n <= 50000)
            return 50021;
        if (n > 50000 && n <= 100000)
            return 100003;
        
        return 1000003; // по условию количество ключей не более 10^5..  это в 10 раз больше
    }

    /// <summary>
    /// добавление пары ключ-значение. Если заданный ключ уже есть в таблице, то соответствующее ему значение обновляется.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Put(int key, int? value)
    {
        var hashValue = Hash(key);

        //если слот пустой
        if (!_slots[hashValue].HasValue)
        {
            _slots[hashValue] = key;
            _data[hashValue] = value;
        }
        else 
        {
            // перезаписать (обновить) значение при одинаковом ключе
            if (_slots[hashValue] ==  key)
                _data[hashValue] = value;
            else
            {
                //поиск свободного слота
                var nextSlotHash = FindNextPosition(Rehash(hashValue), key);

                if (!_slots[nextSlotHash].HasValue)
                {
                    _slots[nextSlotHash] = key;
                    _data[nextSlotHash] = value;
                }
                else //перезаписать
                {
                    _data[nextSlotHash] = value;
                }
            }
        }
    }

    /// <summary>
    /// олучение значения по ключу. Если ключа нет в таблице, то вывести «None». Иначе вывести найденное значение. 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public int? Get(int key)
    {
        var positionHash = FindNextPosition(Hash(key), key);

        if (_slots[positionHash] == key)
            return _data[positionHash];

        return null ;
    }

    /// <summary>
    /// удаление ключа из таблицы. Если такого ключа нет, то вывести «None», иначе вывести хранимое по данному ключу значение и удалить ключ.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public int? Delete(int key)
    {
        var value = Get(key);

        //remove
        if (value.HasValue)
        {
            Put(key, null);

            var hash = FindNextPosition(Hash(key), key);

            _slots[hash] = null;
        }

        return value;
    }

    private int FindNextPosition(int positionHash, int key)
    {
        var tmp = key;
        while (_slots[positionHash].HasValue && _slots[positionHash] != key)
        {
            positionHash = Rehash(positionHash);
        }

        return positionHash;
    }

    private int Hash(int key)
    {
        return Modulus(key, _size);
    }

    private int Rehash(int oldhash)
    {
        return Modulus(oldhash + 1, _size);
    }

    /// <summary>
    /// моя реализия остатка от деления, для корректной работы с отрицательными числами
    /// в дотнете % работает не совсем так как надо в этом случае
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private int Modulus(int a, int b)
    {
        int c = (int)Math.Floor((double)a / b);

        return a - c * b;
    }

}

public class Final2HashTable
{
    
    private static TextReader reader;
    private static TextWriter writer;

    private static HashTable _hashTable;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());


        var n = ReadInt();

        List<List<string>> commandList = new List<List<string>>();

        for (int i = 0; i < n; i++)
        {
            var command = ReadStrList();

            commandList.Add(command);
        }

        _hashTable = new HashTable(n);

        foreach (var command in commandList)
        {
            ProcessCommand(command);
        }

        reader.Close();
        writer.Close();
    }

    private static void ProcessCommand(List<string> command)
    {
        string result = String.Empty;

        switch (command[0])
        {
            case "get":
            {
                var val = _hashTable.Get(Convert.ToInt32(command[1]));
                result = val.HasValue ? $"{val}" : "None";
                break;
            }
            case "put":
                _hashTable.Put(Convert.ToInt32(command[1]), Convert.ToInt32(command[2]));
                break;
            case "delete":
            {
                var val = _hashTable.Delete(Convert.ToInt32(command[1]));
                result = val.HasValue ? $"{val}" : "None";
                break;
            }
            default:
                result = "unknown command";
                break;
        }

        if(!String.IsNullOrEmpty(result))
            writer.WriteLine(result);

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

}


/*
6
put 1 1
put 2 2
get 1
get 2
delete 1
get 1

----------
15
   put 20 27
   get 20
   put 20 21
   get 20
   get 20
   get -1
   get 20
   get -3
   delete 20
   get -29
   get -33
   delete -29
   get 16
   get 14
   put 29 39

27
   21
   21
   None
   21
   None
   21
   None
   None
   None
   None
   None

----------------------------

15
   get 31
   get -34
   get 24
   delete 11
   delete 36
   delete 21
   get 29
   get -30
   put -7 6
   put -7 -26
   put -7 6
   get -7
   get -7
   get -7
   get -7


None
   None
   None
   None
   None
   None
   None
   None
   6
   6
   6
   6
--------------------------------

15
   get 9
   get 37
   get 30
   get -18
   get -5
   put 15 23
   delete 15
   get 7
   put 3 18
   get 3
   put 19 -17
   get -12
   get 19
   get -39
   get 39


None
   None
   None
   None
   None
   23
   None
   18
   None
   -17
   None
   None

---------------------------------
 */