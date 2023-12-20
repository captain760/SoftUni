using System.Collections.Generic;

namespace TaskManager
{
    public class Task
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Assignee { get; set; }

        public int Priority { get; set; }

        public HashSet<Task> Dependants { get; set; } = new HashSet<Task>();
        public HashSet<Task> Dependancies { get; set; } = new HashSet<Task>();
        public override bool Equals(object obj)
        {
            var other = obj as Task;

            if (other == null || other.Id != this.Id)
            {
                return false;
            }

            return true;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}