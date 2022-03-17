using Logger.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
            => type switch
            {
                "SimpleLayout" => new SimpleLayout(),
                "XmlLayout" => new XmlLayout(),
                _ => throw new InvalidOperationException("Missing type"),
            };
    }
}
