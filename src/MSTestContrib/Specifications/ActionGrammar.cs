using System;

namespace MSTestContrib.Specifications
{
    public abstract class ActionGrammar : ExecutableGrammar<Action<SpecificationContext>>
    {
        protected ActionGrammar(SpecificationContext context, string description, Action<SpecificationContext> implementation) : base(context, description, implementation)
        {
        }

        public override void Execute()
        {
            Implementation(Context);
            Result = GrammarResult.Passed;
        }
    }
}
