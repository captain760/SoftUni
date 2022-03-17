using Logger.Appenders;
using Logger.Layouts;
using Logger.LogFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class AppenderFactory
    {
        public static IAppender CreateAppender(
           string type,
           ILayout layout,
           ReportLevel reportLevel = ReportLevel.Info)
        {
            IAppender appender = type switch
            {
                "ConsoleAppender" => new ConsoleAppender(layout),
                "FileAppender" => new FileAppender(layout, new LogFile(), "../../../log.xml"),
                _ => throw new InvalidOperationException("Missing type")
            };

            appender.ReportLevel = reportLevel;

            return appender;
        }
    }
}
