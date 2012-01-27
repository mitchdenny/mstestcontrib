using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.SilverlightControls;

// ReSharper disable CheckNamespace
public static class SilverlightControlExtensions
// ReSharper restore CheckNamespace
{
    public static T Get<T>(this SilverlightControl container, string automationId) where T : SilverlightControl, new()
    {
        container.WaitForControlReady();
        var foo = new T
                        {
                            Container = container,
                            SearchProperties =
                                {
                                    {SilverlightControl.PropertyNames.AutomationId, automationId}
                                },
                            TechnologyName = "Silverlight"
                        };

        foo.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
        foo.Find();
        return foo;
    }

    public static T Get<T>(this SilverlightControl container, Func<PropertyExpressionCollection> searchProperties) where T : SilverlightControl, new()
    {
        container.WaitForControlReady();
        var foo = new T
                        {
                            Container = container,
                            TechnologyName = "Silverlight"
                        };
        foo.SearchProperties.AddRange(searchProperties());

        foo.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
        foo.Find();
        return foo;
    }

    public static IEnumerable<T> GetMultiple<T>(this SilverlightControl container, string automationId) where T : SilverlightControl, new()
    {
        container.WaitForControlReady();
        var foo = new T
                        {
                            Container = container,
                            SearchProperties =
                                {
                                    {SilverlightControl.PropertyNames.AutomationId, automationId}
                                },
                            TechnologyName = "Silverlight"
                        };

        foo.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
        return foo.FindMatchingControls().Cast<T>();
    }
}