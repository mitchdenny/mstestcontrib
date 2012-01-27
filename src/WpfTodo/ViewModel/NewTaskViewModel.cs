using System.Windows;
using System.Windows.Input;
using WpfTodo.Model;

namespace WpfTodo.ViewModel
{
    public class NewTaskViewModel : ViewModelBase
    {
        public NewTaskViewModel()
        {
            CreateTaskCommand = new DelegateCommand(CreateTask);
            CancelCommand = new DelegateCommand(()=>
                                                    {
                                                        Owner.DialogResult = false;
                                                        Owner.Close();
                                                    });
            Task = new Task();
        }

        private void CreateTask()
        {
            Owner.DialogResult = true;
            Owner.Close();
        }

        public Task Task { get; private set; }

        public Window Owner { get; set; }

        public ICommand CreateTaskCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
    }
}