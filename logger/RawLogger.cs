namespace logger
{
    public class RawLogger : AbstractLogger
    {

        protected override void WriteMessage(string message)
        {
            base.WriteMessage($"{LogLevel} {message}");
        }

    }
}
