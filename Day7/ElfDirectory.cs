namespace Day7
{
    internal class ElfDirectory
    {
        internal ElfDirectory parentDir { get; set; }
        internal string dirName { get; set; }
        internal List<ElfDirectory> childDirs { get; set; } = new List<ElfDirectory>();
        internal List<ElfFile> files { get; set; } = new List<ElfFile>();

        internal ElfDirectory(ElfDirectory parentDir, string dirName)
        {
            this.parentDir = parentDir;
            this.dirName = dirName;
        }

        internal ElfDirectory()
        {

        }

        internal int GetSizeRecursive()
        {
            return childDirs.Select(x => x.GetSizeRecursive()).Sum() + files.Select(x => x.size).Sum();
        }

        internal Dictionary<string, int> GetDirectoriesAndSizes()
        {
            Dictionary<string, int> dirsAndSizes= new Dictionary<string, int>();
            dirsAndSizes.Add(GetDirPath(), GetSizeRecursive());
            foreach (ElfDirectory dir in childDirs)
            {
                dir.GetDirectoriesAndSizes().ToList().ForEach(x => dirsAndSizes.Add(x.Key, x.Value));
            }

            return dirsAndSizes;
        }

        internal string GetDirPath()
        {
            string parentPath = "";
            if (parentDir != null)
            {
                parentPath = parentDir.GetDirPath() + "\\";
            }
            return parentPath += dirName;
        }
    }
}
