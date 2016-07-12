using DynamicForms.Questions;
using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class FormAnswerTests
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
            Assert.AreEqual(0, fa.Answers.Count);
        }

        [Test]
        public void AddAnswer()
        {
            var f = new Form();
            var q = new OpenQuestion(f.Root);

            var fa = new FormAnswer();
            var ab = fa.AddAnswerFor(q);
            Assert.IsNotNull(ab);
            Assert.AreEqual(1, fa.Answers.Count);
            Assert.AreEqual(1, q.Answers.Count);
        }

        [Test]
        public void FindAnswer()
        {
            var f = new Form();
            var q = new OpenQuestion(f.Root);

            var fa = new FormAnswer();
            var ab = fa.FindAnswerFor(q);
            Assert.IsNull(ab);
        }

        [Test]
        public void FindOneAnswer()
        {
            var f = new Form();
            var q = new OpenQuestion(f.Root);

            var fa = new FormAnswer();
            var ab1 = fa.AddAnswerFor(q);
            Assert.IsNotNull(ab1);
            var ab2 = fa.FindAnswerFor(q);
            Assert.IsNotNull(ab2);
            Assert.AreSame(ab1, ab2);
        }
    }
}