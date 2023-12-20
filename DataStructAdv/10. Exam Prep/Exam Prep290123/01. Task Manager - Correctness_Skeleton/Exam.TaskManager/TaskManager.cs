using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.TaskManager
{
    public class TaskManager : ITaskManager
    {
        private Dictionary<string, Task> waiting = new Dictionary<string, Task>();
        private Dictionary<string, Task> done = new Dictionary<string, Task>();
        private Dictionary<string, Task> tasks = new Dictionary<string, Task>();
        private int order = 0;
        public void AddTask(Task task)
        {
            
            if (!tasks.ContainsKey(task.Id))
            {
                task.Order = ++order;
                waiting.Add(task.Id, task);
                tasks.Add(task.Id, task);
            }
            
        }

        public bool Contains(Task task)
        {
           return tasks.ContainsKey(task.Id);
        }

        public void DeleteTask(string taskId)
        {
            if (!tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }
            tasks.Remove(taskId);
            if (waiting.ContainsKey(taskId))
            {
                waiting.Remove(taskId);
            }
            else
            {
                done.Remove(taskId);
            }
        }

        public Task ExecuteTask()
        {
           var sortedWaiting = waiting.OrderBy(x=>x.Value.Order).ToDictionary(k=>k.Key, v=>v.Value);
            var firstTask =  sortedWaiting.Values.First();
            if (firstTask != null)
            {
                waiting.Remove(firstTask.Id);
                done.Add(firstTask.Id, firstTask);
                return firstTask;
            }
            else
            {
                throw new ArgumentException();
            }
            
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
        {
            return tasks.Values.OrderByDescending(x => x.EstimatedExecutionTime)
                               .ThenBy(n => n.Name.Length);
        }

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            var domainTasks = waiting.Values.Where(x => x.Domain == domain);
            if (domainTasks.ToList().Count==0)
            {
                throw new ArgumentException();
            }
            return domainTasks;
        }

        public Task GetTask(string taskId)
        {
            if (!tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }
            return tasks[taskId];
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
        {
            return waiting.Values.Where(x => x.EstimatedExecutionTime>=lowerBound && x.EstimatedExecutionTime<=upperBound)
                                 .OrderBy(y=>y.Order);
            
        }

        public void RescheduleTask(string taskId)
        {
            if (!done.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }
            var task = done[taskId];
            done.Remove(taskId);
            task.Order = ++order;
            tasks[taskId] = task;
            waiting.Add(taskId, task);
        }

        public int Size()=>waiting.Count;
    }
}
