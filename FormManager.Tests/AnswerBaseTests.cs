using DynamicForms.Answers;
using DynamicForms.Questions;
using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class AnswerBaseTests
    {
        [Test]
        public void CheckAnswer()
        {
            var f = new Form();
            var q = new OpenQuestion(f.Root);
            var a = new OpenAnswer(q);
            Assert.IsNotNull(a);
        }

        [Test]
        public void CheckAnswerQuestion()
        {
            var f = new Form();
            var q = new OpenQuestion(f.Root);
            var a = new OpenAnswer(q);
            Assert.AreSame(a.Question, q);
        }

        [Test]
        public void AnswerContent()
        {
            var f = new Form();
            var q = new OpenQuestion(f.Root);
            var a = new OpenAnswer(q);
            Assert.IsNull(a.Content);
            string response = "Réponse !!!!!!!!!";
            a.Content = "Réponse !!!!!!!!!";
            Assert.IsInstanceOf<string>(a.Content);
            Assert.AreEqual(a.Content, response);
        }
    }
}