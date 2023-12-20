using Exam.TaskManager;

namespace DemoTM
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tm = new TaskManager();

            tm.AddTask(new Exam.TaskManager.Task("1", "A", 5, "yahoo.com"));
            tm.AddTask(new Exam.TaskManager.Task("2", "B", 4, "abv.com"));
            tm.AddTask(new Exam.TaskManager.Task("3", "CC", 2, "google.com"));
            tm.AddTask(new Exam.TaskManager.Task("4", "D", 2, "micro.com"));
            tm.AddTask(new Exam.TaskManager.Task("5", "E", 1, "render.com"));

            //Console.WriteLine(tm.GetTask("1"));
            //Console.WriteLine(tm.Contains(tm.GetTask("5")));
            //Console.WriteLine(tm.Size());
            Console.WriteLine(String.Join(", ", tm.GetAllTasksOrderedByEETThenByName()));
            //tm.DeleteTask("3");
            tm.ExecuteTask();
            tm.ExecuteTask();
            Console.WriteLine(String.Join(", ", tm.GetAllTasksOrderedByEETThenByName()));
            Console.WriteLine(String.Join(", ", tm.GetTasksInEETRange(1,5)));
            tm.RescheduleTask("1");
            Console.WriteLine(String.Join(", ", tm.GetTasksInEETRange(1, 5)));
            tm.ExecuteTask();
            tm.ExecuteTask();
            Console.WriteLine(String.Join(", ", tm.GetTasksInEETRange(1, 5)));
            Console.WriteLine(String.Join(", ", tm.GetDomainTasks("render.com")));
        }
    }
}