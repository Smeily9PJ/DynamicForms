using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Answer
{
    public class OpenAnswer : AnswerBase<string>
    {
        public OpenAnswer(QuestionBase question) : base(question)
        {
        }

    }
}
