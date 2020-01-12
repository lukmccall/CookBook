using System;
using System.Diagnostics;

namespace logger
{
    public class DiagnosticLogger : AbstractLogger
    {

        protected override void WriteMessage(string message)
        {
            var (methodName, className) = GetCallerDiagnosticInfo();
            base.WriteMessage($"{DateTime.Now:yyyy-MM-dd hh:mm:ss} [{LogLevel}] {className} {methodName}: {message}");
        }

        private (string metodName, string className) GetCallerDiagnosticInfo()
        {
            var stackTrace = new StackTrace();
            foreach (var frame in stackTrace.GetFrames())
            {
                var classType = frame.GetMethod()?.ReflectedType;
                if (classType != null &&
                    classType != typeof(AbstractLogger) &&
                    classType != typeof(DiagnosticLogger) &&
                    classType != typeof(LoggerFacade<>) &&
                    classType != typeof(ILogger))
                {
                    var className = classType.Name;
                    var methodName = frame.GetMethod()?.Name ?? "";

                    return (methodName, className);
                }
            }

            return ("UNKNOWN", "");
        }

    }
}
