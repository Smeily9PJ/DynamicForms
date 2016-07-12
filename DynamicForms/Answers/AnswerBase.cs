using DynamicForms.Questions;

namespace DynamicForms.Answers
{
    public abstract class AnswerBase
    {
        public QuestionBase Question { get; }

        public object Content { get; set; }

        protected AnswerBase(QuestionBase question)
        {
            this.Question = question;
        }

        protected AnswerBase(QuestionBase question, object content)
            : this(question)
        {
            this.Content = content;
        }
    }
}