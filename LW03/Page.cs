namespace LW03
{
    internal class Page
    {
        readonly int size = 4;
        private int id;
        private int? used;
        private int? modif;
        Random random = new();

        public int Size { get { return size; } }
        public int? Used { get { return used; } }
        public int? Modif { get { return modif; } }
        public int ID { get { return id; } }

        public Page(int id, int? used, int? modif)
        {
            this.id = id;
            this.used = used;
            this.modif = modif;
        }

    }
}
