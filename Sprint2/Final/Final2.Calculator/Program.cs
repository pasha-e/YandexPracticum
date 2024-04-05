/* 
    https://contest.yandex.ru/contest/22781/run-report/111407828/
*/

/*
   
   -- ПРИНЦИП РАБОТЫ --
    Преобразование инфиксных выражений в постфиксные (польская нотация) важная составляющая в парсинге и вычислении арифметических выражений.
    Как правидо это делат с помощью алгорита Дейкстры (но здесь там этого не требуется, входные данные сразу с постфиксной записи).
    
    Постфиксная форма записи гораздо проще для алгоритмического решения.
    
    Алгоритм реализуется на стеке операндов, и анализе операторов.
    * считываем данные
    * если это операнд - кладём его в стек
    * если это оператор - снимаем со стека 2 операнда и  выполняем действия над ними
    * результат операции кладём в стек
    * повторяем действия пока есть входные данные
 
     
   -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
    Честно говоря тут мне сложновато чтото написать.. 
    Алгоритм корректно преобразовывает входные данные в результат.
   
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
    Добавление и извлечение из контейнера (стека) стоит O(1).
    Значит сложность завит только от количества операций во входных данных
    Можно предположить что в среднем в выражении поровну операндов и знаков операций. 
    Значит количество операций на стеке равно O(n/2) + O(n/2), т.е положить операнды на стек и снять из отттуда
    Значит врменная сложность алгоритма равна  O(n)
       
   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
   Алгоритм реализован на стеке, в худшем случаем когда мы сперва положим все данные и потом снимем их мы используем памяти под количество входа , т.е. О(n)
   
   */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Final2
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var list = ReadList();

        try
        {
            writer.WriteLine(CalculateExpression(list));
        }
        catch (DivideByZeroException ex)
        {
            writer.Write($"Operation error: {ex.Message}");
        }
        catch (Exception ex)
        {
            writer.Write($"Invalid expression: {ex.Message}");
        }

        reader.Close();
        writer.Close();
    }

    /// <summary>
    /// разбор выражения и его вычисление
    /// </summary>
    /// <param name="expressionList">список лексем</param>
    /// <returns>результат вычисления</returns>
    /// <exception cref="Exception"></exception>
    private static int CalculateExpression(List<string> expressionList)
    {
        Stack<int> operandsStack = new Stack<int>();

        string posibleOperators = "+-*/";

        foreach (var symbol in expressionList)
        {
            if (Int32.TryParse(symbol, out var operand))
            {
                operandsStack.Push(operand);
                continue;
            }

            if (posibleOperators.Contains(symbol))
            {
                var secondOperand = GetOperand(operandsStack);
                var firstOperand = GetOperand(operandsStack);

                var result = CalculateOperation(symbol, firstOperand, secondOperand);

                operandsStack.Push(result);
            }
            else
            {
                throw new Exception("Unknown operand.");
            }
        }

        if (operandsStack.Count == 0)
            throw new Exception("Operand stack is empty.");

        return operandsStack.Pop();
    }

    private static int GetOperand(Stack<int> operandsStack)
    {
        if (operandsStack.Count == 0)
            throw new Exception("Operand stack is empty.");

        return operandsStack.Pop();
    }

    private static int CalculateOperation(string @operator, int firstOperand, int secondOperand )
    {
        var result = 0;

        switch (@operator)
        {
            case "+":
                result = firstOperand + secondOperand;
                break;
            case "-":
                result = firstOperand - secondOperand;
                break;
            case "*":
                result = firstOperand * secondOperand;
                break;
            case "/":
                if (secondOperand == 0)
                    throw new DivideByZeroException("Division by zero.");

                result = (int)Math.Floor((double)firstOperand / secondOperand);

                break;
        }

        return result;
    }

    private static List<string> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}

public class Stack<TValue>
{
    private List<TValue> _items;

    public Stack()
    {
        _items = new List<TValue>();
    }

    public void Push(TValue item)
    {
        _items.Add(item);
    }

    public TValue Pop()
    {
        TValue lastItem = _items[_items.Count - 1];
        _items.RemoveAt(_items.Count - 1);
        return lastItem;
    }

    public TValue Peek
    {
        get {return _items[_items.Count - 1]; }
    }

    public int Count
    {
        get { return _items.Count; }
    }
}