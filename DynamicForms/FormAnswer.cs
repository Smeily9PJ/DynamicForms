using System.Collections.Generic;
using System.Linq;
using DynamicForms.Answers;
using DynamicForms.Questions;

namespace DynamicForms
{
    public class FormAnswer
    {
        public List<AnswerBase> Answers { get; }
        public int AnswerCount => Answers.Count;

        public FormAnswer()
        {
            Answers = new List<AnswerBase>();
        }

        public AnswerBase AddAnswerFor(QuestionBase question)
        {
            var a = question.CreateAnswer();
            Answers.Add(a);
            return a;
        }

        public AnswerBase FindAnswerFor(QuestionBase question)
        {
            return Answers.FirstOrDefault(a => a.Question.Equals(question));
        }
    }
}