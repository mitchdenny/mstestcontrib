using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.SilverlightControls;

// ReSharper disable CheckNamespace
public static class SilverlightWindowExtensions
// ReSharper restore CheckNamespace
{
    public static SilverlightPage AccessKeyPress(this SilverlightPage currentScreen, string accessKey)
    {
        Keyboard.PressModifierKeys(ModifierKeys.Alt);
        Keyboard.SendKeys(accessKey);
        Keyboard.ReleaseModifierKeys(ModifierKeys.Alt);

        return currentScreen;
    }
}