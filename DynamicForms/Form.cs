using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DynamicForms.Questions;
using DynamicForms.Visitors;

namespace DynamicForms
{
    public class Form : IVisitorObject
    {
        private readonly Dictionary<string, FormAnswer> _formAnswers;

        public string Title { get; set; }
        public int FormAnswerCount => _formAnswers.Count;
        public IReadOnlyList<FormAnswer> FormAnswers => _formAnswers.Values.ToList();
        public QuestionRoot Root { get; }

        public Form(string title = "")
        {
            _formAnswers = new Dictionary<string, FormAnswer>();
            Root = new QuestionRoot(this);
            Title = title;
        }

        public FormAnswer FindOrCreateFormAnswer(string user)
        {
            if (string.IsNullOrEmpty(user))
            {
                return null;
            }

            if (_formAnswers.ContainsKey(user))
            {
                return _formAnswers[user];
            }

            var fa = new FormAnswer();
            _formAnswers.Add(user, fa);
            return fa;
        }

        [DebuggerStepThrough]
        public T Accept<T>(IVisitor<T> obj)
        {
            return obj.Visit(this);
        }
    }
}