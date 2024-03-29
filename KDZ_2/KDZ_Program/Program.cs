class Program
{
    static void Main(string[] args)
    {
        bool stop_the_program = false; //флаг остановки программы, в случае введения команды 6 ("Выйти из программы") из меню.
        do
        {
            try
            {
                LibraryOfProcessing.CsvProcessing.GetPath(); //получаем путь от пользователя в начале и читаем файл.
                string[] data = LibraryOfProcessing.CsvProcessing.Read();

                Console.Clear();
                PrintMenu(); //выводим Меню (об этой команде будет сказано ниже при объявлении)

                bool flag = false;
                string command = "";

                while (!flag)
                {
                    Console.Write("Введите команду: ");
                    command = Console.ReadLine();

                    if (command == "1" | command == "2" | command == "3" | command == "4" | command == "5" | command == "6")
                    {
                        flag = true;
                    }
                    else
                    {
                        Console.Write("Введена неверная команда. Попробуйте ещё раз. ");
                    }
                }

                Console.Clear();

                if (command == "1") //прописываем, что делает код в случае каждой из команд.
                {
                    Console.Write("Введите значение NameOfStation: ");
                    string value = Console.ReadLine();

                    string[] result = LibraryOfProcessing.DataProcessing.OrganizeSample(data, "NameOfStation", value);

                    if (result.Length == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Выборка пустая.");
                        Console.WriteLine("Выполнено!");
                    }
                    else
                    {
                        PrintArray(result);
                        SaveTheResult(result);

                        Console.Clear();
                        Console.WriteLine("Выполнено!");
                    }
                }
                else if (command == "2")
                {
                    Console.Write("Введите значение Line: ");
                    string value = Console.ReadLine();

                    string[] result = LibraryOfProcessing.DataProcessing.OrganizeSample(data, "Line", value);

                    if (result.Length == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Выборка пустая.");
                        Console.WriteLine("Выполнено!");
                    }
                    else
                    {
                        PrintArray(result);
                        SaveTheResult(result);

                        Console.Clear();
                        Console.WriteLine("Выполнено!");
                    }
                }
                else if (command == "3")
                {
                    Console.Write("Введите значение NameOfStation: ");
                    string value_1 = Console.ReadLine();

                    Console.Write("Введите значение Month: ");
                    string value_2 = Console.ReadLine();

                    string[] result = LibraryOfProcessing.DataProcessing.OrganizeSample(data, "NameOfStation&Month", value_1, value_2);

                    if (result.Length == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Выборка пустая.");
                        Console.WriteLine("Выполнено!");
                    }
                    else
                    {
                        PrintArray(result);
                        SaveTheResult(result);

                        Console.Clear();
                        Console.WriteLine("Выполнено!");
                    }
                }
                else if (command == "4")
                {
                    string[] result = LibraryOfProcessing.DataProcessing.SortByValue(data, "Year");

                    if (result.Length == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Таблица пустая.");
                        Console.WriteLine("Выполнено!");
                    }
                    else
                    {
                        PrintArray(result);
                        SaveTheResult(result);

                        Console.Clear();
                        Console.WriteLine("Выполнено!");
                    }
                }
                else if (command == "5")
                {
                    string[] result = LibraryOfProcessing.DataProcessing.SortByValue(data, "NameOfStation");

                    if (result.Length == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Таблица пустая.");
                        Console.WriteLine("Выполнено!");
                    }
                    else
                    {
                        PrintArray(result);
                        SaveTheResult(result);

                        Console.Clear();
                        Console.WriteLine("Выполнено!");
                    }
                }
                else
                {
                    Console.WriteLine("Программа завершена.");

                    stop_the_program = true;
                    break;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Вами был передан неверный параметр.");
                Console.WriteLine("Наиболее вероятно, путь вашего файла был некорректен при запуске программы.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Вами был передан неверный параметр.");
                Console.WriteLine("Наиболее вероятно, путь вашего файла был некорректен при сохранении результата.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникла непредвиденная проблема.");
                Console.WriteLine("Наиболее вероятно, это связано с неверным значением, введённым вами.");
            }
        }
        while (!stop_the_program);
    }

    /// <summary>
    /// Метод, который выводит меню команд пользователю.
    /// </summary>
    static void PrintMenu()
    {
        Console.WriteLine("Укажите номер пункта меню для запуска действия:");
        Console.WriteLine("    1. Произвести выборку по значению NameOfStation");
        Console.WriteLine("    2. Произвести выборку по значению Line");
        Console.WriteLine("    3. Произвести выборку по значениям NameOfStation и Month");
        Console.WriteLine("    4. Отсортировать таблицу по значению Year (по возрастанию)");
        Console.WriteLine("    5. Отсортировать таблицу по значению NameOfStation (по алфавиту)");
        Console.WriteLine("    6. Выйти из программы");
    }

    /// <summary>
    /// Метод, который выводит результаты выборок, сортировок в таблицу (строчка может не вместиться в консоль из-за большого количества столбцов, поэтому лучше всего предварительно сделать консоль шире)
    /// </summary>
    /// <param name="input"></param>
    static void PrintArray(string[] input)
    {
        Console.WriteLine();
        string[][] data = LibraryOfProcessing.DataProcessing.Transform(input);
        int[] width_of_values = { 5, 25, 33, 16, 16, 40, 30, 4, 8, 10, 15, 7}; //Длины элементов таблицы для каждого столбца, так как длина каждого из столбцов разная.

        for (int i = 0; i < data.GetLength(0); ++i)
        {
            for (int j = 0; j < data[i].Length; ++j)
            {
                Console.Write(data[i][j].PadRight(width_of_values[j]) + "|");
            }

            Console.WriteLine();

            if (i == 1)
            {
                string string_of_lines = new string('-', width_of_values.Sum() + 12); //после шапки таблицы создаём линию разграничения шапки от остальных данных.
                Console.WriteLine(string_of_lines);
            }
        }
        
    }

    /// <summary>
    /// Отдельный метод, в котором мы описываем, как нам сохранять результат
    /// </summary>
    /// <param name="result"></param>
    static void SaveTheResult(string[] result)
    {
        Console.WriteLine();
        Console.WriteLine("Хотите записать полученный результат в файл? (если данные состоят только из одной строки они будут дописаны в данный вами файл)");
        Console.WriteLine("    1.Да");
        Console.WriteLine("    2.Нет");

        bool correct_command = false;
        string command = "";

        while (!correct_command)
        {
            Console.Write("Введите команду: ");
            command = Console.ReadLine();

            if (command == "1" | command == "2")
            {
                correct_command = true;
            }
            else
            {
                Console.Write("Команда введена неверно. Попробуйте ещё раз. ");
            }
        }
        //как мы можем заметить, результат выборки или сортировки почти никогда не содержит 1 строку с данными, поэтому перегрузка Write для одной строки почти не используется.
        //поэтому реализуем следующий способ: как мы можем заметить перегрузка Write на одну строку дописывает данные в файл, а перегрузка на массив строк его перезаписывает.
        //тогда будем предлагать пользователю самому выбрать: 1) дописать ли ему получившийся результат в файл или 2) перезаписать файл.
        //тогда в 1) случае мы с помощью цикла будем по одной строчке дописывать в файл.
        //а во 2) случае мы будем перезаписывать массив строк в файл.
        if (command == "1") 
        {
            if (result.Length > 3)
            {
                Console.WriteLine();
                Console.WriteLine("Вы хотите дописать или перезаписать результат в файл?");
                Console.WriteLine("    1.Дописать в файл.");
                Console.WriteLine("    2.Перезаписать файл.");
            }

            bool correct_next_command = false;
            string next_command = "";
            bool one_string = false; //когда данные состоят из одной строки, то мы должны её только дописать в файл.

            if (result.Length > 3)
            {
                while (!correct_next_command)
                {
                    Console.Write("Введите команду: ");
                    next_command = Console.ReadLine();

                    if (next_command == "1" | next_command == "2")
                    {
                        correct_next_command = true;
                    }
                    else
                    {
                        Console.Write("Команда введена неверно. Попробуйте ещё раз. ");
                    }
                }
            }
            else
            {
                one_string = true;
                correct_next_command = true;

            }

            if (next_command == "1" | one_string)
            {
                bool correct_file = false; //флаг проверки, что название файла корректно.

                while (!correct_file)
                {
                    try
                    {
                        Console.Write("Введите название файла: ");
                        string path = Console.ReadLine();
                        //если файл существовал до этого, то просто дописываем строки из получившегося ранее результата, иначе создаём файл и кроме результата сохраняем и шапку таблицы.
                        if (File.Exists(path))
                        {
                            for (int i = 2; i < result.Length; ++i)
                            {
                                LibraryOfProcessing.CsvProcessing.Write(result[i], path + ".csv");
                            }
                        }
                        else
                        {
                            for (int i = 0; i < result.Length; ++i)
                            {
                                LibraryOfProcessing.CsvProcessing.Write(result[i], path + ".csv");
                            }
                        }
                        correct_file = true;
                    }
                    catch
                    {
                        Console.Write("Название файла некорректно. Попробуйте ещё раз. ");
                    }
                }
            }
            else
            {
                bool correct_file = false; //флаг проверки, что название файла корректно.

                while (!correct_file)
                {
                    try
                    {
                        Console.Write("Введите название файла: ");
                        string path = Console.ReadLine();
                        LibraryOfProcessing.CsvProcessing.SaveFileInFPath(path + ".csv");
                        LibraryOfProcessing.CsvProcessing.Write(result);
                        correct_file = true;
                    }
                    catch
                    {
                        Console.Write("Название файла некорректно. Попробуйте ещё раз. ");
                    }
                }
            }
        }
    }
}