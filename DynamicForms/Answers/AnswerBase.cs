using DynamicForms.Questions;
using DynamicForms.Visitors;

namespace DynamicForms.Answers
{
    public abstract class AnswerBase : IVisitorObject
    {
        public QuestionBase Question { get; }
        public object Content { get; set; }

        protected AnswerBase(QuestionBase question)
        {
            Question = question;
        }

        protected AnswerBase(QuestionBase question, object content)
            : this(question)
        {
            Content = content;
        }

        public abstract T Accept<T>(IVisitor<T> obj);
    }
}