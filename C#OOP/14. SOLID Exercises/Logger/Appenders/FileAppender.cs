using Logger.Layouts;
using Logger.LogFiles;
using System;
using System.IO;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;
        private readonly string path;
        public FileAppender(ILayout layout, ILogFile logFile, string path) : base(layout)
        {
            this.logFile = logFile;
            this.path = path;
        }

        public override void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            string outputMessage = string.Format(this.Layout.Format, dateTime, errorLevel, message) + Environment.NewLine;
            this.logFile.Write(outputMessage);
            Count++;
            File.AppendAllText(path, outputMessage);
        }
        public override string ToString()
        => $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {Count}, File size {logFile.Size}";
    }
}
