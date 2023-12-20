namespace Kubernetes
{
    public class Pod
    {
        public string Id { get; set; }

        public string ServiceName { get; set; }

        public int Port { get; set; }

        public string Namespace { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as Pod;

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