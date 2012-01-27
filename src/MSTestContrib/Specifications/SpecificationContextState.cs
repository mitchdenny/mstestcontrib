using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using MSTestContrib.Properties;
using System.Diagnostics;

namespace MSTestContrib.Specifications
{
    public class SpecificationContextState : DynamicObject
    {
        public SpecificationContextState()
        {
            StateValues = new Dictionary<string, object>();
        }

        public Dictionary<string, object> StateValues { get; set; }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Debug.Print("Called try get member.");
            var baseInvocationSuccessful = base.TryGetMember(binder, out result);
            if (baseInvocationSuccessful) return true;

            result = StateValues[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Debug.Print("Called try set member.");

            var baseInvocationSuccessful = base.TrySetMember(binder, value);
            if (baseInvocationSuccessful) return true;

            if (!StateValues.ContainsKey(binder.Name))
            {
                StateValues[binder.Name] = value;
                return true;
            }

            if (StateValues[binder.Name].GetType().IsAssignableFrom(binder.ReturnType))
            {
                StateValues[binder.Name] = value;
                return true;
            }
            else
            {
                var message = string.Format(
                    Resources.ExceptionMessageStatePropertyNotAssignable,
                    binder.Name,
                    StateValues[binder.Name].GetType()
                    );
                throw new InvalidOperationException(message);
            }
        }
    }
}
