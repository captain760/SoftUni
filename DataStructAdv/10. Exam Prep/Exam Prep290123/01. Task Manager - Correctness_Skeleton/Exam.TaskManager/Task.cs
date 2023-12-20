namespace Exam.TaskManager
{
    public class Task
    {
        public string Id { get; set; }
        public int Order { get; set; }

        public string Name { get; set; }

        public int EstimatedExecutionTime { get; set; }

        public string Domain { get; set; }

        public Task(string id, string name, int estimatedExecutionTime, string domain)
        {
            Id = id;
            Name = name;
            EstimatedExecutionTime = estimatedExecutionTime;
            Domain = domain;
            Order = 0;
        }
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
            return Id;
        }
    }
}
