using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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