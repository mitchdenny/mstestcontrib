using System.Collections.Generic;
using SilverlightTodo.Model;

namespace SilverlightTodo.Data
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
        void Add(Task task);
        void Delete(int id);
        Task Get(int id);
    }
}