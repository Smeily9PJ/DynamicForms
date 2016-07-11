
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
            var q = new OpenQuestion();
            Assert.IsNotNull(q);
        }

        [Test]
        public void CheckAnswers()
        {
            var q = new OpenQuestion();
            Assert.IsNotNull(q.Answers);
        }

        [Test]
        public void CreateAnswer()
        {
            var q = new OpenQuestion();
            var a = q.CreateAnswer();
            Assert.IsNotNull(a);

        }
    }
}
