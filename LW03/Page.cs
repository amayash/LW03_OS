namespace LW03
{
    internal class Page
    {
        private int id;
        private int? used;
        private int? modif;

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
