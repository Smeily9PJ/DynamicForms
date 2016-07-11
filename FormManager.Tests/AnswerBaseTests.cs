using DynamicForms.Answer;
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
    public class AnswerBaseTests
    {
        [Test]
        public void CheckAnswer()
        {
            var a = new OpenAnswer(new OpenQuestion(null));
            Assert.IsNotNull(a);
        }

        [Test]
        public void CheckAnswerQuestion()
        {
            var q = new OpenQuestion(null);
            var a = new OpenAnswer(q);
            Assert.AreSame(a.Question, q);
        }

        [Test]
        public void AnswerContent()
        {
            var q = new OpenQuestion(null);
            var a = new OpenAnswer(q);
            Assert.IsNull(a.Content);
            string response = "Réponse !!!!!!!!!";
            a.Content = "Réponse !!!!!!!!!";
            Assert.IsInstanceOf<string>(a.Content);
            Assert.AreEqual(a.Content, response);
        }
    }
}
