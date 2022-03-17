using Logger.Appenders;
using System;

namespace Logger.Loggers
{
    public interface ILogger
    {
        IAppender[] Appenders { get; }
        void Info(string time, string message);
        void Warning(string time, string message);
        void Error(string time, string message);
        void Critical(string time, string message);
        void Fatal(string time, string message);
    }
}
