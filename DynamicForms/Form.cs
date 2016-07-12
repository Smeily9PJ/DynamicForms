using System.Collections.Generic;
using System.Linq;
using DynamicForms.Questions;

namespace DynamicForms
{
    public class Form
    {
        private readonly Dictionary<string, FormAnswer> _formAnswers;

        public string Title { get; set; }
        public int FormAnswerCount => _formAnswers.Count;
        public IReadOnlyList<FormAnswer> FormAnswers => _formAnswers.Values.ToList();

        public QuestionRoot Root { get; }

        public Form()
        {
            _formAnswers = new Dictionary<string, FormAnswer>();
            Root = new QuestionRoot(this);
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
    }
}