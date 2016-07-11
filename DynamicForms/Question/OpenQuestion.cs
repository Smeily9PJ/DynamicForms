using DynamicForms.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Question
{
    public class OpenQuestion : QuestionBase
    {
        public override AnswerBase CreateAnswer()
        {
            var a = new OpenAnswer(this);
            this._answers.Add(a);
            return a;
        }
    }
}