using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfTodo.Data;
using WpfTodo.Model;
using WpfTodo.View;

namespace WpfTodo.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ITaskRepository _repo = new TaskRepository();

        public MainWindowViewModel()
        {
            AddTaskCommand = new DelegateCommand(AddNewTask);
            Tasks = new ObservableCollection<Task>();
        }

        public Window Owner { get; set; }

        private void AddNewTask()
        {
            //By setting Owner it maintains the UI Automation tree, normally this would be done by a service so the VM doesnt reference the view
            var dialog = new NewTaskWindow { Owner = Owner };

            if (dialog.ShowDialog() != true) return;

            _repo.Add(dialog.Task);
            Refresh();
        }

        private void Refresh()
        {
            Tasks.Clear();
            foreach (var task in _repo.GetAll().OrderBy(o=>o.DueDate))
            {
                Tasks.Add(task);
            }
        }

        public ObservableCollection<Task> Tasks { get; private set; }

        public ICommand AddTaskCommand { get; private set; }
    }
}