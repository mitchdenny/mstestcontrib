using MSTestContrib.UITesting.Silverlight;

namespace SilverlightTodo.Tests
{
    public class SilverlightTodoApplication : SilverlightApplicationBase
    {
        public override string MainPageTypeName
        {
            get { return "MainPage"; }
        }
    }
}