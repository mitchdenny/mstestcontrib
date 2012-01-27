using System.Windows.Controls;
using System.Windows.Input;
using SilverlightTodo.Model;

namespace SilverlightTodo.ViewModel
{
    public class NewTaskViewModel : ViewModelBase
    {
        public NewTaskViewModel()
        {
            CreateTaskCommand = new DelegateCommand(CreateTask);
            CancelCommand = new DelegateCommand(()=>
                                                    {
                                                        Owner.DialogResult = false;
                                                    });
            Task = new Task();
        }

        private void CreateTask()
        {
            Owner.DialogResult = true;
        }

        public Task Task { get; private set; }

        public ChildWindow Owner { get; set; }

        public ICommand CreateTaskCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
    }
}