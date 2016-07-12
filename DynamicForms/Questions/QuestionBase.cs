using System;
using System.Collections.Generic;
using System.Linq;
using DynamicForms.Answers;
using DynamicForms.Visitors;

namespace DynamicForms.Questions
{
    public abstract class QuestionBase : IVisitorObject
    {
        public IReadOnlyList<AnswerBase> Answers => AnswersList;
        public QuestionBase Parent { get; }
        public string Title { get; set; }

        public int Index
        {
            get
            {
                if (Parent.GetType().IsSubclassOf(typeof(QuestionFolder)))
                {
                    return ((QuestionFolder)Parent).GetIndexOf(this);
                }
                return -1;
            }
            set
            {
                if (Parent.GetType().IsSubclassOf(typeof(QuestionFolder)))
                {
                    ((QuestionFolder)Parent).ChangeIndexOfQuestion(this, value);
                }
            }
        }

        protected readonly List<AnswerBase> AnswersList;

        protected QuestionBase(QuestionBase parent, string title = "")
        {
            AnswersList = new List<AnswerBase>();
            Parent = parent;
            Title = title;
        }

        internal QuestionBase(string title)
            : this(null, title)
        {
        }

        public void ClearAnswers()
        {
            ClearAnswersInFormAnswer(this);
            AnswersList.Clear();
        }

        public abstract AnswerBase CreateAnswer();

        public abstract T Accept<T>(IVisitor<T> obj);

        protected void CheckParentIsNotNull(QuestionBase parent)
        {
            if (parent == null) throw new ArgumentNullException(nameof(parent));
        }

        private void ClearAnswersInFormAnswer(QuestionBase parent)
        {
            var root = parent as QuestionRoot;
            if (root != null)
            {
                var r = root;
                foreach (var answer in r.Form.FormAnswers.Select(x => x.Answers))
                {
                    var a = answer.FirstOrDefault(x => x.Question.Equals(this));
                    if (a != null) answer.Remove(a);
                }
            }
            else
            {
                ClearAnswersInFormAnswer(parent.Parent);
            }
        }
    }
}