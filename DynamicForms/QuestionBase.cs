using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms
{
    public abstract class QuestionBase
    {
        protected readonly List<AnswerBase> _answers;

        public IReadOnlyList<AnswerBase> Answers => this._answers;

        public QuestionBase Parent { get; private set; }

        public QuestionBase(QuestionBase parent)
        {
            this._answers = new List<AnswerBase>();
            this.Parent = parent;
        }

        public abstract AnswerBase CreateAnswer();
    }
}
