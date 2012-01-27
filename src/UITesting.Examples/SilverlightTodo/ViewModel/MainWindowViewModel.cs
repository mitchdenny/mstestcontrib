using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SilverlightTodo.Data;
using SilverlightTodo.Model;
using SilverlightTodo.View;

namespace SilverlightTodo.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ITaskRepository _repo = new TaskRepository();

        public MainWindowViewModel()
        {
            AddTaskCommand = new DelegateCommand(AddNewTask);
            Tasks = new ObservableCollection<Task>();
        }

        private void AddNewTask()
        {
            //By setting Owner it maintains the UI Automation tree, normally this would be done by a service so the VM doesnt reference the view
            var dialog = new NewTaskWindow();

            dialog.Closed += DialogClosed;

            dialog.Show();
        }

        void DialogClosed(object sender, System.EventArgs e)
        {
            var window = (NewTaskWindow) sender;
            if (window.DialogResult != true) return;

            _repo.Add(window.Task);
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