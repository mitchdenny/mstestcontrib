using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.SilverlightControls;

// ReSharper disable CheckNamespace
public static class SilverlightEditExtensions
// ReSharper restore CheckNamespace
{
    public static void Enter(this SilverlightEdit control, string text)
    {
        Keyboard.SendKeys(control, text);
    }
}