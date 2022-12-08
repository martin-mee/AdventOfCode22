namespace Day8
{
    internal class Tree
    {
        internal int height { get; set; }
        internal bool visible { get; set; }
        internal int northView { get; set; }
        internal int southView { get; set; }
        internal int westView { get; set; }
        internal int eastView { get; set; }

        internal Tree(int height)
        {
            this.height = height;
        }

        internal int GetViewRange()
        {
            return northView * southView * westView * eastView;
        }
    }
}
