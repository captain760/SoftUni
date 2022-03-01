using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IDentifiable
    {
        public Robot(string model, string id)
        {
            Id = id;
            Model = model;
        }

        public string Id { get ; set ; }
        public string Model { get; set; }
        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
