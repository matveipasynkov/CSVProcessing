using System.Data;

namespace LibraryOfProcessing;
public static class CsvProcessing
{
    static string fPath = ""; // ставим fPath по умолчанию

    /// <summary>
    /// Просим у пользователя путь к csv файлу, перед тем как показать меню команд.
    /// </summary>
    public static void GetPath()
    {
        Console.Write("Введите путь файла: ");
        fPath = Console.ReadLine();
    }

    /// <summary>
    /// Метод нужный для сохранения файла рядом с исполнимым файлом консольного приложения.
    /// </summary>
    /// <param name="path"></param>
    public static void SaveFileInFPath(string path)
    {
        fPath = path;
    }

    /// <summary>
    /// Чтение файла полученного от пользователя
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string[] Read()
    {
        string[] input = null;

        try
        {
            input = File.ReadAllLines(fPath);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Введено недопустимое название файла.");
            throw new ArgumentNullException();
        }
        catch (IOException e)
        {
            Console.WriteLine("Возникла проблема с открытием файла.");
            throw new ArgumentNullException();
        }
        catch (Exception e)
        {
            Console.WriteLine("Возникла непредвиденная проблема при открытии файла");
            throw new ArgumentNullException();
        }

        string[][] data = new string[input.Length][];

        try
        { ///далее проверяем правильный ли формат у файла.
            string[] check_first_row = { "ID", "NameOfStation", "Line", "Longitude_WGS84", "Latitude_WGS84", "AdmArea", "District", "Year", "Month", "global_id", "geodata_center", "geoarea" };
            string[] check_second_row = { "№ п/п", "Станция метрополитена", "Линия", "Долгота в WGS-84", "Широта в WGS-84", "Административный округ", "Район", "Год", "Месяц", "global_id", "geodata_center", "geoarea" };
            bool flag_first_row = true, flag_second_row = true;
            bool flag_type = true;

            for (int i = 0; i < input.Length; ++i)
            {
                string[] row = input[i][..^1].Split(";");
                data[i] = new string[row.Length];

                for (int j = 0; j < row.Length; ++j)
                {
                    data[i][j] = row[j][1..^1];

                    if (i == 0)
                    {
                        if (data[i][j] != check_first_row[j])
                        {
                            flag_first_row = false;
                        }
                    }
                    else if (i == 1)
                    {
                        if (data[i][j] != check_second_row[j])
                        {
                            flag_second_row = false;
                        }
                    }
                    else if ((j == 0 | j == 7 | j == 9) & (i > 1) & (data[i][j] != ""))
                    {
                        long check_long = 0;

                        if (!long.TryParse(data[i][j], out check_long))
                        {
                            flag_type = false;
                        }
                    }
                    else if ((j == 3 | j == 4) & (i > 1) & data[i][j] != "")
                    {
                        double check_double = 0;
                        if (!double.TryParse(data[i][j], out check_double))
                        {
                            flag_type = false;
                        }
                    }
                }
            }

            if (!flag_first_row | !flag_second_row | !flag_type)
            {
                throw new ArgumentNullException();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Введён недопустимый формат файла");
            throw new ArgumentNullException();
        }

        return input;
    }

    /// <summary>
    /// Перегрузка Write для одной строки.
    /// </summary>
    /// <param name="data_row"></param>
    /// <param name="nPath"></param>
    /// <exception cref="ArgumentException"></exception>
    public static void Write(string data_row, string nPath)
    {
        try
        {
            if (File.Exists(nPath))
            {
                string[] info = File.ReadAllLines(nPath);
                if (info.Length > 0)
                {
                    File.AppendAllText(nPath, "\n" + data_row, encoding: System.Text.Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(nPath, data_row, encoding: System.Text.Encoding.UTF8);
                }
            }
            else
            {
                File.AppendAllText(nPath, data_row, encoding: System.Text.Encoding.UTF8);
            }
        }
        catch (Exception e)
        {
            throw new ArgumentException(); //в случае неккоректного названия файла вызываем ArgumentException.
        }
    }

    /// <summary>
    /// Перегрузка Write для массива строк.
    /// </summary>
    /// <param name="data"></param>
    /// <exception cref="ArgumentException"></exception>
    public static void Write(string[] data)
    {
        try
        {
            string output_string = String.Join("\n", data);
            File.WriteAllText(fPath, output_string, encoding: System.Text.Encoding.UTF8);
        }
        catch (Exception e)
        {
            throw new ArgumentException(); //в случае неккоректного названия файла вызываем ArgumentException.
        }
    }
}