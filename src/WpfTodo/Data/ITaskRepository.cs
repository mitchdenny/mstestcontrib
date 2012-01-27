using System.Collections.Generic;
using WpfTodo.Model;

namespace WpfTodo.Data
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
        void Add(Task task);
        void Delete(int id);
        Task Get(int id);
    }
}