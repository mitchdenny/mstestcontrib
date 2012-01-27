using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSTestContrib.Specifications
{
    public class WhenGrammar : ActionGrammar
    {
        public WhenGrammarPrefix Prefix { get; private set; }

        public WhenGrammar(SpecificationContext context, string description, Action<SpecificationContext> implementation, WhenGrammarPrefix prefix) : base(context, string.Format("{0} {1}", prefix, description), implementation)
        {
            Prefix = prefix;
        }
    }
}
