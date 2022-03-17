
using Logger.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            string output = string.Format(this.Layout.Format, dateTime, errorLevel, message);
            Count++;
            Console.WriteLine(output);
        }
        public override string ToString()
        => $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {Count}";
    }
}
