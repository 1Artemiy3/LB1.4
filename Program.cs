
namespace LB1._4
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Зчитування даних з файлу
                using (StreamReader f = new StreamReader("input.txt"))
                {
                    string[] data = f.ReadToEnd().Split('\n');

                    if (data.Length < 4)
                    {
                        Console.WriteLine("Недостатньо даних у файлі.");
                        return;
                    }

                    int X = int.Parse(data[0].Trim());
                    int AB = int.Parse(data[1].Trim());
                    int BC = int.Parse(data[2].Trim());
                    int weight = int.Parse(data[3].Trim());

                    // Перевірка максимальної ваги
                    if (weight > 2000)
                    {
                        Console.WriteLine("Літак не може підняти вантаж.");
                        return;
                    }

                    // Визначення витрати палива на 1 км
                    int consumption;
                    if (weight <= 500) consumption = 1;
                    else if (weight <= 1000) consumption = 4;
                    else if (weight <= 1500) consumption = 7;
                    else consumption = 9; // до 2000 кг

                    // Обчислення необхідного палива для кожної ділянки
                    double fuelAB = AB * consumption;
                    double fuelBC = BC * consumption;

                    // Перевірка можливості подолати AB
                    if (fuelAB > X)
                    {
                        Console.WriteLine("Неможливо подолати відстань від А до В.");
                        return;
                    }

                    // Перевірка можливості подолати BC
                    if (fuelBC > X)
                    {
                        Console.WriteLine("Неможливо подолати відстань від В до С.");
                        return;
                    }

                    // Визначення залишку палива після подолання AB
                    double remainingAfterAB = X - fuelAB;

                    // Визначення необхідної дозаправки
                    if (remainingAfterAB >= fuelBC)
                    {
                        Console.WriteLine("Дозаправка не потрібна.");
                    }
                    else
                    {
                        double refuel = fuelBC - remainingAfterAB;
                        Console.WriteLine($"Мінімальна дозаправка в пункті В: {refuel} літрів.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}