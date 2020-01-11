using System.IO;

namespace logger.LogStrategies
{
    public class FileLogStrategy : ILogStrategy
    {

        private readonly string _path;


        public FileLogStrategy(string path)
        {
            _path = path;
        }

        public void WriteMessage(string message)
        {
            using var sw = File.AppendText(_path);
            sw.WriteLine(message);
        }

    }
}
