using System.Collections.Generic;
using WpfTodo.Model;

namespace WpfTodo.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Dictionary<int, Task> _tasks = new Dictionary<int, Task>();
        private int _currentId;

        public IEnumerable<Task> GetAll()
        {
            return _tasks.Values;
        }

        public void Add(Task task)
        {
            _tasks.Add(_currentId++, task);
        }

        public void Delete(int id)
        {
            if (_tasks.ContainsKey(id))
                _tasks.Remove(id);
        }

        public Task Get(int id)
        {
            if (_tasks.ContainsKey(id))
                return _tasks[id];

            return null;
        }
    }
}