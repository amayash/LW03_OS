using System;
using System.Text;

namespace LW03
{
    internal class RAM
    {
        private Dictionary<int, Page> ram;
        private readonly int maxSize = 16;
        private ROM rom = new();
        private Random random = new Random();

        public int Count { get { return ram.Count; } }

        public RAM()
        {
            ram = new Dictionary<int, Page>(maxSize);
        }

        public void AddPage(int id)
        {
            if (ram.ContainsKey(id))
            {
                Console.WriteLine($"(ОЗУ) Страница с ID: {id} уже существует.");
                return;
            }
            int key = id;
            if (ram.Count >= maxSize)
            {
                key = NRU(id);
                ram.Remove(key);
            }
            if (key < 0)
            {
                Console.WriteLine("(ОЗУ) Неправильная отработка.");
                return;
            }
            ram.Add(id, new Page(id, random.Next(2), random.Next(2)));
            Console.WriteLine($"(ОЗУ) Добавлена страница с ID: {id}");
        }
        private void AddPage(int id, int used)
        {
            if (ram.ContainsKey(id))
            {
                Console.WriteLine($"(ОЗУ) Страница с ID: {id} уже существует.");
                return;
            }
            int key = id;
            if (ram.Count >= maxSize)
            {
                key = NRU(id);
                ram.Remove(key);
            }
            if (key < 0)
            {
                Console.WriteLine("(ОЗУ) Неправильная отработка.");
                return;
            }
            ram.Add(id, new Page(id, used, random.Next(2)));
            Console.WriteLine($"(ОЗУ) Добавлена страница с ID: {id}");
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append("(ОЗУ) ID: ");
            foreach (var elem in ram)
                sb.Append(elem.Key+" ");
            sb.Append("\n");
            return sb.ToString();
        }

        public Page GetPage(int id)
        {
            Page page = new Page(-1, null, null);
            if (ram.TryGetValue(id, out page))
            {
                Console.WriteLine($"(ОЗУ) Страница с ID: {id} нашлась.");
                return page;
            }
            else
            {
                page = rom.GetPage(id);
                if (page.ID < 0)
                {
                    Console.WriteLine($"(ОЗУ) Страничное прерывание. Страница с ID: {id} не существует. Она будет создана.");
                    AddPage(id, 1);
                    Page value = new Page(-1, null, null);
                    ram.TryGetValue(id, out value);
                    return value;
                }
                return page;
            }
        }

        private int NRU(int id)
        {
            Console.WriteLine($"(ОЗУ) Переполнение на ID {id}.\n(ОЗУ) Вызван алгоритм замещения страниц.");
            Console.WriteLine("(ПЗУ) ID: "+rom.ToString());

            foreach (KeyValuePair<int, Page> kvp in ram)
            {
                if (kvp.Value.Used == 0 & kvp.Value.Modif == 0)
                {
                    rom.AddPage(kvp.Value);
                    return kvp.Key;
                }
            }
            foreach (KeyValuePair<int, Page> kvp in ram)
            {
                if (kvp.Value.Used == 0 & kvp.Value.Modif == 1)
                {
                    rom.AddPage(kvp.Value);
                    return kvp.Key;
                }
            }
            foreach (KeyValuePair<int, Page> kvp in ram)
            {
                if (kvp.Value.Used == 1 & kvp.Value.Modif == 0)
                {
                    rom.AddPage(kvp.Value);
                    return kvp.Key;
                }
            }
            foreach (KeyValuePair<int, Page> kvp in ram)
            {
                if (kvp.Value.Used == 1 & kvp.Value.Modif == 1)
                {
                    rom.AddPage(kvp.Value);
                    return kvp.Key;
                }
            }
            return -1;
        }

    }
}
