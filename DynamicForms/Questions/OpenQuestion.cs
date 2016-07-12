using System.Diagnostics;
using DynamicForms.Answers;
using DynamicForms.Visitors;

namespace DynamicForms.Questions
{
    public class OpenQuestion : QuestionBase
    {
        public OpenQuestion(QuestionBase parent)
            : this(parent, string.Empty)
        {

        }

        public OpenQuestion(QuestionBase parent, string title)
            : base(parent, title)
        {
            CheckParentIsNotNull(parent);
        }

        public override AnswerBase CreateAnswer()
        {
            var a = new OpenAnswer(this);
            AnswersList.Add(a);
            return a;
        }

        [DebuggerStepThrough]
        public override T Accept<T>(IVisitor<T> obj)
        {
            return obj.Visit(this);
        }
    }
}