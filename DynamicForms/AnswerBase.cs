using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms
{
    public abstract class AnswerBase<T>
    {
        public QuestionBase Question { get; }

        public T Content { get; set; }

        public AnswerBase(QuestionBase question)
        {
            this.Question = question;
        }
    }
}
