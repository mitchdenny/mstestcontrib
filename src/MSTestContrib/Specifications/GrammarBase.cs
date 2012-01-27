using System;
namespace MSTestContrib.Specifications
{
    public abstract class GrammarBase
    {
        public SpecificationContext Context { get; private set; }
        public string Description { get; private set; }
        public GrammarResult Result { get; protected set; }
        public Exception Exception { get; protected set; }

        protected GrammarBase(SpecificationContext context, string description)
        {
            Context = context;
            Description = description;
            Result = GrammarResult.Unknown;
        }

        public virtual void Evaluate()
        {
            Context.Grammars.Add(this);
        }
    }
}
