

namespace Logger.Appenders
{
    
    using System;
    using Layouts;
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public int Count { get; protected set; }
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel errorLevel, string message);
        
    }
}
