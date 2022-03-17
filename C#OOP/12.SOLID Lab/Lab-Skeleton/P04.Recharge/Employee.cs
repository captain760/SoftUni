namespace P04.Recharge
{
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            Console.WriteLine("Sleeping 8hrs...");
        }

        public override void Work(int hours)
        {
            this.WorkingHours += hours;
        }

        //public override void Recharge()
        //{
        //    throw new InvalidOperationException("Employees cannot recharge");
        //}

    }
}
