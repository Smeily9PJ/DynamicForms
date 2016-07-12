using System;
using System.Collections.Generic;
using System.Linq;
using DynamicForms.Answers;
using DynamicForms.Visitors;

namespace DynamicForms.Questions
{
    public class QuestionFolder : QuestionBase
    {
        private readonly List<QuestionBase> _questions;

        public IReadOnlyList<QuestionBase> Questions => _questions;

        private QuestionFolder(QuestionBase parent, string title = "")
            : base(parent, title)
        {
            CheckParentIsNotNull(parent);
            _questions = new List<QuestionBase>();
        }

        internal QuestionFolder(string title)
            : base(title)
        {
            _questions = new List<QuestionBase>();
        }

        public QuestionFolder CreateQuestionFolder(string title = "")
        {
            return new QuestionFolder(this, title);
        }

        public QuestionBase CreateQuestion(Type questionType, string title = "", params object[] parameters)
        {
            if (!questionType.IsSubclassOf(typeof(QuestionBase))) throw new ArgumentException($"{nameof(questionType)} is not of type QuestionBase");

            var o = parameters != null && parameters.Any()
                ? Activator.CreateInstance(questionType, this, title, parameters)
                : Activator.CreateInstance(questionType, this, title);
            var q = (QuestionBase)o;

            _questions.Add(q);
            return q;
        }

        public bool RemoveQuestion(QuestionBase question)
        {
            if (question == null) return false;
            if (!_questions.Contains(question)) return false;

            question.ClearAnswers();

            return _questions.Remove(question);
        }

        public override AnswerBase CreateAnswer()
        {
            return null;
        }

        public override T Accept<T>(IVisitor<T> obj)
        {
            throw new NotImplementedException();
        }

        internal int GetIndexOf(QuestionBase question)
        {
            return _questions.IndexOf(question);
        }

        internal void ChangeIndexOfQuestion(QuestionBase question, int index)
        {
            if (question == null) throw new ArgumentNullException(nameof(question));
            if (index < 0 || index >= _questions.Count) throw new ArgumentOutOfRangeException(nameof(index));

            var currentIndex = _questions.IndexOf(question);
            _questions.RemoveAt(currentIndex);
            _questions.Insert(index, question);
        }
    }
}