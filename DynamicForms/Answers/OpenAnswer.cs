using System.Diagnostics;
using DynamicForms.Questions;
using DynamicForms.Visitors;

namespace DynamicForms.Answers
{
    public class OpenAnswer : AnswerBase
    {
        public new string Content { get; set; }

        public OpenAnswer(OpenQuestion question)
            : base(question)
        {
        }

        [DebuggerStepThrough]
        public override T Accept<T>(IVisitor<T> obj)
        {
            return obj.Visit(this);
        }
    }
}