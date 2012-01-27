using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSTestContrib.Specifications
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class SpecificationDescriptionAttribute : Attribute
	{
        public SpecificationDescriptionAttribute(string description)
        {
            Description = description;
        }
    
        public string Description { get; private set; }
    }
}
