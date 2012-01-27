using SilverlightTodo.Model;
using SilverlightTodo.ViewModel;

namespace SilverlightTodo.View
{
    public partial class NewTaskWindow
    {
        private readonly NewTaskViewModel _newTaskViewModel;

        public NewTaskWindow()
        {
            _newTaskViewModel = new NewTaskViewModel {Owner = this};
            DataContext = _newTaskViewModel;
            InitializeComponent();
        }

        public Task Task
        {
            get { return _newTaskViewModel.Task; }
        }
    }
}
