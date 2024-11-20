using Domain.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        //TODO: Impelenet with DB

        // Temporary in-memory storage
        private static List<TaskItem> _tasks = new List<TaskItem>();

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks;
        }

        public TaskItem? Get(int? id) 
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(TaskItem task)
        {
            task.Id = _tasks.Count + 1;
            _tasks.Add(task);
        }

        public void Update(TaskItem task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Status = task.Status;
            }
        }

        public void UpdateTask(int taskId, TaskItem task) 
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (existingTask != null)
            {
                existingTask.Title = task.Title ?? existingTask.Title;
                existingTask.Description = task.Description ?? existingTask.Description;
                existingTask.Status = task.Status ?? existingTask.Status;
            }
        }

        public void Delete(TaskItem entity)
        {
            _tasks.Remove(entity);
        }
    }
}
