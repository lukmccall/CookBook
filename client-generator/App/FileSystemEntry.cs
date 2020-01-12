using System.IO;

namespace client_generator.App
{
    public class FileSystemEntry
    {

        public string ParentDirectory { get; set; }

        public bool IsDirectory { get; set; }

        public string FileName { get; set; }

        public override string ToString()
        {
            if (IsDirectory)
            {
                return $"D | {FileName}";
            }

            return $"F | {FileName}";
        }

        public virtual string GoToFile()
        {
            return Path.Combine(ParentDirectory, FileName);
        }

    }
}
