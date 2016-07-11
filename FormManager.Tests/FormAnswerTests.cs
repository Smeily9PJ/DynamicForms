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
    }
}
