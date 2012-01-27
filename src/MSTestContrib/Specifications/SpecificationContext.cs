using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestContrib.Specifications
{
	public class SpecificationContext
	{
        public dynamic State { get; set; }
        public List<GrammarBase> Grammars { get; private set; }
        public string ScenarioDescription { get; private set; }
        public Specification Specification { get; private set; }
        public TestContext TestContext { get; private set; }

	    public SpecificationContext(Specification specification, TestContext testContext, string scenarioDescription)
        {
	        Grammars = new List<GrammarBase>();
	        Specification = specification;
	        TestContext = testContext;
	        ScenarioDescription = scenarioDescription;
            State = new SpecificationContextState();
        }
	}
}
