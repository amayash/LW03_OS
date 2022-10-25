using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace LW03
{
    internal class ROM
    {
        private List<Page> rom = new List<Page>();
        private Random random = new();

        public void AddPage(Page page)
        {
            foreach (var elem in rom)
            {
                if (elem.ID == page.ID)
                {
                    Console.WriteLine($"(ПЗУ) Страница с ID: {page.ID} уже существует");
                    return;
                }
            }
            Console.WriteLine($"(ПЗУ) Добавлена страница с ID: {page.ID}");
            rom.Add(page);
        }

        public Page GetPage(int id)
        {
            for (int i = 0; i < rom.Count; i++)
            {
                if (rom[i].ID != id)
                    continue;
                Page temp = rom[i];
                rom[i] = null;
                return temp;
            }
            return new Page(-1, null, null);
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var page in rom)
                sb.Append(page.ID + " ");
            return sb.ToString();
        }

    }
}
