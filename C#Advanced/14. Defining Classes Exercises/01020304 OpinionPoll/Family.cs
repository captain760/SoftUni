using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            ListOfPeople = new List<Person>();
        }
        public List<Person> ListOfPeople { get; set; }
        public void AddMember(Person member)
        {
            
            this.ListOfPeople.Add(member);
        }
        public Person GetOldestMember()
        {
            int maxAge = ListOfPeople.Max(x => x.Age);
            Person OldestOne = ListOfPeople.FirstOrDefault(x => x.Age == maxAge);
            return OldestOne;
        }
        public List<Person> OldPeople( int borderAge)
        {
            return ListOfPeople.OrderBy(x => x.Name).Where(x => x.Age > borderAge).ToList();
        }
    }

}
