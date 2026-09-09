using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1_лаб
{
    public class FuelPrice
    {
        public string FuelType { get; private set; }
        public DateTime Date { get; private set; }
        public double Price { get; private set; }

        public FuelPrice(string fuelType, DateTime date, double price)
        {
            FuelType = fuelType;
            Date = date;
            Price = price;
        }

        public void Print()
        {
            Console.WriteLine("Объект: Цена топлива");
            Console.WriteLine($"  Тип топлива: {FuelType}");
            Console.WriteLine($"  Дата:        {Date:yyyy.MM.dd}");
            Console.WriteLine($"  Цена:        {Price:F2} руб.");
        }

        public static FuelPrice ParseFromString(string input)
        {
            var match = Regex.Match(input, @"^\S+\s+""([^""]+)""\s+(\d{4}\.\d{2}\.\d{2})\s+(\d+[\.,]\d+)");

            if (match.Success)
            {
                string fuelType = match.Groups[1].Value;

                DateTime date = DateTime.ParseExact(match.Groups[2].Value, "yyyy.MM.dd", CultureInfo.InvariantCulture);

                string priceStr = match.Groups[3].Value.Replace('.', ',');
                double price = double.Parse(priceStr, new CultureInfo("ru-RU"));

                return new FuelPrice(fuelType, date, price);
            }

            throw new ArgumentException("Входная строка не соответствует требуемому формату.");
        }
    }

}
