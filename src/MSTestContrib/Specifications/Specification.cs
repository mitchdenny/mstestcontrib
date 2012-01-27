using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestContrib.Properties;
using System.Text;
using System.Collections.Generic;

namespace MSTestContrib.Specifications
{
	public class Specification
	{
        public Specification()
        {
        }

	    public string Description { get; private set; }
	    public SpecificationContext Context { get; private set; }
        public TestContext TestContext { get; set; }
        
        [TestInitialize()]
        public virtual void Initialize()
        {
            Description = GetSpecificationDescription();
            var scenarioDescription = GetScenarioDescription();
            Context = new SpecificationContext(this, TestContext, scenarioDescription);
        }

        private string GetSpecificationDescription()
        {
            var specificationType = GetType();
            var attributes = specificationType.GetCustomAttributes(typeof(SpecificationDescriptionAttribute), false);

            if (attributes.Length != 1)
            {
                string exceptionMessage = string.Format(
                    Resources.ExceptionMessageMissingSpecificationDescriptionAttribute,
                    GetType().FullName
                    );

                throw new SpecificationException(exceptionMessage);
            }

            var attribute = (SpecificationDescriptionAttribute)attributes[0];
            return attribute.Description;
        }

	    private string GetScenarioDescription()
	    {
	        var specificationType = GetType();
	        var testMethod = specificationType.GetMethod(TestContext.TestName);
	        var attributes = testMethod.GetCustomAttributes(typeof(ScenarioDescriptionAttribute), false);
            
            if (attributes.Length != 1)
            {
                string exceptionMessage = string.Format(
                    Resources.ExceptionMessageMessingScenarioDescriptionAttribute,
                    testMethod.Name,
                    specificationType.FullName
                    );

                throw new SpecificationException(exceptionMessage);
            }

            var attribute = (ScenarioDescriptionAttribute) attributes[0];
	        return attribute.Description;
	    }

	    [TestCleanup()]
        public virtual void Cleanup()
        {
            var report = BuildReport();

            var exceptioned = Context.Grammars.Any(x => x.Result == GrammarResult.Exception);
            if (exceptioned)
            {
                Assert.Fail(Resources.FailMessageUnhandledWhilstProcessingGrammars, report);
            }

            var inconclusive = Context.Grammars.Any(x => x.Result == GrammarResult.NotImplemented);
            if (inconclusive)
            {
                Assert.Inconclusive(Resources.AssertMessageTestResultsInconclusive, report);
            }

            var failed = Context.Grammars.Any(x => x.Result == GrammarResult.Failed);
            if (failed)
            {
                Assert.Fail(Resources.FailMessageGrammersNotPassed, report);
            }
        }

        private string BuildReport()
        {
            var specificationBuilder = new StringBuilder();
            specificationBuilder.AppendFormat("Specification: {0}\r\n\tScenario: {1}\r\n", Context.Specification.Description, Context.ScenarioDescription);

            var exceptions = new List<Exception>();
            for (int grammarIndex = 0; grammarIndex < Context.Grammars.Count; grammarIndex++)
            {
                var grammar = Context.Grammars[grammarIndex];
                var suffix = grammarIndex == Context.Grammars.Count - 1 ? "." : ",";
                
                specificationBuilder.AppendFormat("\t\t{0}{1} ({2}", grammar.Description, suffix, grammar.Result);

                if (grammar.Result == GrammarResult.Exception)
                {
                    exceptions.Add(grammar.Exception);
                    specificationBuilder.AppendFormat(", see exception #{0} below", exceptions.Count - 1);
                }

                specificationBuilder.Append(")\r\n");
            }

            var exceptionBuilder = new StringBuilder();

            for (int exceptionIndex = 0; exceptionIndex < exceptions.Count; exceptionIndex++)
            {
                var exception = exceptions[exceptionIndex];
                exceptionBuilder.AppendFormat("Exception #{0}: {1}\r\n\r\n", exceptionIndex, exception);
            }

            var report = string.Format("{0}\r\n{1}", specificationBuilder, exceptionBuilder);
            return report;
        }

        public GivenGrammar Given(string description)
        {
            return Given(description, null);
        }

        public GivenGrammar Given(string description, Action<SpecificationContext> implementation)
        {
            var given = new GivenGrammar(Context, description, implementation, GivenGrammarPrefix.Given);
            given.Evaluate();
            return given;
        }
	}
}
