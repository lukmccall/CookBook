using System;

namespace logger
{
    public class RawLogger : AbstractLogger
    {

        protected override void WriteMessage(string message)
        {
            base.WriteMessage($"{DateTime.Now:yyyy-MM-dd hh:mm:ss} {LogLevel} {message}");
        }

    }
}
