# YandexPracticum

Курс ["Алгоритмы и структуры данных"](https://practicum.yandex.ru/algorithms/)

Мои примеры решения задач на .NET (C#)

## Trial tasks

[contest.yandex.ru](https://contest.yandex.ru/contest/26365/problems/)

---

## Sprint 1. Введение в алгоритмы

[contest.yandex.ru](https://contest.yandex.ru/contest/22449/problems/)

---

<details>
  <summary> <b>Финальные задачи</b> <a href="https://contest.yandex.ru/contest/22450/problems/">contest.yandex.ru</a> </summary>

  ---

  <details><summary><b>Ближайший ноль(<a href="/Sprint1/Final/Sprint1FinalNearZero/Sprint1Final1NearestZero.cs">NearestZero</a>)</b></summary>

Тимофей ищет место, чтобы построить себе дом. Улица, на которой он хочет жить, имеет длину n, то есть состоит из n одинаковых идущих подряд участков. Каждый участок либо пустой, либо на нём уже построен дом.<br>
Общительный Тимофей не хочет жить далеко от других людей на этой улице. Поэтому ему важно для каждого участка знать расстояние до ближайшего пустого участка. Если участок пустой, эта величина будет равна нулю — расстояние до самого себя.<br>
Помогите Тимофею посчитать искомые расстояния. Для этого у вас есть карта улицы. Дома в городе Тимофея нумеровались в том порядке, в котором строились, поэтому их номера на карте никак не упорядочены. Пустые участки обозначены нулями.

#### Формат ввода
В первой строке дана длина улицы —– n (1 ≤ n ≤ 10^6). В следующей строке записаны n целых неотрицательных чисел — номера домов и обозначения пустых участков на карте (нули). Гарантируется, что в последовательности есть хотя бы один ноль. Номера домов (положительные числа) уникальны и не превосходят 10^9.

#### Формат вывода
Для каждого из участков выведите расстояние до ближайшего нуля. Числа выводите в одну строку, разделяя их пробелами.

#### Пример
| Ввод | Вывод |
| ---- | ----- |
| 5<br>0 1 4 9 0 | 0 1 2 1 0 |
| 6<br>0 7 9 4 8 20 | 0 1 2 3 4 5 |

</details>

---

<details><summary><b>Ловкость рук (<a href="/Sprint1/Final/Sprint1Final2DeftHands/Sprint1Final2DeftHands.cs">DeftHands.cs</a>)</b></summary>

«Тренажёр для скоростной печати» представляет собой квадратную клавиатуру из шестнадцати клавиш размером 4x4. На каждой клавише может быть изображена либо точка, либо цифра от 1 до 9.<br>
Занятие на тренажёре делится на раунды:
- каждый раунд состоит из нескольких игр;
- в разных раундах число игр может быть разным;
- номер каждой игры в раунде обозначается счётчиком t.

Для каждого раунда на клавишах устанавливаются определённые значения, которые остаются неизменными в течение всех игр раунда.

![](https://contest.yandex.ru/testsys/statement-image?imageId=89e2d9d263b4cf6c2d2d4a1b4b2de1149705669414ca828603a7a6fbadf42931)

Значение счётчика игр t не может превысить значение самого большого числа, отображённого на клавиатуре в текущем раунде.<br>
В упражнении на тренажёре принимают участие два игрока, они играют вдвоём на одной клавиатуре. Для каждого раунда устанавливается максимальное число клавиш, которые может нажать один игрок (оно обозначается переменной k и не изменяется в течение раунда).<br>
В каждой отдельной игре участники должны вместе нажать на клавиши, на которых изображена цифра, соответствующая номеру игры t. Например, во второй игре раунда игроки должны нажать все те клавиши, на которых изображена двойка.<br>
В раунде могут быть игры, где не требуется нажимать кнопки: например, в приведённом варианте раунда в играх от t = 4 до t = 8 кнопки нажимать не потребуется: на клавиатуре нет цифр от 4 до 8:

![](https://contest.yandex.ru/testsys/statement-image?imageId=99651ae7826ea95ee117dc6f037e8daf6622596ca41408697faa167236980a69)

Если в очередной игре у участников есть возможность нажать все необходимые клавиши — они их нажимают и получают 1 балл.<br>
Предположим, что для раунда задан набор кнопок, как на картинке, и k = 3 (каждый из участников может нажать не более трёх кнопок). Тогда во второй игре (t = 2), где должны быть нажаты двойки, игроки вдвоём смогут нажать только 6 клавиш (k * 2 = 6). Но на клавиатуре семь двоек; участники не смогут нажать их все и не получат балл.

![](https://contest.yandex.ru/testsys/statement-image?imageId=0225c36c4597bc5bb220fa59fe0d179ee2735adf3dc7be36124b9073381b7495)

Напишите программу, которая будет принимать данные для определённого раунда:
- значение k,
- значения для кнопок,

и вычислит количество баллов, которое будут заработано в этом раунде.

#### Формат ввода
В первой строке дано целое число k (1 ≤ k ≤ 5).<br>
В четырёх следующих строках заданы значения для кнопок –— по 4 символа в каждой строке. Каждый символ —– либо точка, либо цифра от 1 до 9. Символы одной строки идут подряд и не разделены пробелами.

#### Формат вывода
Выведите единственное число –— количество баллов, которое игроки наберут в раунде.

#### Пример
| Ввод | Вывод |
| ---- | ----- |
| 3<br>1231<br>2..2<br>2..2<br>2..2<br> | 2 |
| 4<br>1111<br>9999<br>1111<br>9911<br> | 1 |
| 4<br>1111<br>1111<br>1111<br>1111<br> | 0 |

</details>
</details>

---

## Sprint 2. Основные структуры

[contest.yandex.ru](https://contest.yandex.ru/contest/22779/problems/)

---

<details>
  <summary> <b>Финальные задачи</b> <a href="https://contest.yandex.ru/contest/22781/problems/">contest.yandex.ru</a> </summary>

  ---

<details>
<summary>
<b>Дек (<a href="/Sprint2/Final/Final1.Deque/Program.cs">Deque.cs</a>)</b>
</summary>

#### Условие

Гоша реализовал структуру данных Дек, максимальный размер которого определяется заданным числом. 
Методы `push_back(x)`, `push_front(x)`, `pop_back()`, `pop_front()` работали корректно. 
Но, если в деке было много элементов, программа работала очень долго. 
Дело в том, что не все операции выполнялись за O(1). 
Помогите Гоше! Напишите эффективную реализацию.

**Внимание: при реализации нельзя использовать связный список.**

#### Формат ввода
В первой строке записано количество команд n — целое число, не превосходящее 100000. Во второй строке записано число m — максимальный размер дека. Он не превосходит 50000. В следующих n строках записана одна из команд:

* `push_back(value)` – добавить элемент в конец дека. Если в деке уже находится максимальное число элементов, вывести «error».
* `push_front(value)` – добавить элемент в начало дека. Если в деке уже находится максимальное число элементов, вывести «error».
* `pop_front()` – вывести первый элемент дека и удалить его. Если дек был пуст, то вывести «error».
* `pop_back()` – вывести последний элемент дека и удалить его. Если дек был пуст, то вывести «error».
`value` — целое число, по модулю не превосходящее 1000.

#### Формат вывода
Выведите результат выполнения каждой команды на отдельной строке. 
Для успешных запросов `push_back(x)` и `push_front(x)` ничего выводить не надо.

#### Пример
<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
4<br>
4<br>
push_front 861<br>
push_front -819<br>
pop_back<br>
pop_back<br>

</td>
    <td valign="top">
861<br>
-819<br>

</td>
  </tr>
</tbody></table>

</details>

---

<details>
<summary>
<b>Калькулятор (<a href="Sprint2/Final/Final2.Calculator/Program.cs">Calculator.cs</a>)</b>
</summary>

#### Условие
Задание связано с обратной польской нотацией. 
Она используется для парсинга арифметических выражений. 
Еще её иногда называют постфиксной нотацией.

В постфиксной нотации операнды расположены перед знаками операций.

**Пример:**

10 2 4 * 

означает 10 - 2 * 4 и равно 2

Разберём последний пример подробнее:

Знак * стоит сразу после чисел 2 и 4, значит к ним нужно применить операцию, которую этот знак обозначает, то есть перемножить эти два числа. В результате получим 8.

После этого выражение приобретёт вид:

10 8 -

Операцию «минус» нужно применить к двум идущим перед ней числам, то есть 10 и 8. В итоге получаем 2.

Рассмотрим алгоритм более подробно. Для его реализации будем использовать стек.

Для вычисления значения выражения, записанного в обратной польской нотации, 
нужно считывать выражение слева направо и придерживаться следующих шагов:

1. Обработка входного символа:
Если на вход подан операнд, он помещается на вершину стека.
Если на вход подан знак операции, то эта операция выполняется над требуемым количеством значений, взятых из стека в порядке добавления. Результат выполненной операции помещается на вершину стека.
2. Если входной набор символов обработан не полностью, перейти к шагу 1.
3. После полной обработки входного набора символов результат вычисления выражения находится в вершине стека. Если в стеке осталось несколько чисел, то надо вывести только верхний элемент.

**Замечание про отрицательные числа и деление:** 
в этой задаче под делением понимается математическое целочисленное деление. 
Это значит, что округление всегда происходит вниз. 
А именно: если a / b = c, то b ⋅ c — это наибольшее число, 
которое не превосходит a и одновременно делится без остатка на b.

Например, -1 / 3 = -1. Будьте осторожны: в C++, Java и Go, например, деление чисел работает иначе.

В текущей задаче гарантируется, что деления на отрицательное число нет.

#### Формат ввода
В единственной строке дано выражение, записанное в обратной польской нотации. Числа и арифметические операции записаны через пробел.

На вход могут подаваться операции: +, -, *, / и числа, по модулю не превосходящие 10000.

Гарантируется, что значение промежуточных выражений в тестовых данных по модулю не больше 50000.

#### Формат вывода
Выведите единственное число — значение выражения.

#### Пример
<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
2 1 + 3 *

</td>
    <td valign="top">
9

</td>
  </tr>
</tbody></table>

</details>

  
</details>

---

## Sprint 3. Рекурсия и сортировки 

[contest.yandex.ru](https://contest.yandex.ru/contest/23638/problems/)

---

<details>
<summary>
<b>А. Генератор скобок (<a href="Sprint3/A.BracketGenerator/Program.cs">BracketGenerator.cs</a>)</b>
</summary>

#### Условие
Рита по поручению Тимофея наводит порядок в правильных скобочных последовательностях (ПСП),
состоящих только из круглых скобок (). 
Для этого ей надо сгенерировать все ПСП длины 2n в алфавитном порядке —– 
алфавит состоит из ( и ) и открывающая скобка идёт раньше закрывающей.

Помогите Рите —– напишите программу, 
которая по заданному n выведет все ПСП в нужном порядке.


Рассмотрим второй пример. Надо вывести ПСП из четырёх символов. Таких всего две:

* (())
* ()()

(()) идёт раньше ()(), так как первый символ у них одинаковый, а на второй позиции у первой ПСП стоит (, который идёт раньше ).

#### Формат ввода
На вход функция принимает n — целое число от 0 до 10.

#### Формат вывода
Функция должна напечатать все возможные скобочные последовательности заданной длины в алфавитном (лексикографическом) порядке.

#### Пример
<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
3<br>

</td>
    <td valign="top">
((()))<br>
(()())<br>
(())()<br>
()(())<br>
()()()<br>

</td>
  </tr>
</tbody></table>

</details>

---

<details>
<summary>
<b>B. Комбинации (<a href="Sprint3/B.Combinations/Program.cs">Combinations.cs</a>)</b>
</summary>

#### Условие
На клавиатуре старых мобильных телефонов каждой цифре соответствовало несколько букв. 

Примерно так:
2:'abc',
3:'def',
4:'ghi',
5:'jkl',
6:'mno',
7:'pqrs',
8:'tuv',
9:'wxyz'

Вам известно в каком порядке были нажаты кнопки телефона, без учета повторов. 
Напечатайте все комбинации букв, которые можно набрать такой последовательностью нажатий.

#### Формат ввода
На вход подается строка, состоящая из цифр 2-9 включительно. Длина строки не превосходит 10 символов.

#### Формат вывода
Выведите все возможные комбинации букв через пробел.

#### Пример
<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
23<br>

</td>
    <td valign="top">
ad ae af bd be bf cd ce cf<br>

</td>
  </tr>
</tbody></table>

</details>

---

<details>
  <summary> <b>Финальные задачи</b> <a href="https://contest.yandex.ru/contest/23815/problems/">contest.yandex.ru</a> </summary>

  ---
 
<details>
<summary>
<b>Поиск в сломанном массиве (<a href="/Sprint3/Final/Final1.BrokenArraySearch/Program.cs">BrokenArraySearch.cs</a>)</b>
</summary>

#### Условие
Алла ошиблась при копировании из одной структуры данных в другую. 
Она хранила массив чисел в кольцевом буфере. 
Массив был отсортирован по возрастанию, 
и в нём можно было найти элемент за логарифмическое время. 
Алла скопировала данные из кольцевого буфера в обычный массив, 
но сдвинула данные исходной отсортированной последовательности. 
Теперь массив не является отсортированным. 
Тем не менее нужно обеспечить возможность находить в нем элемент за O(log n).
Можно предполагать, что в массиве только уникальные элементы.

#### Формат ввода
Функция принимает массив натуральных чисел и искомое число k. 
Длина массива не превосходит 10000. 
Элементы массива и число k не превосходят по значению 10000.

В примерах:
В первой строке записано число n — длина массива.
Во второй строке записано положительное число k — искомый элемент. 
Далее в строку через пробел записано n натуральных чисел – элементы массива.

#### Формат вывода
Функция должна вернуть индекс элемента, равного k, 
если такой есть в массиве (нумерация с нуля). 
Если элемент не найден, функция должна вернуть − 1.
Изменять массив нельзя.

#### Пример
<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
9<br>
5<br>
19 21 100 101 1 4 5 7 12<br>

</td>
    <td valign="top">
6

</td>
  </tr>
</tbody></table>

</details>

---

<details>
<summary>
<b>Эффективная быстрая сортировка (<a href="Sprint3/Final/Final2.EffectiveQuickSort/Program.cs">Final2.EffectiveQuickSort.cs</a>)</b>
</summary>

#### Условие
Тимофей решил организовать соревнование по спортивному программированию, 
чтобы найти талантливых стажёров. 
Задачи подобраны, участники зарегистрированы, тесты написаны. 
Осталось придумать, как в конце соревнования будет определяться победитель.


Каждый участник имеет уникальный логин. 
Когда соревнование закончится, к нему будут привязаны два показателя: 
количество решённых задач P_i и размер штрафа F_i. 
Штраф начисляется за неудачные попытки и время, затраченное на задачу.


Тимофей решил сортировать таблицу результатов следующим образом: 
при сравнении двух участников выше будет идти тот, у которого решено больше задач. 
При равенстве числа решённых задач первым идёт участник с меньшим штрафом. 
Если же и штрафы совпадают, то первым будет тот, 
у которого логин идёт раньше в алфавитном (лексикографическом) порядке.


Тимофей заказал толстовки для победителей и накануне поехал за ними в магазин. 
В своё отсутствие он поручил вам реализовать алгоритм быстрой сортировки (англ. quick sort) для таблицы результатов. Так как Тимофей любит спортивное программирование и не любит зря расходовать оперативную память, то ваша реализация сортировки не может потреблять O(n) дополнительной памяти для промежуточных данных (такая модификация быстрой сортировки называется "in-place").


**Как работает in-place quick sort**

Как и в случае обычной быстрой сортировки, которая использует дополнительную память, 
необходимо выбрать опорный элемент (англ. pivot), а затем переупорядочить массив.
Сделаем так, чтобы сначала шли элементы, не превосходящие опорного, а затем —– большие опорного.


Затем сортировка вызывается рекурсивно для двух полученных частей. 
Именно на этапе разделения элементов на группы в обычном алгоритме используется дополнительная память. 
Теперь разберёмся, как реализовать этот шаг in-place.

Пусть мы как-то выбрали опорный элемент. Заведём два указателя left и right, 
которые изначально будут указывать на левый и правый концы отрезка соответственно. 
Затем будем двигать левый указатель вправо до тех пор, пока он указывает на элемент, 
меньший опорного. Аналогично двигаем правый указатель влево, пока он стоит на элементе,
превосходящем опорный. 
В итоге окажется, что левее от left все элементы точно принадлежат первой группе, 
а правее от right — второй. Элементы, на которых стоят указатели, нарушают порядок. 
Поменяем их местами (в большинстве языков программирования используется функция swap()) 
и продвинем указатели на следующие элементы. 
Будем повторять это действие до тех пор, пока left и right не столкнутся.

#### Формат ввода
В первой строке задано число участников n, 1 ≤ n ≤ 100 000.
В каждой из следующих n строк задана информация про одного из участников.
i-й участник описывается тремя параметрами:

* уникальным логином (строкой из маленьких латинских букв длиной не более 20)
* числом решённых задач P_i
* штрафом Fi

Fi и Pi — целые числа, лежащие в диапазоне от 0 до 10^9.

#### Формат вывода
Для отсортированного списка участников выведите по порядку их логины по одному в строке.

#### Пример
<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
5<br>
alla 4 100<br>
gena 6 1000<br>
gosha 2 90<br>
rita 2 90<br>
timofey 4 80<br>

</td>
    <td valign="top">
gena<br>
timofey<br>
alla<br>
gosha<br>
rita<br>

</td>
  </tr>
</tbody></table>

</details>

</details>

---
## Sprint 4. Хэш-функции

[contest.yandex.ru](https://contest.yandex.ru/contest/23991/problems/)

---

<details>
  <summary> <b>Финальные задачи</b> <a href="https://contest.yandex.ru/contest/24414/problems/">contest.yandex.ru</a> </summary>

  ---

 <details>
<summary>
<b>Поисковая система (<a href="Sprint4/Final/Final1.SearchSystem/Program.cs">SearchSystem.cs</a>)</b>
</summary>

#### Условие
Тимофей пишет свою поисковую систему.

Имеется n документов, каждый из которых представляет собой текст из слов. 
По этим документам требуется построить поисковый индекс. 
На вход системе будут подаваться запросы. 
Запрос —– некоторый набор слов. 
По запросу надо вывести 5 самых релевантных документов.

Релевантность документа оценивается следующим образом: 
для каждого уникального слова из запроса берётся число его вхождений в документ, 
полученные числа для всех слов из запроса суммируются. 
Итоговая сумма и является релевантностью документа. 
Чем больше сумма, тем больше документ подходит под запрос.

Сортировка документов на выдаче производится по убыванию релевантности. 
Если релевантности документов совпадают —– то по возрастанию их порядковых номеров в базе 
(то есть во входных данных).

#### Формат ввода
В первой строке дано натуральное число n —– количество документов в базе (1 ≤ n ≤ 104).

Далее в n строках даны документы по одному в строке. Каждый документ состоит из нескольких слов, 
слова отделяются друг от друга одним пробелом и состоят из маленьких латинских букв. 
Длина одного текста не превосходит 1000 символов. Текст не бывает пустым.

В следующей строке дано число запросов —– натуральное число m (1 ≤ m ≤ 104). 
В следующих m строках даны запросы по одному в строке. 
Каждый запрос состоит из одного или нескольких слов. 
Запрос не бывает пустым. 
Слова отделяются друг от друга одним пробелом и состоят из маленьких латинских букв. 
Число символов в запросе не превосходит 100.

#### Формат вывода
Для каждого запроса выведите на одной строке номера пяти самых релевантных документов. 
Если нашлось менее пяти документов, то выведите столько, сколько нашлось. 
Документы с релевантностью 0 выдавать не нужно.

#### Пример
<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
3<br>
i love coffee<br>
coffee with milk and sugar<br>
free tea for everyone<br>
3<br>
i like black coffee without milk<br>
everyone loves new year<br>
mary likes black coffee without milk<br>

</td>
    <td valign="top">
1 2<br>
3<br>
2 1<br>

</td>
  </tr>
</tbody></table>

<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
6<br>
buy flat in moscow<br>
rent flat in moscow<br>
sell flat in moscow<br>
want flat in moscow like crazy<br>
clean flat in moscow on weekends<br>
renovate flat in moscow<br>
1<br>
flat in moscow for crazy weekends<br>

</td>
    <td valign="top">
4 5 1 2 3<br>
</td>
  </tr>
</tbody></table>

<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
3<br>
i like dfs and bfs<br>
i like dfs dfs<br>
i like bfs with bfs and bfs<br>
1<br>
dfs dfs dfs dfs bfs<br>

</td>
    <td valign="top">
3 1 2<br>
</td>
  </tr>
</tbody></table>

</details>

---

<details>
<summary>
<b>Хеш-таблица (<a href="Sprint4/Final/Final2.HashTable/Program.cs">HashTable.cs</a>)</b>
</summary>

#### Условие
Тимофей, как хороший руководитель, 
хранит информацию о зарплатах своих сотрудников в базе данных и постоянно её обновляет. 
Он поручил вам написать реализацию хеш-таблицы, 
чтобы хранить в ней базу данных с зарплатами сотрудников.

Хеш-таблица должна поддерживать следующие операции: 

* `put key value` —– добавление пары ключ-значение. Если заданный ключ уже есть в таблице, то соответствующее ему значение обновляется. 
* `get key` –— получение значения по ключу. Если ключа нет в таблице, то вывести «None». Иначе вывести найденное значение. 
* `delete key` –— удаление ключа из таблицы. Если такого ключа нет, то вывести «None», иначе вывести хранимое по данному ключу значение и удалить ключ.

В таблице хранятся уникальные ключи.

Требования к реализации: 

* Нельзя использовать имеющиеся в языках программирования реализации хеш-таблиц 
(std::unordered_map в С++, dict в Python, HashMap в Java, и т. д.)
* Число хранимых в таблице ключей не превосходит 10^5.
* Разрешать коллизии следует с помощью метода цепочек или с помощью открытой адресации.
* Все операции должны выполняться за O(1) в среднем.
* Поддерживать рехеширование и масштабирование хеш-таблицы не требуется.
* Ключи и значения, id сотрудников и их зарплата, —– целые числа. Поддерживать произвольные хешируемые типы не требуется.

#### Формат ввода
В первой строке задано общее число запросов к таблице n (1≤ n≤ 106).

В следующих n строках записаны запросы, которые бывают трех видов –— `get`, `put`, `delete` 
—– как описано в условии.

Все ключи и значения –— целые неотрицательные числа, не превосходящие 10^9.

#### Формат вывода
На каждый запрос вида `get` и `delete` выведите ответ на него в отдельной строке.


#### Пример
<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
10<br>
get 1<br>
put 1 10<br>
put 2 4<br>
get 1<br>
get 2<br>
delete 2<br>
get 2<br>
put 1 5<br>
get 1<br>
delete 2<br>

</td>
    <td valign="top">
None<br>
10<br>
4<br>
4<br>
None<br>
5<br>
None<br>

</td>
  </tr>
</tbody></table>

</details>



</details>

---
## Sprint 5. Деревья

[contest.yandex.ru](https://contest.yandex.ru/contest/24809/problems/)

---

<details>
  <summary> <b>Финальные задачи</b> <a href="https://contest.yandex.ru/contest/24810/problems/">contest.yandex.ru</a> </summary>

  ---

  <details>
<summary>
<b>Пирамидальная сортировка (<a href="Sprint5/Final/Final1.HeapSort/Program.cs">HeapSort.cs</a>)</b>
</summary>

#### Условие
**В данной задаче необходимо реализовать сортировку кучей. 
При этом кучу необходимо реализовать самостоятельно, использовать имеющиеся в языке реализации нельзя. 
Сначала рекомендуется решить задачи про просеивание вниз и вверх.**

Тимофей решил организовать соревнование по спортивному программированию, 
чтобы найти талантливых стажёров. 
Задачи подобраны, участники зарегистрированы, тесты написаны. 
Осталось придумать, как в конце соревнования будет определяться победитель.


Каждый участник имеет уникальный логин. 
Когда соревнование закончится, к нему будут привязаны два показателя: 
количество решённых задач P_i и размер штрафа F_i. 
Штраф начисляется за неудачные попытки и время, затраченное на задачу.


Тимофей решил сортировать таблицу результатов следующим образом: 
при сравнении двух участников выше будет идти тот, у которого решено больше задач. 
При равенстве числа решённых задач первым идёт участник с меньшим штрафом. 
Если же и штрафы совпадают, то первым будет тот, 
у которого логин идёт раньше в алфавитном (лексикографическом) порядке.


Тимофей заказал толстовки для победителей и накануне поехал за ними в магазин. 
В своё отсутствие он поручил вам реализовать алгоритм сортировки кучей (англ. Heapsort) для таблицы результатов.

#### Формат ввода
В первой строке задано число участников n, 1 ≤ n ≤ 100 000.
В каждой из следующих n строк задана информация про одного из участников.
i-й участник описывается тремя параметрами:

* уникальным логином (строкой из маленьких латинских букв длиной не более 20)
* числом решённых задач P_i
* штрафом Fi

Fi и Pi — целые числа, лежащие в диапазоне от 0 до 10^9.

#### Формат вывода
Для отсортированного списка участников выведите по порядку их логины по одному в строке.

#### Пример
<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
5<br>
alla 4 100<br>
gena 6 1000<br>
gosha 2 90<br>
rita 2 90<br>
timofey 4 80<br>

</td>
    <td valign="top">
gena<br>
timofey<br>
alla<br>
gosha<br>
rita<br>

</td>
  </tr>
</tbody></table>

<table><tbody>
  <tr>
    <td><b>Ввод</b></td>
    <td><b>Вывод</b></td>
  </tr>
  <tr>
    <td valign="top">
5<br>
alla 0 0<br>
gena 0 0<br>
gosha 0 0<br>
rita 0 0<br>
timofey 0 0<br>

</td>
    <td valign="top">
alla<br>
gena<br>
gosha<br>
rita<br>
timofey<br>
</td>
  </tr>
</tbody></table>

</details>

---

<details>
<summary>
<b>Удали узел (<a href="Sprint5/Final/Final2.RemoveNode/Program.cs">RemoveNode.cs</a>)</b>
</summary>

#### Условие
Дано бинарное дерево поиска, в котором хранятся ключи. Ключи — уникальные целые числа. 
Найдите вершину с заданным ключом и удалите её из дерева так, чтобы дерево осталось корректным бинарным деревом поиска. 
Если ключа в дереве нет, то изменять дерево не надо.
На вход вашей функции подаётся корень дерева и ключ, который надо удалить. 
Функция должна вернуть корень изменённого дерева. 
Сложность удаления узла должна составлять O(h), где h –— высота дерева.
Создавать новые вершины (вдруг очень захочется) нельзя.

#### Формат ввода
Ключи дерева – натуральные числа. 
В итоговом решении не надо определять свою структуру/свой класс, описывающий вершину дерева.


</details>

  ---

</details>

---
