using DynamicForms.Question;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Tests
{
    [TestFixture]
    class FormAnswerTests
    {
        [Test]
        public void CheckFormAnswer()
        {
            var fa = new FormAnswer();
            Assert.IsNotNull(fa);
        }

        [Test]
        public void CheckAnswers()
        {
            var fa = new FormAnswer();
            Assert.IsNotNull(fa.Answers);
        }

        [Test]
        public void CountAnswers()
        {
            var fa = new FormAnswer();
            Assert.AreEqual(0, fa.AnswerCount);
        }

        [Test]
        public void AddAnswer()
        {
            var fa = new FormAnswer();
            var ab = fa.AddAnswerFor(new OpenQuestion());
            Assert.AreEqual(1, fa.AnswerCount);
        }

        [Test]
        public void FindAnswer()
        {
            var fa = new FormAnswer();
            var ab = fa.FindAnswerFor(new OpenQuestion());
            Assert.IsNull(ab);
        }

        [Test]
        public void FindOneAnswer()
        {
            var fa = new FormAnswer();
            var q = new OpenQuestion();
            var ab1 = fa.AddAnswerFor(q);
            Assert.IsNotNull(ab1);
            var ab2 = fa.FindAnswerFor(q);
            Assert.IsNotNull(ab2);
            Assert.AreSame(ab1, ab2);
        }
    }
}
