using MSTestContrib.UITesting;
using WpfTodo.Tests.Screens;

namespace WpfTodo.Tests
{
    public class CodedUiTestBase : CodedUITestBase<TodoApp>
    {
        protected MainScreen MainScreen()
        {
            return new MainScreen(Application, Application.MainWindow);
        }
    }
}
