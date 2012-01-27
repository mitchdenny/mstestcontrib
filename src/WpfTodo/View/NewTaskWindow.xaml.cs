using WpfTodo.Model;
using WpfTodo.ViewModel;

namespace WpfTodo.View
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
