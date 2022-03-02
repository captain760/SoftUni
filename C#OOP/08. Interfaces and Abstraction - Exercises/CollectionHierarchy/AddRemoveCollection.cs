using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection: IAddableAtStart,ICollectable
    {
        public AddRemoveCollection()
        {
            Collection = new List<string>();
        }

        public List<string> Collection { get ; set; }

        public int Add(string element)
        {
            Collection.Insert(0, element);
            return 0;
        }
        public string Remove()
        {
            string removedElement = Collection[Collection.Count - 1];
            Collection.RemoveAt(Collection.Count - 1);
            return removedElement;
        }
    }
}
