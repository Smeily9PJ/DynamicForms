using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms
{
    public abstract class AnswerBase
    {
        public QuestionBase Question { get; }

        public object Content { get; protected set; }

        protected AnswerBase(QuestionBase question)
        {
            this.Question = question;
        }
    }
}
