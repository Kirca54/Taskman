using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem? Get(int? id);
        void Insert(TaskItem task);
        void Update(TaskItem task);
        void UpdateTask(int taskId, TaskItem task); 
        void Delete(TaskItem task);
    }
}
