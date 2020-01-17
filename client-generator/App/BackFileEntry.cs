using System.IO;

namespace client_generator.App
{
    public class BackFileEntry : FileSystemEntry
    {

        public BackFileEntry(string currentPath)
        {
            FileName = "..";
            IsDirectory = true;
            ParentDirectory = Directory.GetParent(currentPath)?.FullName ?? currentPath;
        }

        public override string ToString()
        {
            return FileName;
        }

        public override string GoToFile()
        {
            return ParentDirectory;
        }

    }
}
