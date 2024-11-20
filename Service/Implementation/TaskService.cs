using Domain;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TaskItem> GetAllTasks()
        {
            return _taskRepository.GetAll().ToList();
        }

        public TaskItem? GetDetailsForTask(int? id)
        {
            return _taskRepository.Get(id);
        }

        public void CreateNewTask(TaskItem task)
        {
            _taskRepository.Insert(task);
        }

        public void UpdateTask(int taskId, TaskItem task)
        {
            _taskRepository.UpdateTask(taskId, task);
        }

        public void DeleteTask(int id)
        {
            var taskItem = _taskRepository.Get(id);
            if (taskItem != null)
            {
                _taskRepository.Delete(taskItem);
            }
        }
    }
}
