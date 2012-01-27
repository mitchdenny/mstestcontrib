using SilverlightTodo.ViewModel;

namespace SilverlightTodo
{
    public partial class MainPage
    {
        public MainPage()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
