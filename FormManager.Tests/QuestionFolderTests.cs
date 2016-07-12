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
            Assert.AreEqual(0, r.Questions.Count);

            var q1 = r.CreateQuestion(typeof(OpenQuestion));
            Assert.AreEqual(1, r.Questions.Count);

            var f1 = r.CreateQuestionFolder();
            Assert.AreEqual(2, r.Questions.Count);
            Assert.IsNotNull(r.Questions[1]);
            Assert.AreSame(f1, r.Questions[1]);
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
            Assert.AreEqual(0, fa.Answers.Count);
        }

        [Test]
        public void MoveQuestionInList()
        {
            var f = new Form();
            var r = f.Root;

            var q0 = r.CreateQuestion(typeof(OpenQuestion), "0");
            var q1 = r.CreateQuestion(typeof(OpenQuestion), "1");
            var q2 = r.CreateQuestion(typeof(OpenQuestion), "2");
            var q3 = r.CreateQuestion(typeof(OpenQuestion), "3");
            var q4 = r.CreateQuestion(typeof(OpenQuestion), "4");
            var q5 = r.CreateQuestion(typeof(OpenQuestion), "5");
            var q6 = r.CreateQuestion(typeof(OpenQuestion), "6");
            var q7 = r.CreateQuestion(typeof(OpenQuestion), "7");
            Assert.AreEqual(0, q0.Index);
            Assert.AreEqual(1, q1.Index);
            Assert.AreEqual(2, q2.Index);
            Assert.AreEqual(3, q3.Index);
            Assert.AreEqual(4, q4.Index);
            Assert.AreEqual(5, q5.Index);
            Assert.AreEqual(6, q6.Index);
            Assert.AreEqual(7, q7.Index);

            q4.Index = 1;

            Assert.AreEqual(0, q0.Index);
            Assert.AreEqual(1, q4.Index);
            Assert.AreEqual(2, q1.Index);
            Assert.AreEqual(3, q2.Index);
            Assert.AreEqual(4, q3.Index);
            Assert.AreEqual(5, q5.Index);
            Assert.AreEqual(6, q6.Index);
            Assert.AreEqual(7, q7.Index);
        }
    }
}