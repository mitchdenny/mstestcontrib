using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting.SilverlightControls;

// ReSharper disable CheckNamespace
public static class SilverlightComboBoxExtensions
// ReSharper restore CheckNamespace
{
    public static void Select(this SilverlightComboBox listControl, Predicate<SilverlightListItem> shouldSelectItem)
    {
        listControl.WaitForControlEnabled();

        listControl.SelectedItem = listControl.Items
            .Cast<SilverlightListItem>()
            .First(i => shouldSelectItem(i))
            .DisplayText;
    }
}