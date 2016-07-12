using System;
using DynamicForms.Questions;
using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class QuestionRootTests
    {
        [Test]
        public void CheckQuestionRoot()
        {
            var f = new Form();

            var q = new QuestionRoot(f);
            Assert.IsNotNull(q);

            var q2 = new QuestionRoot(f, "C'est une titre !");
            Assert.IsNotNullOrEmpty(q2.Title);

            Assert.Throws<ArgumentNullException>(() => new QuestionRoot(null));
        }

        [Test]
        public void CheckForm()
        {
            var f = new Form();
            var q = new QuestionRoot(f);
            Assert.IsNotNull(q.Form);
            Assert.AreSame(q.Form, f);
        }

        [Test]
        public void CheckQuestions()
        {
            var f = new Form();
            var r = f.Root;
            Assert.IsNotNull(r.Questions);
        }
    }
}