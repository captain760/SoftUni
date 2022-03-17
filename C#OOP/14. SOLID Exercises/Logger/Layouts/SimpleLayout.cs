
namespace Logger.Layouts
{
    public class SimpleLayout : Layout
    {
        private const string format = "{0} - {1} - {2}";
        public SimpleLayout():base(format)
        {
                
        }
    }
}
