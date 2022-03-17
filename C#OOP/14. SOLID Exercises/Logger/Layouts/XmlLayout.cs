
namespace Logger.Layouts
{
    public class XmlLayout : Layout
    {
        public const string format = @"<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";

        public XmlLayout() : base(format)
        {

        }
    }
}
