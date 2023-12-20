using TaskManager;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new Manager();
            // Arrange
            var task1 = new TaskManager.Task
            {
                Id = "1",
                Assignee = "John",
                Priority = 1,
                Title = "Task1",
            };

            var task2 = new TaskManager.Task
            {
                Id = "2",
                Assignee = "John",
                Priority = 1,
                Title = "Task2",
            };

            var task3 = new TaskManager.Task
            {
                Id = "3",
                Assignee = "John",
                Priority = 1,
                Title = "Task3",
            };
            var task4 = new TaskManager.Task
            {
                Id = "4",
                Assignee = "John",
                Priority = 1,
                Title = "Task4",
            };
            // Act
            taskManager.AddTask(task1);
            taskManager.AddTask(task2);
            taskManager.AddTask(task3);
            taskManager.AddTask(task4);

            taskManager.AddDependency(task1.Id, task2.Id);
            taskManager.AddDependency(task2.Id, task3.Id);
            taskManager.AddDependency(task4.Id, task1.Id);

            taskManager.RemoveDependency(task2.Id,task3.Id);

            Console.WriteLine(String.Join(", ",taskManager.GetDependencies("1")));
            Console.WriteLine(String.Join(", ",taskManager.GetDependents("1")));
            Console.WriteLine();
            Console.WriteLine(String.Join(", ",taskManager.GetDependencies("2")));
            Console.WriteLine(String.Join(", ",taskManager.GetDependents("2")));
            Console.WriteLine();
            Console.WriteLine(String.Join(", ",taskManager.GetDependencies("3")));
            Console.WriteLine(String.Join(", ",taskManager.GetDependents("3")));
            Console.WriteLine();
            Console.WriteLine(String.Join(", ", taskManager.GetDependencies("4")));
            Console.WriteLine(String.Join(", ", taskManager.GetDependents("4")));
            // Assert
            //Assert.That(
            //    this.taskManager.GetDependencies(task1.Id).OrderBy(t => t.Title),
            //    Is.EquivalentTo(new List<Task> { task2, task3 }));

            //Assert.That(
            //    taskManager.GetDependents(task1.Id),
            //    Is.EquivalentTo(new List<Task>()));

            //Assert.That(
            //    this.taskManager.GetDependencies(task2.Id),
            //    Is.EquivalentTo(new List<Task> { task3 }));

            //Assert.That(
            //    this.taskManager.GetDependents(task2.Id),
            //    Is.EquivalentTo(new List<Task> { task1 }));

            //Assert.That(
            //    this.taskManager.GetDependencies(task3.Id),
            //    Is.EquivalentTo(new List<Task>()));

            //Assert.That(
            //    this.taskManager.GetDependents(task3.Id).OrderBy(t => t.Title),
            //    Is.EquivalentTo(new List<Task> { task1, task2 }));
        }
    }
}