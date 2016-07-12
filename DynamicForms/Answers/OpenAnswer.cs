using DynamicForms.Questions;

namespace DynamicForms.Answers
{
    public class OpenAnswer : AnswerBase
    {
        public new string Content { get; set; }

        public OpenAnswer(OpenQuestion question)
            : base(question)
        {
        }
    }
}