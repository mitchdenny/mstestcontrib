using MSTestContrib.UITesting.Silverlight;
using $rootnamespace$.Screens;

namespace $rootnamespace$
{
    public class CodedUITestBase : SilverlightCodedUITestBase<$rootnamespace$Application>
    {
        protected MainScreen MainScreen()
        {
            return new MainScreen(Application, Application.MainPage);
        }
    }
}
