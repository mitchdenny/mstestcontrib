using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.SilverlightControls;

// ReSharper disable CheckNamespace
public static class SilverlightButtonExtensions
// ReSharper restore CheckNamespace
{
    public static void Click(this SilverlightButton button)
    {
        Mouse.Click(button);
    }
}