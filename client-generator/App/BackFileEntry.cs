using System.IO;

namespace client_generator.App
{
    public class BackFileEntry : FileSystemEntry
    {

        public BackFileEntry(string currentPath)
        {
            IsDirectory = true;
            FileName = "..";
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
