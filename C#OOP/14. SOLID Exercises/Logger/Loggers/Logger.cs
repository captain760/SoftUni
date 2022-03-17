using Logger.Appenders;
using System;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        private DateTime time;
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;

        }

        public IAppender[] Appenders { get; }

        public void Critical(string time, string message)
        {
            foreach (var appender in Appenders)
            {
                if (appender.ReportLevel<=ReportLevel.Critical)
                {
                    appender.Append(time, ReportLevel.Critical, message);
                }
                
            }
        }

        public void Error(string time, string message)
        {
            foreach (var appender in Appenders)
            {
                if (appender.ReportLevel <= ReportLevel.Error)
                {
                    appender.Append(time, ReportLevel.Error, message);
                }
            }
        }

        public void Fatal(string time, string message)
        {
            foreach (var appender in Appenders)
            {
                if (appender.ReportLevel <= ReportLevel.Fatal)
                {
                    appender.Append(time, ReportLevel.Fatal, message);
                }
            }
        }

        public void Info(string time, string message)
        {
            foreach (var appender in Appenders)
            {
                if (appender.ReportLevel == ReportLevel.Info)
                {
                    appender.Append(time, ReportLevel.Info, message);
                }
            }
        }

        public void Warning(string time, string message)
        {
            foreach (var appender in Appenders)
            {
                if (appender.ReportLevel <= ReportLevel.Warning)
                {
                    appender.Append(time, ReportLevel.Warning, message);
                }
            }
        }
    }
}
