namespace P04.Recharge
{
    public abstract class Worker 
    {
        public string Id { get; set; }
        public int WorkingHours { get; set; }
        public Worker(string id)
        {
            this.Id = id;
        }

        public abstract void Work(int hours);
        

        //public abstract void Sleep();

        //public abstract void Recharge();
    }
}