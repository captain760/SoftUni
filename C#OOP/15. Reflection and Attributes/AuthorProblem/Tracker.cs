using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods((BindingFlags)28);
            foreach (var method in methods)
            {
                
                    var attributes = method.GetCustomAttributes(false);
                    foreach (var attr in attributes)
                    {
                    AuthorAttribute atr = attr as AuthorAttribute;
                        if (atr!=null)
                        {
                            Console.WriteLine($"{method.Name} is written by {atr.Name}");
                        }
                        
                    }
                    
                
            }
        }
    }
}
