namespace LibraryOfProcessing;
public static class DataProcessing
{
    /// <summary>
    /// Сортировка по значению Year или NameOfStation
    /// </summary>
    /// <param name="input"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string[] SortByValue(string[] input, string name)
    {
        string[][] data = Transform(input);

        int sort_index;

        if (name == "Year")
        {
            sort_index = Array.IndexOf(data[0], "Year");
        }
        else
        {
             sort_index = Array.IndexOf(data[0], "NameOfStation");
        }

        bool end_of_sorting = false;

        while (!end_of_sorting)
        {
            end_of_sorting = true;

            for (int i = 2; i < input.Length - 1; ++i)
            {
                if (String.Compare(data[i][sort_index], data[i + 1][sort_index]) == 1)
                {
                    end_of_sorting = false;
                    Swap(input, i, i + 1);
                    Swap(data, i, i + 1);
                }
            }
        }

        return input;
    }

    /// <summary>
    /// Метод для организации выборки по значению NameOfStation, Line или (NameOfStation и Month)
    /// </summary>
    /// <param name="input"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="second_value"></param> second_value по умолчанию на случай, если производится выборка по одному значению.
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string[] OrganizeSample(string[] input, string name, string value, string second_value="")
    {
        string[][] data = Transform(input); //про метод Transform сказано чуть ниже при объявлении (у него 2 перегрузки)
        string[] result = { input[0], input[1] }; //в результат также сохраняем шапку таблицы.

        if (name == "NameOfStation" | name == "Line")
        {
            int curr_index = Array.IndexOf(data[0], name);
            int founded_rows = 2;

            for (int i = 0; i < data.GetLength(0); ++i)
            {
                if (data[i][curr_index] == value)
                {
                    ++founded_rows;
                    Array.Resize(ref result, founded_rows);
                    result[^1] = input[i];
                }
            }

        }
        else if (name == "NameOfStation&Month")
        {
            int curr_index_1 = Array.IndexOf(data[0], "NameOfStation");
            int curr_index_2 = Array.IndexOf(data[0], "Month");
            int founded_rows = 2;

            for (int i = 0; i < data.GetLength(0); ++i)
            {
                if (data[i][curr_index_1] == value & data[i][curr_index_2] == second_value)
                {
                    ++founded_rows;
                    Array.Resize(ref result, founded_rows);
                    result[^1] = input[i];
                }
            }
        }
        else
        {
            throw new ArgumentException(); //на случай, если неправильно указан столбец.
        }
        return result;
    }

    /// <summary>
    /// Метод, который нужен для того, чтобы поменять местами две строки в массиве строк.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="index_1"></param>
    /// <param name="index_2"></param>
    public static void Swap(string[] input, int index_1, int index_2)
    {
        string tmp = input[index_1];
        input[index_1] = input[index_2];
        input[index_2] = tmp;
    }

    /// <summary>
    /// Метод, который нужен для того, чтобы поменять местами две строки в массиве массивов.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="index_1"></param>
    /// <param name="index_2"></param>
    public static void Swap(string[][] input, int index_1, int index_2)
    {
        string[] tmp = input[index_1];
        input[index_1] = input[index_2];
        input[index_2] = tmp;
    }

    /// <summary> (1-ая перегрузка)
    /// Метод, трансформирующий массив строк таблицы в массив массивов, чтобы удобнее было работать при организации выборки или сортировке.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string[][] Transform(string[] input)
    {
        string[][] data = new string[input.Length][];

        for (int i = 0; i < input.Length; ++i)
        {
            string[] row = input[i][..^1].Split(";");
            data[i] = new string[row.Length];

            for (int j = 0; j < row.Length; ++j)
            {
                data[i][j] = row[j][1..^1];
            }
        }

        return data;
    }

    /// <summary> (2-ая перегрузка)
    /// Метод, трансформирующий строку таблицы в одномерный массив элементов.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string[] Transform(string input)
    {
        string[] row = input[..^1].Split(";");
        string[] data = new string[row.Length];

        for (int i = 0; i < row.Length; ++i)
        {
            data[i] = row[i][1..^1];
        }

        return data;
    }

    /// <summary> (1-ая перегрузка)
    /// Метод, являющийся обратным к методу Transform (1-ая перегрузка)
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string[] BackTransform(string[][] input)
    {
        string[] data = new string[input.GetLength(0)];

        for (int i = 0; i < input.GetLength(0); ++i)
        {
            string row = "";

            for (int j = 0; j < input[i].Length; ++j)
            {
                row += input[i][j] + ";";
            }

            data[i] = row;
        }

        return data;
    }

    /// <summary> (2-ая перегрузка)
    /// Метод, являющийся обратным к методу Transform (2-ая перегрузка)
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string BackTransform(string[] input)
    {
        string data = "";

        for (int i = 0; i < input.Length; ++i)
        {
            data += input[i] + ";";
        }

        return data;
    }
}
