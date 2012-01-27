using MSTestContrib.UITesting;
using WpfTodo.Tests.Screens;

namespace WpfTodo.Tests
{
    public class CodedUITestBase : CodedUITestBase<TodoApp>
    {
        protected MainScreen MainScreen()
        {
            return new MainScreen(Application, Application.MainWindow);
        }
    }
}
