using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection:ICollectable
    {
        public AddCollection()
        {
            Collection = new List<string>();
        }

        public List<string> Collection { get ; set ; }

        public int Add(string element)
        {
            Collection.Add(element);
            return Collection.Count - 1;
        }
    }
}
