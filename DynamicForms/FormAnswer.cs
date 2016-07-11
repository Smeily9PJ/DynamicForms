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
        public List<AnswerBase<Task>> Answers { get; }
        public int AnswerCount => this.Answers.Count;

        public FormAnswer()
        {
            this.Answers = new List<AnswerBase>();
        }

        public AnswerBase AddAnswerFor(QuestionBase question)
        {
            var ab = new OpenAnswer(question);
            this.Answers.Add(ab);
            return ab;
        }

        public AnswerBase FindAnswerFor(QuestionBase question)
        {
            return this.Answers.FirstOrDefault(a => a.Question.Equals(question));
        }
    }
}
