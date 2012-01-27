using System;

namespace MSTestContrib.Specifications
{
    public static class GivenGrammarExtension
    {
        public static GivenGrammar And(this GivenGrammar givenGrammar, string description, Action<SpecificationContext> implementation)
        {
            var andGivenGrammar = new GivenGrammar(givenGrammar.Context, description, implementation, GivenGrammarPrefix.And);
            andGivenGrammar.Evaluate();
            return andGivenGrammar;
        }

        public static GivenGrammar And(this GivenGrammar givenGrammar, string description)
        {
            return And(givenGrammar, description, null);
        }
    }
}
