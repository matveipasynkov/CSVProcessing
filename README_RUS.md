# CSVProcessing
Это мой второй проект, который был задан в качестве домашнего задания в вузе. Консольное приложение хранится в KDZ_Program, библиотека классов в LibraryOfProcessing

## Основное задание
Разработать решение, содержащие проект консольного приложения и библиотеку классов,
включающую статические классы для работы с данными CSV-файла.

## Консольное приложение 
#### 1. Запросить у пользователя абсолютный путь к файлу с csv-данными (station-rate.csv). Для получения данных из файла использовать метод Read класса CsvProcessing из библиотеки классов.

#### 2. После получения данных из файла предоставить пользователю экранное меню, пункты которого отвечают за манипуляции с файлом и его данными:
   
	a. выборка по значениям полей NameOfStation, Line, NameOfStation и Month. Для организации выборки использовать методы класса DataProcessing из библиотеки классов. Конкретные значения полей для организации выборки получать от пользователя. Результат выводить на экран в табличном, читаемом виде. Если результат пуст, то оповещать пользователя.

	b. сортировка по значениям полей: Year по возрастанию, NameOfStation по алфавиту. Для организации сортировки использовать методы класса DataProcessing из библиотеки классов. Результат сортировки выводить на экран в табличном, читаемом виде.

	c. сохранение результатов выборок и сортировок в csv-файле при помощи перегруженных методов Write класса CsvProcessing (правила работы с содержимым файла уточнены в разделе «Библиотека классов»). Требуется использовать в работе обе перегрузки: для записи одной строки – одну, для записи массива строк – вторую. Структура файла, т.е. набор полей, должны быть идентичны исходному, включая заголовки. Разрабатываемое консольное приложение должно без ошибок загружать данные из любого созданного ей файла. Имя файла и необходимость сохранения данных запрашивать у пользователя после вывода данных на экран. Сохранять файл рядом с исполнимым файлом консольного приложения. Если пользователь указал некорректное имя файла, то оповещать его и запрашивать повторный ввод.

#### 3. Реализовать обработку всех исключительных ситуаций, которые могут возникать при работе с вызываемыми методами, включая методы разрабатываемой в рамках проекта библиотеки.

## Библиотека классов
#### 1. Класс CsvProcessing: содержит методы для чтения и записи данных в csv файл. Для хранения пути к файлу в классе использовать статическое поле fPath, к данным этого поля обращаются все методы:
	• Метод Read возвращает массив строк (string[]) файла, доступного по fPath. Если файл отсутствует, или его структура не соответствуют варианту, то метод выбрасывает исключение с типом ArgumentNullException.
	• Метод Write отвечает за запись данных в файл и имеет две перегрузки:
		- Метод с параметрами: строкой (string) и путём к новому файлу nPath. Метод дописывает (не стирая уже записанные в файл данные) в конец файла данные из параметра-строки после последней строки, если файл по nPath уже присутствует на диске. Если файл отсутствует, то он должен быть создан по указанному пути. Файлы, путь до которых указан некорректно, метод не создаёт, поэтому нужно самостоятельно реализовать вариант программного оповещения для вызывающего кода.
		- Метод с параметром массивом строк (string[]) записывает новые данные, переданные в параметре массиве строк в уже существующий по пути fPath файл, стирая его исходное содержимое. Если файл по пути fPath отсутствует, то он должен быть создан по указанному пути. Файлы, путь до которых указан некорректно, метод не создаёт, поэтому нужно самостоятельно реализовать вариант программного оповещения для вызывающего кода.
#### 2. Класс DataProcessing содержит методы для работы с данными, полученными из файла: методы получения выборок и методы сортировок по данным полей. Способы упорядочивания и столбцы для фильтрации:
	Фильтрация: NameOfStation, Line, NameOfStation и Month (то есть одновременно по двум столбцам).
	Сортировка: Year по возрастанию, NameOfStation по алфавиту.

## Требования по совместимости и качеству для основной задачи
	1) весь программный код должен быть написан на языке программирования C# с учётом использования .net 6.0;
	2) исходный код должен содержать комментарии, объясняющие неочевидные фрагменты и решения, резюме кода, описание целей кода (см. материалы лекции 1, модуль 1);
	3) использованные в программе идентификаторы должны соответствовать правилам и соглашениям об именовании идентификаторов C# (https://learn.microsoft.com/ruru/dotnet/csharp/fundamentals/coding-style/identifier-names);
	4) представленный к проверке код должен отвечать общим соглашениям о коде C# Microsoft (https://learn.microsoft.com/ru-ru/dotnet/csharp/fundamentals/coding-style/codingconventions); 
	5) при перемещении папки проекта библиотеки (копировании / переносе на другое устройство) файлы должны открываться программой также успешно, как и на компьютере создателя, т.е. по относительному пути;
	6) текстовые данные, включая данные на русском языке, успешно декодируются при представлении пользователю и человекочитаемы;
	7) программа не допускает пользователя до решения задач, пока с клавиатуры не будут введены корректные данные;
	8) консольное приложение обрабатывает исключительные ситуации, связанные (1) со вводом и преобразованием / приведением данных как с клавиатуры, так и из файлов; (2) с созданием, инициализацией, обращением к элементам массивов и строк; (3) вызовом методов библиотеки.
	9) представленная к проверке библиотека классов должна решать все поставленные задачи, успешно компилироваться.
	10) в качестве структур данных использовать только массивы (тип, производный от Array).
	11) для работы с csv-файлами запрещено использовать сторонние библиотеки и nuget-пакеты, код должен быть подготовлен самостоятельно.
	12) консольное приложение должно обрабатывать аварийные ситуации и содержать цикл повторения решения.
	13) каждый метод библиотеки может быть использован отдельно от кода консольного приложения, например, при вставке в другой проект и обращении к методам библиотеки из него по ссылке на библиотеку и указанной в задании сигнатуре метода.

## Дополнительные комментарии
В данных есть пропуски и пустые поля. Выводить на экран такие данные не нужно, но их требуется учитывать, если пропуски встречаются при сортировках или фильтрах. Например, размещать вначале или конце списка при сортировке.
