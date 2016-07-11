using DynamicForms.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms
{
    public class FormAnswer
    {
        public List<AnswerBase> Answers { get; }
        public int AnswerCount => this.Answers.Count;

        public FormAnswer()
        {
            this.Answers = new List<AnswerBase>();
        }

        public AnswerBase AddAnswerFor(QuestionBase question)
        {
            var a = question.CreateAnswer();
            this.Answers.Add(a);
            return a;
        }

        public AnswerBase FindAnswerFor(QuestionBase question)
        {
            return this.Answers.FirstOrDefault(a => a.Question.Equals(question));
        }
    }
}
