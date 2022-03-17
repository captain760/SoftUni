using Logger.Layouts;
using System;

namespace Logger.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        int Count { get; }
        void Append(string dateTime, ReportLevel errorLevel, string message);
    }
}
