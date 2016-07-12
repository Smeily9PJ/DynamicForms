using System;
using System.Diagnostics;
using DynamicForms.Visitors;

namespace DynamicForms.Questions
{
    public class QuestionRoot : QuestionFolder
    {
        public Form Form { get; }

        public QuestionRoot(Form form, string title = "")
            : base(title)
        {
            if (form == null) throw new ArgumentNullException(nameof(form));
            Form = form;
        }

        [DebuggerStepThrough]
        public override T Accept<T>(IVisitor<T> obj)
        {
            return obj.Visit(this);
        }
    }
}