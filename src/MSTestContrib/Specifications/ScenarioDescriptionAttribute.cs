using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSTestContrib.Specifications
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ScenarioDescriptionAttribute : Attribute
    {
        public ScenarioDescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
