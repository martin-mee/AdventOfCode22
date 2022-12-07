namespace Day7
{
    internal class ElfFile
    {
        internal string name { get; set; }
        internal int size { get; set; }

        internal ElfFile(string name, int size)
        {
            this.name = name;
            this.size = size;
        }
    }
}
