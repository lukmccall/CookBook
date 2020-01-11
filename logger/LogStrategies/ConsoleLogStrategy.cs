using System;

namespace logger.LogStrategies
{
    public class ConsoleLogStrategy : ILogStrategy
    {

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
}
