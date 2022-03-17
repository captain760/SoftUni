using System.Linq;
using System.Text;

namespace Logger.LogFiles
{
    public class LogFile : ILogFile

    {
        private readonly StringBuilder sb;
        public LogFile()
        {
            this.sb = new StringBuilder();
        }
        public int Size =>
            this.sb.ToString().Where(char.IsLetter).Sum(x => x);

        public void Write(string message)
        {
            this.sb.Append(message);
        }
    }
}
