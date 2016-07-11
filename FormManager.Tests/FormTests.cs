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
    }
}
