namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            Employee me = new Employee("1029");
            Robot R2D2 = new Robot("r2d2", 10);
            me.Work(12);
            me.Sleep();

            R2D2.CurrentPower = 9;
            Console.WriteLine(R2D2.CurrentPower);
            R2D2.Work(14);
            Console.WriteLine(R2D2.CurrentPower);            
            R2D2.Recharge();
            Console.WriteLine(R2D2.CurrentPower);

        }
    }
}
