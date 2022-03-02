using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList:IAddableAtStart,ICollectable
    {
        public MyList()
        {
            Collection = new List<string>();
        }
        public int Used { get {return Collection.Count; } }

        public List<string> Collection { get; set; }

        public int Add(string element)
        {
            Collection.Insert(0, element);
            return 0;
        }
        public string Remove()
        {
            string removedElement = Collection[0];
            Collection.RemoveAt(0);
            return removedElement;
        }
    }
}
