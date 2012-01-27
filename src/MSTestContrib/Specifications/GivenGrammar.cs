using System;

namespace MSTestContrib.Specifications
{
    public class GivenGrammar : ActionGrammar
    {
        public GivenGrammarPrefix Prefix { get; private set; }

        public GivenGrammar(SpecificationContext context, string description, Action<SpecificationContext> implementation, GivenGrammarPrefix prefix) : base(context, string.Format("{0} {1}", prefix, description), implementation)
        {
            Prefix = prefix;
        }
    }
}
