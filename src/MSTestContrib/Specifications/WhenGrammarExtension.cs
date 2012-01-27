using System;

namespace MSTestContrib.Specifications
{
    public static class WhenGrammarExtension
    {
        public static WhenGrammar When(this GivenGrammar givenGrammar, string description, Action<SpecificationContext> implementation)
        {
            var whenGrammar = new WhenGrammar(givenGrammar.Context, description, implementation, WhenGrammarPrefix.When);
            whenGrammar.Evaluate();
            return whenGrammar;
        }

        public static WhenGrammar When(this GivenGrammar givenGrammar, string description)
        {
            return When(givenGrammar, description, null);
        }

        public static WhenGrammar And(this WhenGrammar whenGrammar, string description, Action<SpecificationContext> implementation)
        {
            var andWhenGrammar = new WhenGrammar(whenGrammar.Context, description, implementation, WhenGrammarPrefix.And);
            andWhenGrammar.Evaluate();
            return andWhenGrammar;
        }

        public static WhenGrammar And(this WhenGrammar whenGrammar, string description)
        {
            return And(whenGrammar, description, null);
        }
    }
}
