
using DynamicForms.Question;
using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class QuestionTests
    {
        [Test]
        public void CheckQuestion()
        {
            var q = new OpenQuestion(null);
            Assert.IsNotNull(q);
        }

        [Test]
        public void CheckAnswers()
        {
            var q = new OpenQuestion(null);
            Assert.IsNotNull(q.Answers);
        }

        [Test]
        public void CreateAnswer()
        {
            var q = new OpenQuestion(null);
            var a = q.CreateAnswer();
            Assert.IsNotNull(a);
        }

        [Test]
        public void CheckParent()
        {
            var q = new OpenQuestion(null);
            var a = q.Parent;
            Assert.IsNotNull(a);
        }
    }
}
