using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSTestContrib.Specifications
{
    public class ThenGrammar : FunctionGrammar
    {
        public ThenGrammarPrefix Prefix { get; private set; }

        public ThenGrammar(SpecificationContext context, string description, Func<SpecificationContext, bool> implementation, ThenGrammarPrefix prefix) : base(context, string.Format("{0} {1}", prefix, description), implementation)
        {
            Prefix = prefix;
        }
    }
}
