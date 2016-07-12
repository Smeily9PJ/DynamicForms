using System.Collections.Generic;
using System.Diagnostics;
using DynamicForms.Visitors;

namespace DynamicForms
{
    public class FormManager : IVisitorObject
    {
        public List<Form> Forms { get; }

        public FormManager()
        {
            Forms = new List<Form>();
        }

        [DebuggerStepThrough]
        public T Accept<T>(IVisitor<T> obj)
        {
            return obj.Visit(this);
        }
    }
}