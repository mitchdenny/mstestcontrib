using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quickstart.Wpf
{
    [CodedUITest]
    public class ExampleTest : CodedUiTestBase
    {
        [TestMethod]
        public void CodedUiTestMethod1()
        {
            // We can get our main screen here. then even use TDD style to drive out our user experience. then fill in the details later
            var mainScreen = MainScreen();
            var anotherScreen = mainScreen.OpenSomething();

            //Do stuff with anotherScreen (create methods)

            // anotherScreen.EnterSomeInfo("Foo");
            // anotherScreen.Ok();

            Assert.AreEqual("Expected", mainScreen.SomeValue);
        }
    }
}