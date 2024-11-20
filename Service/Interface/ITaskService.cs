using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITaskService
    {
        List<TaskItem> GetAllTasks();  
        TaskItem? GetDetailsForTask(int? id); 
        void CreateNewTask(TaskItem task);  
        void UpdateTask(int taskId, TaskItem task);  
        void DeleteTask(int id);
    }
}
