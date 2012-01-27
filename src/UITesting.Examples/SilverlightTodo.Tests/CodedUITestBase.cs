using MSTestContrib.UITesting.Silverlight;
using SilverlightTodo.Tests.Screens;

namespace SilverlightTodo.Tests
{
    public class CodedUITestBase : SilverlightCodedUITestBase<SilverlightTodoApplication>
    {
        protected MainScreen MainScreen()
        {
            return new MainScreen(Application, Application.MainPage);
        }
    }
}
