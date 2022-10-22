using System;

namespace LW03
{
    class Program
    {
        static void Main(string[] args)
        {
            RAM ram = new RAM();
            Random random = new Random();
            int maxRandom = 100;
            int[] arr = new int[12] { random.Next(maxRandom+1), random.Next(maxRandom+1), random.Next(maxRandom+1),
                random.Next(maxRandom+1), random.Next(maxRandom+1), random.Next(maxRandom+1),
                random.Next(maxRandom+1), random.Next(maxRandom+1), random.Next(maxRandom+1),
                random.Next(maxRandom+1), random.Next(maxRandom+1), random.Next(maxRandom+1) };
            
            for (int i = 0; i < arr.Length; i++)
                ram.AddPage(arr[i]);

            Console.WriteLine($"Текущая вместимость ОЗУ: {ram.Count}\n");
            ram.AddPage(5);
            ram.AddPage(15);
            Console.WriteLine($"Текущая вместимость ОЗУ: {ram.Count}\n");
            ram.AddPage(25);
            ram.AddPage(35);
            Console.WriteLine($"Текущая вместимость ОЗУ: {ram.Count} \n");
            ram.AddPage(45);
            ram.AddPage(55);
            Console.WriteLine($"Текущая вместимость ОЗУ: {ram.Count} \n");
            ram.AddPage(5);
            ram.AddPage(55);
            Console.WriteLine($"Текущая вместимость ОЗУ: {ram.Count} \n");
            ram.GetPage(5);
            ram.Print();
            ram.GetPage(5);

            ram.AddPage(124);
            ram.AddPage(125);
            ram.AddPage(126);
            ram.AddPage(126);
            ram.GetPage(126);
            ram.Print();

            Console.ReadKey();
        }
    }
}