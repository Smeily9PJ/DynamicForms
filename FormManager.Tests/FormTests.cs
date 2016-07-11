using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class FormTests
    {
        [Test]
        public void CheckForm()
        {
            var f = new Form();
            Assert.IsNotNull(f);
        }

        [Test]
        public void CheckTitle()
        {
            var f = new Form();
            f.Title = "Test";
            Assert.AreEqual("Test", f.Title);
        }

        [Test]
        public void CreateEmptyKeyAnswers()
        {
            var f = new Form();
            Assert.IsNull(f.FindOrCreateFormAnswer(""));
        }

        [Test]
        public void CreateAnswers()
        {
            var f = new Form();
            var fa = f.FindOrCreateFormAnswer("testeur");
            Assert.IsNotNull(fa);
        }

        [Test]
        public void FindAnswers()
        {
            var f = new Form();
            var fa1 = f.FindOrCreateFormAnswer("testeur");
            Assert.IsNotNull(fa1);
            var fa2 = f.FindOrCreateFormAnswer("testeur");
            Assert.IsNotNull(fa2);
            Assert.AreSame(fa1, fa2);
        }

        [Test]
        public void CreateDifferentAnswers()
        {
            var f = new Form();
            var fa1 = f.FindOrCreateFormAnswer("testeur1");
            Assert.IsNotNull(fa1);
            var fa2 = f.FindOrCreateFormAnswer("testeur2");
            Assert.IsNotNull(fa2);
            Assert.AreNotSame(fa1, fa2);
        }

        [Test]
        public void CheckAnswersCount()
        {
            var f = new Form();
            Assert.AreEqual(0, f.FormAnswerCount);
            for (int i = 0; i < 2; i++)
            {
                f.FindOrCreateFormAnswer("testeur");
                Assert.AreEqual(1, f.FormAnswerCount);
            }
            f.FindOrCreateFormAnswer("toto");
            Assert.AreEqual(2, f.FormAnswerCount);
        }

        [Test]
        public void CheckAnswersType()
        {
            var f = new Form();
            Assert.AreEqual(0, f.FormAnswerCount);
            var fa = f.FindOrCreateFormAnswer("testeur");
            Assert.IsInstanceOf<FormAnswer>(fa);
            var fa2 = f.FindOrCreateFormAnswer("testeur");
            Assert.IsInstanceOf<FormAnswer>(fa2);
        }

        [Test]
        public void CheckQuestions()
        {
            var f = new Form();
            Assert.IsNotNull(f.Questions);
            Assert.IsInstanceOf<QuestionRoot>(f.Questions);
        }
    }
}
