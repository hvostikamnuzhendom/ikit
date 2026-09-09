using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_лаб
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<string> testCases = new List<string>
            {
                "Цена_топлива \"АИ-95\" 2026.09.03 54.70",
                "Цена_топлива    \"ДТ_Зимнее\"    2026.12.15    65.25",
                "Цена_топлива \"АИ-100\" 2026.05.20 72.00"
            };

            Console.WriteLine("--- Запуск тестирования программы на C# ---");
            Console.WriteLine();

            for (int i = 0; i < testCases.Count; i++)
            {
                Console.WriteLine($"Входная строка №{i + 1}: {testCases[i]}");

                try
                {
                    FuelPrice fp = FuelPrice.ParseFromString(testCases[i]);

                    fp.Print();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при разборе: {ex.Message}");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
