using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSTestContrib.Specifications
{
    public static class ThenGrammarExtension
    {
        public static ThenGrammar Then(this GivenGrammar givenGrammar, string description, Func<SpecificationContext, bool> implementation)
        {
            var thenGrammar = new ThenGrammar(givenGrammar.Context, description, implementation, ThenGrammarPrefix.Then);
            thenGrammar.Evaluate();
            return thenGrammar;
        }

        public static ThenGrammar Then(this GivenGrammar givenGrammar, string description)
        {
            return Then(givenGrammar, description, null);
        }

        public static ThenGrammar Then(this WhenGrammar whenGrammar, string description, Func<SpecificationContext, bool> implementation)
        {
            var thenGrammar = new ThenGrammar(whenGrammar.Context, description, implementation, ThenGrammarPrefix.Then);
            thenGrammar.Evaluate();
            return thenGrammar;
        }

        public static ThenGrammar Then(this WhenGrammar whenGrammar, string description)
        {
            return Then(whenGrammar, description, null);
        }

        public static ThenGrammar And(this ThenGrammar thenGrammar, string description, Func<SpecificationContext, bool> implementation)
        {
            var andThenGrammar = new ThenGrammar(thenGrammar.Context, description, implementation, ThenGrammarPrefix.Then);
            andThenGrammar.Evaluate();
            return andThenGrammar;
        }

        public static ThenGrammar And(this ThenGrammar thenGrammar, string description)
        {
            return And(thenGrammar, description, null);
        }
    }
}
