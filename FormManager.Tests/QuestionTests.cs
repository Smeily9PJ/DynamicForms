using DynamicForms.Questions;
using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class QuestionTests
    {
        [Test]
        public void CheckQuestion()
        {
            var f = new Form();
            var q = new OpenQuestion(f.Root);
            Assert.IsNotNull(q);
        }

        [Test]
        public void CheckAnswers()
        {
            var f = new Form();
            var q = new OpenQuestion(f.Root);
            Assert.IsNotNull(q.Answers);
        }

        [Test]
        public void CreateAnswer()
        {
            var f = new Form();
            var q = new OpenQuestion(f.Root);
            var a = q.CreateAnswer();
            Assert.IsNotNull(a);
        }

        [Test]
        public void CheckParent()
        {
            var f = new Form();
            var q = new OpenQuestion(f.Root);
            var a = q.Parent;
            Assert.IsNotNull(a);
        }

        [Test]
        public void CheckTitle()
        {
            var f = new Form();

            var q = new OpenQuestion(f.Root);
            Assert.IsNullOrEmpty(q.Title);
            q.Title = "C'est un titre ouf !";
            Assert.IsNotNullOrEmpty(q.Title);

            var q2 = new OpenQuestion(f.Root, "Titre de ouf 2!");
            Assert.IsNotNullOrEmpty(q2.Title);

            var q3 = new OpenQuestion(f.Root, string.Empty);
            Assert.IsNullOrEmpty(q3.Title);
        }
    }
}