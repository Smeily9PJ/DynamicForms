using System;
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
            this.AnswersList.Add(a);
            return a;
        }

        public override T Accept<T>(IVisitor<T> obj)
        {
            throw new NotImplementedException();
        }
    }
}