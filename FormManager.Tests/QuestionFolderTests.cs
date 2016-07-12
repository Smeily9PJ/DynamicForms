using System;
using DynamicForms.Questions;
using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class QuestionFolderTests
    {
        [Test]
        public void CheckQuestionFolder()
        {
            var f = new Form();
            var q = f.Root.CreateQuestionFolder();
            Assert.IsNotNull(q);
        }

        [Test]
        public void CheckQuestions()
        {
            var f = new Form();
            var q = f.Root.CreateQuestionFolder();
            Assert.IsNotNull(q.Questions);
        }

        [Test]
        public void AddQuestion()
        {
            var f = new Form();
            Assert.AreEqual(0, f.Root.Questions.Count);

            var q1 = f.Root.CreateQuestion(typeof(OpenQuestion));
            Assert.IsNotNull(q1);
            Assert.AreEqual(1, f.Root.Questions.Count);
            Assert.AreSame(f.Root, q1.Parent);

            Assert.Throws<ArgumentException>(() => f.Root.CreateQuestion(typeof(object)));
            Assert.AreEqual(1, f.Root.Questions.Count);

            var q2 = f.Root.CreateQuestion(typeof(OpenQuestion), "Toto");
            Assert.AreEqual(2, f.Root.Questions.Count);
            Assert.AreEqual("Toto", q2.Title);
        }

        [Test]
        public void HierachyOfQuestions()
        {
            var f = new Form();

            var r = f.Root;
            var q1 = r.CreateQuestion(typeof(OpenQuestion));

            var f1 = r.CreateQuestionFolder();
            var q2 = f1.CreateQuestion(typeof(OpenQuestion));

            var f2 = f1.CreateQuestionFolder();

            var f3 = f2.CreateQuestionFolder();

            Assert.AreSame(r, q1.Parent);
            Assert.AreSame(r, f1.Parent);
            Assert.AreSame(f1, q2.Parent);
            Assert.AreSame(f1, f2.Parent);
            Assert.AreSame(f2, f3.Parent);
        }

        [Test]
        public void AddAnswer()
        {
            var f = new Form();
            var r = f.Root;

            var a1 = f.Root.CreateAnswer();
            Assert.IsNull(a1);

            var q = r.CreateQuestion(typeof(OpenQuestion));
            var a2 = q.CreateAnswer();
            Assert.IsNotNull(a2);
        }

        [Test]
        public void RemoveQuestion()
        {
            var f = new Form();
            var r = f.Root;
            var q = r.CreateQuestion(typeof(OpenQuestion));
            var a = q.CreateAnswer();
            a.Content = "toto";

            var result = r.RemoveQuestion(q);
            Assert.True(result);
            Assert.AreEqual(0, r.Questions.Count);
        }

        [Test]
        public void RemoveQuestion2()
        {
            var f = new Form();
            var fa = f.FindOrCreateFormAnswer("toto");
            var r = f.Root;
            var q = r.CreateQuestion(typeof(OpenQuestion));
            var a = fa.AddAnswerFor(q);
            a.Content = "toto";

            var result = r.RemoveQuestion(q);
            Assert.True(result);
            Assert.AreEqual(0, r.Questions.Count);
        }

        [Test]
        public void ClearAnswersWhenRemoveQuestion()
        {
            var f = new Form();
            var fa = f.FindOrCreateFormAnswer("toto");
            var r = f.Root;
            var q = r.CreateQuestion(typeof(OpenQuestion));
            var a = fa.AddAnswerFor(q);
            a.Content = "toto";

            r.RemoveQuestion(q);
            Assert.AreEqual(0, q.Answers.Count);
            Assert.AreEqual(0, fa.AnswerCount);
        }
    }
}