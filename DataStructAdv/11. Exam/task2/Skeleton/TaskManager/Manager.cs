using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager
{
    public class Manager : IManager
    {
        private Dictionary<string, Task> managers = new Dictionary<string, Task>();

        public void AddDependency(string taskId, string dependentTaskId)
        {
            if (!managers.ContainsKey(taskId) || !managers.ContainsKey(dependentTaskId)) 
            {
                throw new ArgumentException();
            }

            var task = managers[taskId];
            var boss = managers[dependentTaskId];
            
            task.Dependants.Add(boss);
            boss.Dependancies.Add(task);
            foreach (var item in boss.Dependants)
            {
                task.Dependants.Add(item);
            }
            foreach (var item in task.Dependancies)
            {
                boss.Dependancies.Add(item);
                item.Dependants.Add(boss);
            }

            if (task.Dependancies.Contains(boss) || boss.Dependants.Contains(task))
            {
                throw new ArgumentException();
            }
        }

        public void AddTask(Task task)
        {
            if (managers.ContainsKey(task.Id))
            {
                throw new ArgumentException();
            }
            managers.Add(task.Id, task);
        }

        public bool Contains(string taskId)
        {
            return managers.ContainsKey(taskId);
        }

        public Task Get(string taskId)
        {
            if (!managers.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }
            return managers[taskId];
        }

        public IEnumerable<Task> GetDependencies(string taskId)
        {
            if (!managers.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }
           
            var firstDependants= managers[taskId].Dependants;
            HashSet<Task> result = firstDependants;
            foreach ( var item in firstDependants) 
            {
                foreach ( var item2 in item.Dependants) { result.Add(item2); }

            }
            return result;
        }

        public IEnumerable<Task> GetDependents(string taskId)
        {
            if (!managers.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }
            return managers[taskId].Dependancies;
        }

        public void RemoveDependency(string taskId, string dependentTaskId)
        {
            if (!managers.ContainsKey(taskId) || !managers.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException();
            }

            var task = managers[taskId];
            var boss = managers[dependentTaskId];
            //if (!task.Dependants.Contains(boss) || boss.Dependancies.Contains(task))
            //{
            //    throw new ArgumentException();
            //}

            task.Dependants.Remove(boss);
            boss.Dependancies.Remove(task);
            foreach (var item in task.Dependancies)
            {
                item.Dependants.Remove(boss);
            }
            foreach (var item in boss.Dependants)
            {
                item.Dependancies.Remove(task);
            }
        }

        public void RemoveTask(string taskId)
        {
            if (!managers.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }
            Task taskToDelete = managers[taskId];
            foreach (var task in taskToDelete.Dependancies)
            {
                task.Dependants.Remove(taskToDelete);
            }
                
               
            
            foreach (var task in taskToDelete.Dependants)
            {
                task.Dependancies.Remove(task);
            }
            managers.Remove(taskId);
        }

        public int Size()=>managers.Count;
    }
}